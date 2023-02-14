using EcommerceV2.Entities.Concrete;
using ECommerceV2.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceV2.Services.Abstract
{
    public interface ICommissionRateService
    {
        Task<IDataResult<int>> GetCommissionRatesByUserIdAsync(int userId);
        Task<IDataResult<int>> GetAllCommissionRatesByUserIdAsync(int userId);
        Task<IResult> AddAsync(MCommissionRate commissionRate,string createdByName);
        Task<IResult> UpdateAsync(MCommissionRate commissionRate, string modifiedByName);
        Task<IResult> DeleteAsync(int Id);
        Task<IResult> HardDeleteAsync(int Id);
    }
}
