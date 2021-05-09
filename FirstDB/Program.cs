using System;
using System.Linq;

namespace FirstDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (TestDBContext context = new TestDBContext())
            {
                var usersList = context.Users.ToList();
                foreach (var item in usersList)
                {
                    Console.WriteLine($"{item.Id}-{item.Name}-{item.Age}");
                }
            }
        }
    }
}
