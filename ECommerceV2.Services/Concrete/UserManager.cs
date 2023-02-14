using AutoMapper;
using EcommerceV2.Entities.Concrete;
using EcommerceV2.Entities.Dtos;
using ECommerceV2.Data.Abstract;
using ECommerceV2.Services.Abstract;
using ECommerceV2.Shared.Utilities.Results.Abstract;
using ECommerceV2.Shared.Utilities.Results.ComplexTypes;
using ECommerceV2.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceV2.Services.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IResult> AddAsync(UserDto userDto, string createdByUserUniqueId)
        {
            var user = _mapper.Map<MUser>(userDto);
            user.CreatedByName = createdByUserUniqueId;
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
            var user = await _unitOfWork.Users.GetAsync(x => x.Id== userId);
            if(user != null)
            {
                user.IsDeleted= true;
                user.ModifiedByName = modifiedByUserUniqueId;
                user.ModifiedDate = DateTime.Now;
                await _unitOfWork.Users.UpdateAsync(user);
                await _unitOfWork.SaveAsync();
                return new Result(EResultStatus.Success,"Kullanıcı silindi");
            }

            return new Result(EResultStatus.Error, "Hata oluştu");
        }

        public async Task<IDataResult<UserListDto>> GetAllAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync(null);
            if(users.Count>-1)
            {
                return new DataResult<UserListDto>(EResultStatus.Success, new UserListDto {
                    Users= users,
                    ResultStatus = EResultStatus.Success
                });
            }

            return new DataResult<UserListDto>(EResultStatus.Error, "Sistemde henüz tanımlı kullanıcı yok.", new UserListDto {
                Users = null,
                ResultStatus = EResultStatus.Error,
                Message = "Sistemde henüz tanımlı kullanıcı yok."
            });
        }

        public async Task<IDataResult<UserListDto>> GetAllByNonBlockedUsersAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync(x => !x.Blocked);
            if (users.Count > -1)
            {
                return new DataResult<UserListDto>(EResultStatus.Success, new UserListDto
                {
                    Users = users,
                    ResultStatus = EResultStatus.Success
                });
            }

            return new DataResult<UserListDto>(EResultStatus.Error, "Henüz engellenen kullanıcı yok.", new UserListDto
            {
                Users = null,
                ResultStatus = EResultStatus.Error,
                Message = "Henüz engellenen kullanıcı yok."
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
                    ResultStatus = EResultStatus.Success
                });
            }

            return new DataResult<UserListDto>(EResultStatus.Error, "Henüz silinen kullanıcı yok.", new UserListDto
            {
                Users = null,
                ResultStatus = EResultStatus.Error,
                Message = "Henüz silinen kullanıcı yok."
            });
        }

        public async Task<IDataResult<UserDto>> GetAsync(int userId)
        {
            var user = await _unitOfWork.Users.GetAsync(x=>x.Id == userId);
            if (user != null)
            {
                return new DataResult<UserDto>(EResultStatus.Success,new UserDto { 
                    User = user,
                    ResultStatus= EResultStatus.Success
                }); 
            }

            return new DataResult<UserDto>(EResultStatus.Error, "Kullanıcı bulunamadı", new UserDto { 
                User = null,
                ResultStatus= EResultStatus.Error,
                Message = "Kullanıcı bulunamadı"
            });
        }

        public Task<IResult> HardDelete(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(UserDto userDto, string modifiedByUserUniqueId)
        {
            throw new NotImplementedException();
        }
    }
}
