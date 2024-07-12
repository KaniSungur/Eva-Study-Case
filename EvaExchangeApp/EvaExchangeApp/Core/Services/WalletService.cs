using EvaExchangeApp.Core.Repositories;
using EvaExchangeApp.Core.Services;
using EvaExchangeApp.Data;
using Microsoft.EntityFrameworkCore;

namespace EvaExchangeApp.Core.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }
        public void AddStocktoWallet(int id, string name, string companyName, int companyId, int quantity)
        {
            var isHaveStock = _walletRepository.IsHasStock(companyId);

            if (isHaveStock == true)
            {
                _walletRepository.UpdateWalletStockQuantityUsersBuy(id, companyId, quantity);
            }
            Wallet wallet = new Wallet();
            {
                wallet.UserId = id;
                wallet.CompanyId = companyId;
                wallet.UserName = name;
                wallet.Company = companyName;
                wallet.Quantity = quantity;
            }

            _walletRepository.AddStockinWallet(wallet);
        }

        public void DeleteStocktoWallet(int id, int companyId, int quantity)
        {
            var walletStock = _walletRepository.GetWallet(id);
            var stock = walletStock.Where(x => x.CompanyId == x.CompanyId).FirstOrDefault();
            
            if (stock.Quantity == quantity)
            {
                _walletRepository.DeleteStockToWallet(id, companyId);
            }
            else
            {
                _walletRepository.UpdateWalletStockQuantityUsersSell(id, companyId, quantity);
            }

        }
    }
}
