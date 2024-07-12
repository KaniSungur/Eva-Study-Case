using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchangeApp.Data
{
    public class Wallet
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int CompanyId { get; set; }

        public string? UserName { get; set; }

        public string? Company { get; set; }

        public int Quantity { get; set; }
    }
}
