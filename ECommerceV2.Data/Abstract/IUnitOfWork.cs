using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceV2.Data.Abstract
{
    public interface IUnitOfWork
    {
        IActionRepository Actions { get; }
        ICategoryRepository Categories { get; }
        ICommissionRateRepository CommissionRates { get; }
        IReceivedMessageRepository ReceivedMessages { get; }
        ISentMessageRepository SentMessages { get; }
        IStockFileRepository StockFiles { get; }
        IUserFileRepository UserFiles { get; }
        IWishRepository WishRepository { get; }
        Task<int> SaveAsync();
    }
}
