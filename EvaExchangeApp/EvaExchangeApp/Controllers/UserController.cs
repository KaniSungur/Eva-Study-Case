using EvaExchangeApp.Core.Repositories;
using EvaExchangeApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace EvaExchangeApp.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("allUser")]
        public List<User> GetAllUsers()
        {

            return _userRepository.GetAllUsers();
        }
    }
}
