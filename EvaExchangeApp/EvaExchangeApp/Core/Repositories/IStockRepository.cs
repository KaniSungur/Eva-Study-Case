using EvaExchangeApp.Data;
using EvaExchangeApp.Models;

namespace EvaExchangeApp.Core.Repositories
{
    public interface IStockRepository
    {
        IList<Stock> GetAllStock();

        Stock GetStocksByStockId(int id);

        void UpdateBuyStockQuantity(int id, int quantity);

        void UpdateSellStockQuantity(int id, int quantity);

        void AddTransaction(int userId, int stockId, int quantity, decimal price, ExchangeType exchangeType, DateTime date);
    }
}
