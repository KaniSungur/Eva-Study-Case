using EvaExchangeApp.Core.Repositories;
using EvaExchangeApp.Data;
using EvaExchangeApp.Models;

namespace EvaExchangeApp.Core.Services
{
    public class StockService : IStockService
    {
        private readonly IUserRepository _userRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IWalletService _walletService;
        private readonly IWalletRepository _walletRepository;

        public StockService(IUserRepository userRepository, IStockRepository stockRepository, IWalletService walletService, IWalletRepository walletRepository)
        {
            _userRepository = userRepository;
            _stockRepository = stockRepository;
            _walletService = walletService;
            _walletRepository = walletRepository;
        }
        public void BuyStock(int userId, int companyId, int quantity)
        {
            try
            {
                var totalAmount = _userRepository.GetTotalAmount(userId);

                var stock = _stockRepository.GetStocksByStockId(companyId);

                var userName = _userRepository.GetUserNameById(userId);

                var quantityStock = stock.Quantity;

                var priceStock = stock.Price;

                var totalPrice = priceStock * quantity;

                if (totalAmount < totalPrice)
                {
                    throw new Exception("Your Balance Is Insufficient");
                }
                if (quantityStock < quantity)
                {
                    throw new Exception("The number of shares is less than what you entered");
                }

                _stockRepository.UpdateBuyStockQuantity(companyId, quantity);
                _userRepository.UpdateUserBalanceBuyStock(userId, totalPrice);
                _walletService.AddStocktoWallet(userId, userName, stock.CompanyName, companyId, quantity);
                _stockRepository.AddTransaction(userId, companyId, quantity, priceStock, ExchangeType.buy, DateTime.Now);
            }
            catch
            {
                throw new Exception("Operation Failed");
            }
            
        }
        public void SellStock(int userId, int companyId, int quantity)
        {
            try
            {
                var heldStock = _walletRepository.GetUserStockToWallet(userId, companyId);

                if (heldStock == null)
                {
                    throw new Exception("The specified stock was not found.");
                }

                if (heldStock.Quantity < quantity)
                {
                    throw new Exception("The amount of shares you hold is less than what you want to sell");
                }

                var userName = _userRepository.GetUserNameById(userId);

                var stock = _stockRepository.GetStocksByStockId(companyId);

                var priceStock = stock.Price;

                var totalPrice = priceStock * quantity;


                _stockRepository.UpdateSellStockQuantity(companyId, quantity);
                _userRepository.UpdateUserBalanceSellStock(userId, totalPrice);
                _walletService.DeleteStocktoWallet(userId, companyId, quantity);
                _stockRepository.AddTransaction(userId, companyId, quantity, priceStock, ExchangeType.sell, DateTime.Now);
            }
            catch
            {
                throw new Exception("Operation Failed");
            }
        }
    }

    
}

