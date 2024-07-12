using EvaExchangeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaExchangeApp.Data
{
    public class Transaction
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int StockId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public ExchangeType ExchangeType { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
