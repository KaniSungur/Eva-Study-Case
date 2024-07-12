using EvaExchangeApp.Core.Repositories;
using EvaExchangeApp.Core.Services;
using EvaExchangeApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace EvaExchangeApp.Controllers
{
    [ApiController]
    [Route("api/stocks")]
    public class StockController : Controller
    {
        private readonly IStockRepository _stockRepository;
        private readonly IStockService _stockService;
        
        public StockController(IStockRepository stockRepository, IStockService stockService)
        {
            _stockRepository = stockRepository;
            _stockService = stockService;
        }
        [HttpGet("allStocks")]
        public IList<Stock> GetAllStocks()
        {
            var data = _stockRepository.GetAllStock().ToList();
            return data;
        }

        [HttpPost("buyStock")]
        public IActionResult BuyStock(int userId, int stockId, int quantity)
        {
            _stockService.BuyStock(userId, stockId, quantity);

            return Ok();
        }

        [HttpPost("SellStock")]
        public IActionResult SellStock(int userId, int stockId, int quantity)
        {
            _stockService.SellStock(userId, stockId, quantity);

            return Ok();
        }
    }
}
