using System;
using ecommerce.lib.store;
using ecommerce.lib.card;
using ecommerce.lib.people;

namespace ecommerce
{
    class Program
    {
        
        
        public static void Main(string[] args)
        {

            Title(); 
            
            Check check = new Check();
            
            Console.WriteLine(check.IssueDateTime);
            Console.WriteLine(check.ExpirationDate());
            
           
            Human man = new Man("Yannick", "Fumukani", 1987);
            
            Store store = new Store("Walmart", "Foods, pharmacy and other stuff");
            
            // Adding product in the store
            store.AddItem(new Item("Banana", 45.12));
            store.AddItem(new Item("Peanut Butter", 8.56));
            store.AddItem(new Item("shawarma", 15.00));
            
            Cart cart = new Cart();
            cart.AddItem(store.GetItem("Banana"), 8);
            cart.AddItem(store.GetItem("shawarma"), 5);
            
           // cart.Checkout()
           store.GetItemsList();

            Console.WriteLine("++++++++");
            
            
            try
            {
               // cart.RemoveItem(store.GetItem("Banana"), 8);
                cart.GetItemsList();
                Console.WriteLine($"Cart total: ${cart.GetCartTotal()}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Internal error: {e.Message}");
            }
            
            
            
            Console.WriteLine("++++++++ after ");
            
            cart.GetItemsList();
            Console.WriteLine($"Cart total: ${cart.GetCartTotal()}");

        }

        public static void Title()
        {
            Console.WriteLine($"Welcome to the ECommerce App by Yannick Fumukani");
            Console.WriteLine($"************************************************");
        }
    }
}