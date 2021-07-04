using System;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to Address book!");
            //calling operations class that contains operation
            Operations Operations = new Operations();

            //non-static method 
            Operations.ReadInput();
            Console.Read();

        }
    }
}

