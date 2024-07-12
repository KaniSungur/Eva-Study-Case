using Microsoft.EntityFrameworkCore;

namespace EvaExchangeApp.Data
{
    public class EvaDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public EvaDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string deneme = "Host=localhost; Database=eva_stock_db; UserId=postgres; Password=123456; Port=5432";
            options.UseNpgsql(deneme);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Wallet> Wallets { get; set; }

        public DbSet<Balance> Balances { get; set; }
    }
}
