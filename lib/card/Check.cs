using System;
using System.Globalization;

namespace ecommerce.lib.card
{
    public class Check : IPayable
    {
        public double Balance { set; get; }
        public DateTime IssueDateTime { set; get; }
        public DateTime ExpDate { set; get; }

        public Check()
        {
            Balance = 1000;
            IssueDateTime = DateTime.Now;
            ExpDate = IssueDateTime.AddDays(15.00);
        }

        public double GetBalance()
        {
            return Balance;
        }

        public void Pay(double amount)
        {
            if (Balance - amount <= 0)
            {
                Console.WriteLine("This check has not enough money!");
            }
            else
            {
                Balance -= amount;
            }
        }
        
        
        public String ExpirationDate()
        {
            return ExpDate.ToString(CultureInfo.InvariantCulture);
        }
    }
}