using EvaExchangeApp.Data;
using EvaExchangeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EvaExchangeApp.Core.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly EvaDbContext _context;

        public StockRepository(EvaDbContext context)
        {
            _context = context;
        }

        public IList<Stock> GetAllStock()
        {

            var allStock = _context.Stocks.ToList();
            return allStock;

        }

        public Stock GetStocksByStockId(int id) 
        {
            var stock = GetAllStock().FirstOrDefault(x => x.Id == id);
            return stock;
        }

        public void UpdateBuyStockQuantity(int id, int quantity)
        {
            var stock = _context.Stocks.Where(x => x.Id == id).SingleOrDefault();
            
            if(stock != null)
            {
                stock.Quantity = stock.Quantity - quantity;
                _context.Update(stock);
                _context.SaveChanges();
            }
            
        }

        public void UpdateSellStockQuantity(int id, int quantity)
        {
            var stock = _context.Stocks.Where(x => x.Id == id).SingleOrDefault();

            if (stock != null)
            {
                stock.Quantity = stock.Quantity + quantity;
                _context.Update(stock);
                _context.SaveChanges();
            }

        }

        public void AddTransaction(int userId, int stockId, int quantity, decimal price, ExchangeType exchangeType, DateTime date) 
        {
            Transaction transaction = new Transaction()
            {
                UserId = userId,
                StockId = stockId,
                Quantity = quantity,
                Price = price,
                ExchangeType = exchangeType,
                TransactionDate = DateTime.UtcNow
            };

            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }
    }
}
