using EvaExchangeApp.Data;
using Microsoft.EntityFrameworkCore;

namespace EvaExchangeApp.Core.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly EvaDbContext _context;

        public WalletRepository(EvaDbContext context)
        {
            _context = context;
        }
        public List<Wallet> GetWallet(int id) 
        {
            var usersWallet = _context.Wallets.Where( x => x.UserId == id).ToList();
            return usersWallet;
        }
            
        public void AddStockinWallet(Wallet wallet)
        {
            _context.Wallets.Add(wallet);
            _context.SaveChanges();
        }

        public bool IsHasStock(int id)
        {
            var stock = _context.Wallets.FirstOrDefault(x => x.CompanyId == id);
            if (stock != null)
            {
                return true;
            }
            return false;
        }

        public void UpdateWalletStockQuantityUsersBuy(int userId, int companyId, int quantity)
        {
            var userStock = _context.Wallets.FirstOrDefault(x => x.UserId == userId && x.CompanyId == companyId);
            
            userStock.Quantity += quantity;
            _context.Update(userStock);
            _context.SaveChanges();

        }

        public Wallet? GetUserStockToWallet(int userId, int companyId)
        {
            var userStock = _context.Wallets.FirstOrDefault(x => x.UserId == userId && x.CompanyId == companyId);
            if(userStock != null)
            {
                return userStock;
            }
            return null;
        }

        public void DeleteStockToWallet(int userId, int companyId)
        {
            var userStock = _context.Wallets.FirstOrDefault(x => x.UserId == userId && x.CompanyId == companyId);

            _context.Remove(userStock);
            _context.SaveChanges();

        }

        public void UpdateWalletStockQuantityUsersSell(int userId, int companyId, int quantity)
        {
            var userStock = _context.Wallets.FirstOrDefault(x => x.UserId == userId && x.CompanyId == companyId);

            userStock.Quantity -= quantity;
            _context.Update(userStock);
            _context.SaveChanges();

        }


    }
}
