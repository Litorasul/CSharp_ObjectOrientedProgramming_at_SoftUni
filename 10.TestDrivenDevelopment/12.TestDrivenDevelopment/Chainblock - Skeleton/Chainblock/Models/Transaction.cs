using System;
using System.Collections.Generic;
using System.Text;
using Chainblock.Contracts;

namespace Chainblock.Models
{
    public class Transaction : ITransaction
    {
        private double amount;

        public Transaction(int id, string from, string to, double amount, string status)
        {
            this.Id = id;
            this.From = from;
            this.To = to;
            this.Amount = amount;
            this.Status = (TransactionStatus) Enum.Parse(typeof(TransactionStatus), status);
        }

        public int Id { get; set; }
        public TransactionStatus Status { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public double Amount
        {
            get => amount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Transaction amount can not be negative");
                }
                amount = value;
            }
        }

        public int CompareTo(ITransaction other)
        {
            if (this.amount > other.Amount)
            {
                return 1;
            }

            if (this.amount == other.Amount)
            {
                return 0;
            }

            return -1;
        }
    }
}
