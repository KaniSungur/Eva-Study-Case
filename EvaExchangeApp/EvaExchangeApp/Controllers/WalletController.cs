using EvaExchangeApp.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EvaExchangeApp.Controllers
{
    [ApiController]
    [Route("api/wallets")]
    public class WalletController : Controller
    {
        private readonly IWalletRepository   _walletRepository;

        public WalletController(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        [HttpGet("GetUserWallet")]
        public IActionResult GetUserWallet(int id)
        {
            var userwallet = _walletRepository.GetWallet(id);

            return Ok(userwallet);
        }
    }
}
