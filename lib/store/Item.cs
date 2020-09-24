
using System;
namespace ecommerce.lib.store
{

    public class Item
    {
        private String _name;
        private double _price;

        public Item(String name, double price)
        {
            _name = name;
            _price = price;
        }

        public String GetName()
        {
            return _name;
        }

        public double GetPrice()
        {
            return _price;
        }

        public String GetInfos()
        {
            return $"{_name}: ${_price}";
        }
    }
    
}
