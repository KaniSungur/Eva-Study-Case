﻿namespace EvaExchangeApp.Data
{
    public class Balance
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
