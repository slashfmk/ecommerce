using System;
using System.Collections.Generic;
using ecommerce.lib.store;

namespace ecommerce.lib.store
{
    public class Store
    {
        
        public String StoreName { get; set; }
        public String Description { get; set; }
        private List<Item> _productList;

        public Store(String storeName, String description)
        {
            StoreName = storeName;
            Description = description;
            _productList = new List<Item>();
        }

        public void AddItem(Item item)
        {
            this._productList.Add(item);
        }

        public int GetItemsNumber()
        {
            return _productList.Count;
        }

        public Item GetItem(String searchedItem)
        {
            Item itemFound = null;
            foreach (Item i in _productList)
            {
                if (i.GetName() == searchedItem)
                {
                    itemFound = i;
                    break;
                }
                
            }

            return itemFound;
        }

        public void GetItemsList()
        {
            Console.WriteLine($"There are {GetItemsNumber()} items in the store");
            Console.WriteLine($"-------------------------------");
            if (_productList.Count > 0)
            {
                foreach (Item item in _productList)
                {
                    Console.WriteLine(item.GetInfos());
                }
            }
            else
            {
                Console.WriteLine($"The store is empty! Sorry!");
            }
           
        }
    }
}