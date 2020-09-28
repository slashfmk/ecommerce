using System;
using ecommerce.lib.card;
using System.Collections.Generic;

namespace ecommerce.lib.store
{
    public class Cart
    {

        private List<ItemAndQte> _itemsList;

        // struct for Item and Quantity
        private struct ItemAndQte
        {
            public  Item Item { get; set; }
            public  int Qte { get; set; }
            
            public ItemAndQte(Item itm, int qte)
            {
                Item = itm;
                Qte = qte;
            }

            public Item GetItem()
            {
                return Item;
            }

            public double GetQte()
            {
                return Qte;
            }

            public String GetItemAndQte()
            {
                return $"{Item.GetName()}: ${Item.GetPrice()} x {Qte} | ${GetTotal()}";
            }

            public double GetTotal()
            {
                return Item.GetPrice() * Qte;
            }
        }
        

        public Cart()
        {
            _itemsList = new List<ItemAndQte>();
        }

        public void AddItem(Item item, int qte)
        {
            _itemsList.Add(new ItemAndQte(item, qte));
        }

        public void GetItemsList()
        {
            foreach (ItemAndQte item in _itemsList)
            {
                Console.WriteLine($"{item.GetItemAndQte()}");
            }
        }
        
        public double GetCartTotal()
        {
            double total = 0;
            foreach (ItemAndQte item in _itemsList)
            {
                total += item.GetTotal();
            }

            return total;
        }

        public void RemoveItem(Item item, int qte)
        {
            //  int i = _itemsList.FindIndex(item);
            bool found = false;
            
                foreach (ItemAndQte itemToRemove in _itemsList)
                {
                    if (itemToRemove.GetItem() == item)
                    {
                        _itemsList.Remove(new ItemAndQte(item, qte));
                        found = true;
                        break;
                    }
                }


                if(!found){Console.WriteLine($"There's no {item.GetName()} in the chart!");}
        }

        public void Checkout(IPayable ipayable)
        {
            ipayable.Pay(GetCartTotal());
        }
    }
    
    
}