
using System;

namespace ecommerce.lib.people
{
    public class Man: Human
    {
        public Man(string firstName, string lastName, int birthYear): base(firstName, lastName, birthYear, "male"){}

        public override void GetId()
        {
            Console.WriteLine($"Firstname: {base._firstName} | age: {DateTime.Now.Year - base._birthYear} years old | gender: {base._sex}");
        }
    }
}