using System;

namespace ecommerce.lib.card
{
    
    public abstract class CreditCard: IPayable
    {

        public int CardId { get; set; }
        public string Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }
        public int Pin { get; set; }
        public int PurchaseCount { get; set; }


        protected CreditCard(string firstName, string lastName, string type, double balance)
        {
            var random = new Random();
            this.CardId = random.Next();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Balance = balance;
            this.Type = type;
            this.Pin = 0000;
            this.PurchaseCount = 0;
        }

        public void Pay(double amount)
        {
            int userPin;
            
            Console.WriteLine($"Please enter your card PIN first!");
            userPin = Convert.ToInt32(Console.ReadLine());

            if (this.Pin != userPin)
            {
                Console.WriteLine($"Your pin is incorrect, try again later!");
            }
            else
            {
                
                if (this.Balance - amount <= 0)
                {
                    Console.WriteLine($"You can't make this purchase, you don't have enough money");
                    Console.WriteLine($"You need ${amount - this.Balance} more");
                }
                else
                {
                    this.Balance -= amount;
                    this.PurchaseCount++;
                    this.NewBalanceInfos();
                }
            }

        }

        public void SetPin()
        {
            int userCurrentPin, newPin, newPinConfirm;
            
            Console.WriteLine("Please enter your current pin code");
            userCurrentPin = Convert.ToInt32(Console.ReadLine());

            if (userCurrentPin != this.Pin)
            {
                Console.WriteLine($"The pin entered is wrong");
            }
            else
            {
                Console.WriteLine($"Enter your new Pin code");
                newPin = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Please confirm your new Pin code");
                newPinConfirm = Convert.ToInt32(Console.ReadLine());

                if (newPin.Equals(newPinConfirm))
                {
                    if (newPin.ToString().Length != 4)
                    {
                        Console.WriteLine($"A new Pin must have 4 digits, you entered {newPin.ToString().Length} digits instead!");
                    }
                    else
                    {
                        this.Pin = newPin;
                        Console.WriteLine($"Pin successfully updated!");
                    }
                   
                }
                else
                {
                    Console.WriteLine($"Your new Pins don't match each other! Operation failed!");
                }
            }

        }

        protected void NewBalanceInfos()
        {
            Console.WriteLine($"Your new balance for {this.Type} #{this.CardId} is ${this.Balance}");
            Console.WriteLine("");
        }

        public void Deposit(double amount)
        {
            this.Balance += amount;
            this.NewBalanceInfos();
        }

        public double GetBalance()
        {
            return this.Balance;
        }

        public string GetFullInfo()
        {
            return $" Owner: {this.FirstName} {this.LastName} | Balance: ${this.Balance} | Type: {this.Type} | card #: {this.CardId} | usage: {this.PurchaseCount}";
        }


    }

}