
using System;
using System.Collections.Generic;

namespace ecommerce.lib.card
{
    public class Wallet
    {

        private List<CreditCard> _cards;
        private String _firstName;
        private String _lastName;

        public Wallet(String firstName, String lastName)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._cards = new List<CreditCard>();
        }

        public void GetNewCard(String cardType)
        {
            switch (cardType)
            {
                case "visa":
                    this._cards.Add(new Visa(this._firstName, this._lastName, 0.00));
                    break;
                case "master":
                    this._cards.Add(new Master(this._firstName, this._lastName, 0.00));
                    break;
                default:
                    this._cards.Add(new Visa(this._firstName, this._lastName, 0.00));
                    break;
            }
        }

        public void ShowAvailableCards()
        {
            int num = 0;
            foreach (CreditCard cd in this._cards)
            {
                Console.WriteLine($"{num}. {cd.GetFullInfo()} ");
                num++;
            }
        }
        

        private void ActionChoice(char userAction, double amount)
        {
            bool found = false;
            int chosenCard;
            
            Console.WriteLine($"{this._firstName}'s available _cards list");
            Console.WriteLine($"***************************************");
            ShowAvailableCards();
            

            if (this._cards.Count == 1)
            {
                if (userAction == 'D')
                {
                    _cards[0].Deposit(amount);
                }
                else if(userAction == 'P')
                {
                    _cards[0].Pay(amount);
                }
            } else if (_cards.Count <= 0)
            {
                Console.WriteLine("You don't have a credit card yet!");
            }
            else
            {
                Console.WriteLine("Please enter the id number of the card you want to use");
            
                chosenCard = Convert.ToInt32(Console.ReadLine());
            
                foreach (CreditCard cd in this._cards)
                {
                    if (chosenCard == cd.CardId)
                    {
                        if (userAction == 'D')
                        {
                            cd.Deposit(amount);
                        }
                        else if(userAction == 'P')
                        {
                            cd.Pay(amount);
                        }
                        else
                        {
                            Console.WriteLine($"No such option available");
                        }
                        found = true;
                        break;
                    }
                
                }

                if (!found)
                {
                    Console.WriteLine($"Card #{chosenCard} not found in your wallet! Please check your card info please");
                }
            }

        }

        public void Purchase(double amount)
        {
            try
            {
               // Console.WriteLine("How much money you wanna spend?");
                amount = Convert.ToDouble(Console.ReadLine());
                ActionChoice('P', amount);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
           
        }
        
        public void LoadMoney()
        {
            try
            {
                Console.WriteLine("How much money you wanna put today?");
                double amount = Convert.ToDouble(Console.ReadLine());
                ActionChoice('D', amount);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
            
        }
        
    }
}