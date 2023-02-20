using EcommerceV2.Entities.Dtos;
using ECommerceV2.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceV2.Services.Abstract
{
    public interface IActionService
    {
        Task<IDataResult<ActionDto>> GetAsync(int actionId);
        Task<IDataResult<ActionListDto>> GetAllAsync();
        Task<IDataResult<ActionListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<ActionListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IDataResult<ActionListDto>> GetAllByCategoryAsync(int categoryId);
        Task<IResult> AddAsync(ActionDto actionDto, string CreatedByUserUniqueId);
        Task<IResult> UpdateAsync(ActionDto actionDto, string ModifiedByUserUniqueId);
        Task<IResult> DeleteAsync(int actionId, string ModifiedByUserUniqueId);
        Task<IResult> HardDeleteAsync(int actionId);
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
    }
}
