using ECommerceV2.Data.Abstract;
using ECommerceV2.Data.Concrete.EntityFramework.Contexts;
using ECommerceV2.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceV2.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceV2Context _context;
        private EfActionRepository _actionRepository;
        private EfCategoryRepository _categoryRepository;
        private EfCommissionRateRepository _commissionRateRepository;
        private EfReceivedMessageRepository _receivedMessageRepository;
        private EfSentMessageRepository _sentMessageRepository;
        private EfStockRepository _stockRepository;
        private EfUserFileRepository _userFileRepository;
        private EfStockFileRepository _stockFileRepository;
        private EfUserRepository _userRepository;
        private EfWishRepository _wishRepository;

        public UnitOfWork(ECommerceV2Context context)
        {
            _context = context;
        }

        public IActionRepository Actions => _actionRepository ?? new EfActionRepository(_context);

        public ICategoryRepository Categories => _categoryRepository ?? new EfCategoryRepository(_context);


        public ICommissionRateRepository CommissionRates => _commissionRateRepository ?? new EfCommissionRateRepository(_context);


        public IReceivedMessageRepository ReceivedMessages => _receivedMessageRepository ?? new EfReceivedMessageRepository(_context);


        public ISentMessageRepository SentMessages => _sentMessageRepository ?? new EfSentMessageRepository(_context);


        public IStockFileRepository StockFiles => _stockFileRepository ?? new EfStockFileRepository(_context);


        public IStockRepository Stocks => _stockRepository ?? new EfStockRepository(_context);


        public IUserFileRepository UserFiles => _userFileRepository ?? new EfUserFileRepository(_context);


        public IUserRepository Users => _userRepository ?? new EfUserRepository(_context);


        public IWishRepository Wishes => _wishRepository ?? new EfWishRepository(_context);


        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        { 
            await _context.DisposeAsync(); 
        }
    }
}
