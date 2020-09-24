using System;

namespace ecommerce.lib.card
{

    public class Visa : CreditCard
    {

        public Visa(string firstName, string lastName, double balance) : base(firstName, lastName, "visa", balance)
        {

        }

    }

}