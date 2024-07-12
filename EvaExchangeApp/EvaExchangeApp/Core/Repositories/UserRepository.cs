using EvaExchangeApp.Data;

namespace EvaExchangeApp.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EvaDbContext _context;

        public UserRepository(EvaDbContext context)
        {
            _context = context;
        }
        public IList<User> GetAllUser()
        {
            var allUser = _context.Users.ToList();
            return allUser;

        }

        public decimal GetTotalAmount(int id)
        {
            var userAmount = _context.Balances.Where(x => x.UserId == id).ToList();

            var totalAmount = userAmount[0].TotalAmount;

            return totalAmount;
        }

        public void UpdateUserBalanceBuyStock(int id, decimal totalPrice)
        {
            var balance = _context.Balances.Where(x => x.Id == id).SingleOrDefault();

            if (balance != null)
            {
                balance.TotalAmount -= totalPrice;
                _context.Update(balance);
                _context.SaveChanges();
            }
        }

        public void UpdateUserBalanceSellStock(int id, decimal totalPrice)
        {
            var balance = _context.Balances.Where(x => x.Id == id).SingleOrDefault();

            if (balance != null)
            {
                balance.TotalAmount += totalPrice;
                _context.Update(balance);
                _context.SaveChanges();
            }
        }

        public string GetUserNameById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                var userName = user.FirstName;
                return userName;
            }

            return null;
            
        }

        public List<User> GetAllUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

    }
}
