namespace EvaExchangeApp.Core.Services
{
    public interface IWalletService
    {
        void AddStocktoWallet(int id, string name, string companyName, int companyId, int quantity);

        void DeleteStocktoWallet(int id, int companyId, int quantity);
    }
}
