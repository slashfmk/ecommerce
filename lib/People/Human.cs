
using System;
using ecommerce.lib.card;
using ecommerce.lib.store;

namespace ecommerce.lib.people
{
    public abstract class Human
    {

        protected String _firstName;
        protected String _lastName;
        protected int _birthYear;
        protected String _sex;
        protected Wallet _wallet;

        public enum CardType
        {
            visa,
            master
        }

        public Human(String firstName, String lastName, int birthYear, String sex)
        {
            _firstName = firstName;
            _lastName = lastName;
            _birthYear = birthYear;
            _sex = sex;
            _wallet = new Wallet(firstName, lastName);
        }

        public void GetNewCard(String cardTypeChoice)
        {
            if (CardType.master.ToString().Equals(cardTypeChoice) || CardType.visa.ToString().Equals(cardTypeChoice))
            {
                _wallet.GetNewCard(cardTypeChoice);
            }
            else
            {
                Console.WriteLine($"we don't issue {cardTypeChoice} card, available credit cards are: visa and master");
            }
            
        }

        public void MyCards()
        {
            _wallet.ShowAvailableCards();
        }

        public void Purchase(double amount)
        {
            _wallet.Purchase(amount);
        }

        public void Deposit()
        {
            _wallet.LoadMoney();
        }

        public abstract void GetId();
        
    }
}