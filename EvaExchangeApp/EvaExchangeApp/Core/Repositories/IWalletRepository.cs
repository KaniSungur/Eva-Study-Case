using EvaExchangeApp.Data;

namespace EvaExchangeApp.Core.Repositories
{
    public interface IWalletRepository
    {
        List<Wallet> GetWallet(int id);
        void AddStockinWallet(Wallet wallet);
        void UpdateWalletStockQuantityUsersBuy(int userId, int companyId, int quantity);
        bool IsHasStock(int id);
        Wallet? GetUserStockToWallet(int userId, int companyId);
        void DeleteStockToWallet(int userId, int companyId);
        void UpdateWalletStockQuantityUsersSell(int userId, int companyId, int quantity);
    }
}
