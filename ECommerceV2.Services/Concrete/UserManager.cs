using AutoMapper;
using EcommerceV2.Entities.Concrete;
using EcommerceV2.Entities.Dtos;
using ECommerceV2.Data.Abstract;
using ECommerceV2.Services.Abstract;
using ECommerceV2.Services.Abstract.Encryption;
using ECommerceV2.Services.Concrete.Encryption;
using ECommerceV2.Shared.Utilities.Results.Abstract;
using ECommerceV2.Shared.Utilities.Results.ComplexTypes;
using ECommerceV2.Shared.Utilities.Results.Concrete;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerceV2.Services.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public UserManager(IUnitOfWork unitOfWork, IMapper mapper, IEncryptionStrategy encryption)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<UserDto>> Authenticate(UserDto userDto)
        {
            var mUser = await _unitOfWork.Users.GetAsync(x => x.Email == userDto.Email);
            var mUserDto = _mapper.Map<MUser, UserDto>(mUser);
            if (mUserDto != null)
            {
                EncryptionStrategy x = new EncryptionStrategy(new M5Encryption());
                var toBigger = x.Encrypt(mUserDto.PasswordHash).ToUpper();
                var toLower = x.Encrypt(mUserDto.PasswordHash).ToLower();
                if (Encoding.Default.GetString(mUser.PasswordHash) != toBigger && Encoding.Default.GetString(mUser.PasswordHash) != toLower)
                {
                    return WrongPasswordError();
                }
                else
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenKey = Encoding.ASCII.GetBytes("5B668EE3972691212B2342DADCFFB");
                    var tokenDescriptor = new SecurityTokenDescriptor()
                    {
                        Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Name, mUserDto.Email)
                    }),
                        Expires = DateTime.Now.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                    };

                    mUserDto.Token = tokenHandler.CreateToken(tokenDescriptor);

                    return new DataResult<UserDto>(EResultStatus.Success, "Kullanıcı doğrulandı", mUserDto);
                }
            }
            else
            {
                return WrongPasswordError();
            }
        }

        public async Task<IResult> AddAsync(UserDto userDto, string createdByUserUniqueId)
        {
            var user = _mapper.Map<MUser>(userDto);
            user.CreatedByUserUniqueId = createdByUserUniqueId;
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveAsync();
            return new Result(EResultStatus.Success, "Kullanıcı oluşturuldu");
        }

        public async Task<IResult> CountAsync()
        {
            var usersCount = await _unitOfWork.Users.CountAsync();
            if (usersCount > -1)
            {
                return new DataResult<int>(EResultStatus.Success, usersCount);
            }
            else
            {
                return new DataResult<int>(EResultStatus.Error, $"Beklenmeyen bir hata ile karşılaşıldı.", -1);
            }
        }

        public async Task<IResult> DeleteAsync(int userId, string modifiedByUserUniqueId)
        {
            var user = await _unitOfWork.Users.GetAsync(x => x.Id == userId);
            if (user != null)
            {
                user.IsDeleted = true;
                user.ModifiedByUserUniqueId = modifiedByUserUniqueId;
                user.ModifiedDate = DateTime.Now;
                await _unitOfWork.Users.UpdateAsync(user);
                await _unitOfWork.SaveAsync();
                return new Result(EResultStatus.Success, "Kullanıcı silindi");
            }

            return new Result(EResultStatus.Error, "Hata oluştu");
        }

        public async Task<IDataResult<UserListDto>> GetAllAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync(null);
            if (users.Count > -1)
            {
                return new DataResult<UserListDto>(EResultStatus.Success, new UserListDto
                {
                    Users = users
                });
            }

            return new DataResult<UserListDto>(EResultStatus.Error, "Sistemde henüz tanımlı kullanıcı yok.", null);
        }

        public async Task<IDataResult<UserListDto>> GetAllByNonBlockedUsersAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync(x => !x.Blocked);
            if (users.Count > -1)
            {
                return new DataResult<UserListDto>(EResultStatus.Success, new UserListDto
                {
                    Users = users,
                });
            }

            return new DataResult<UserListDto>(EResultStatus.Error, "Henüz engellenen kullanıcı yok.", new UserListDto
            {
                Users = null,
            });
        }

        public async Task<IDataResult<UserListDto>> GetAllByNonDeletedAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync(x => !x.IsDeleted);
            if (users.Count > -1)
            {
                return new DataResult<UserListDto>(EResultStatus.Success, new UserListDto
                {
                    Users = users,
                });
            }

            return new DataResult<UserListDto>(EResultStatus.Error, "Henüz silinen kullanıcı yok.", new UserListDto
            {
                Users = null,
            });
        }

        public async Task<IDataResult<UserDto>> GetAsync(int userId)
        {
            var user = await _unitOfWork.Users.GetAsync(x => x.Id == userId);
            var userDto = _mapper.Map<MUser, UserDto>(user);
            if (user != null)
            {
                return new DataResult<UserDto>(EResultStatus.Success, userDto);
            }

            return new DataResult<UserDto>(EResultStatus.Error, "Kullanıcı bulunamadı", null);
        }

        public async Task<IResult> HardDelete(int userId)
        {
            var user = await _unitOfWork.Users.GetAsync(x => x.Id == userId);
            if (user != null)
            {
                await _unitOfWork.Users.DeleteAsync(user);
                await _unitOfWork.SaveAsync();
                new Result(EResultStatus.Success, "Kullanıcı sistemden tamamen silindi");
            }

            return new Result(EResultStatus.Error, "Bu Id'ye ait kullanıcı bulunamadı");
        }

        public async Task<IResult> UpdateAsync(UserDto userDto, string modifiedByUserUniqueId)
        {
            var oldUser = await _unitOfWork.Users.GetAsync(x => x.Id == userDto.Id);
            var user = _mapper.Map(userDto, oldUser);
            user.ModifiedByUserUniqueId = modifiedByUserUniqueId;
            var updatedUser = await _unitOfWork.Users.UpdateAsync(user);
            var updatedUserDto = _mapper.Map<MUser, UserDto>(updatedUser);
            await _unitOfWork.SaveAsync();
            return new DataResult<UserDto>(EResultStatus.Success, "Kullanıcı üzerindeki değişiklikler başarıyla tamamlandı.", updatedUserDto);
        }

        IDataResult<UserDto> WrongPasswordError()
        {
            return new DataResult<UserDto>(EResultStatus.Error, "Kullanıcı adı veya şifre yanlış, lütfen kontrol ediniz!", null);
        }
    }
}
