namespace EvaExchangeApp.Core.Services
{
    public interface IStockService
    {
        void BuyStock(int userId, int companyId, int quantity);
        void SellStock(int userId, int companyId, int quantity);
    }
}
