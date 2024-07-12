using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchangeApp.Data
{
    public class Stock
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; }

        public decimal Price { get; set; }
    }
}
