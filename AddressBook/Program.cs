using System;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to address book program!");
 
                //calling operation management class that contains operation
                
                Operations.AddDetails();
                Console.Read();
            
        }
    }
}

