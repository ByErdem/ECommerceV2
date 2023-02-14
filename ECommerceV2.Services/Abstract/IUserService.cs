using EcommerceV2.Entities.Dtos;
using ECommerceV2.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceV2.Services.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<UserDto>> GetAsync(int userId);
        Task<IDataResult<UserListDto>> GetAllAsync();
        Task<IDataResult<UserListDto>> GetAllByNonBlockedUsersAsync();
        Task<IDataResult<UserListDto>> GetAllByNonDeletedAsync();
        Task<IResult> AddAsync(UserDto userDto);
        Task<IResult> UpdateAsync(UserDto userDto);
        Task<IResult> DeleteAsync(int userId);
        Task<IResult> HardDelete(int userId);
        Task<IResult> CountAsync();

    }
}
