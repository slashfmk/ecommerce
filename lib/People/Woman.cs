
using System;

namespace ecommerce.lib.people
{
    public class Woman: Human
    {
        public Woman(string firstName, string lastName, int birthYear): base(firstName, lastName, birthYear, "female"){}
        
        public override void GetId()
        {
            Console.WriteLine($"Firstname: {base._firstName} | age: {DateTime.Now.Year - base._birthYear} | gender: {base._sex}");
        }
    }
}