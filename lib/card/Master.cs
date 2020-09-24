using System;

namespace ecommerce.lib.card
{

    public class Master : CreditCard
    {
        public Master(string firstName, string lastName, double balance) : base(firstName, lastName, "master", balance)
        {

        }

    }
}