using EvaExchangeApp.Data;

namespace EvaExchangeApp.Core.Repositories
{
    public interface IUserRepository
    {
        decimal GetTotalAmount(int id);

        void UpdateUserBalanceBuyStock(int id, decimal totalPrice);

        void UpdateUserBalanceSellStock(int id, decimal totalPrice);

        string GetUserNameById(int id);

        List<User> GetAllUsers();
    }
}
