using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class Operations
    {
        Dictionary<string, AddressBookCompute> addressDictionary;

        //constructor that create the object for address book and store in dictionary
        public Operations()
        {
            addressDictionary = new Dictionary<string, AddressBookCompute>();
        }

        //read input from user
        public void ReadInput()
        {
            Operations operation = new Operations();
            //creating the object for the class address book 
            bool CONTINUE = true;
            string name;
            AddressBookCompute book;

            //the loop continues until the user exit the site
            while (CONTINUE)
            {
                //selecting the choice
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1.Add new address book");
                Console.WriteLine("2.Add contacts");
                Console.WriteLine("3.Display");
                Console.WriteLine("4.Edit Details");
                Console.WriteLine("5.Delete the contact");
                Console.WriteLine("6.Delete the address book");
                Console.WriteLine("7.Display the person by city or state");
                Console.WriteLine("8.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());

                //select choice
                switch (choice)
                {
                    case 1:
                        //creating the dictionary
                        Console.WriteLine("Enter address book name:");
                        string addBookName = Console.ReadLine();
                        AddressBookCompute addressBook1 = new AddressBookCompute();
                        this.addressDictionary.Add(addBookName, addressBook1);
                        break;


                    case 2:
                        try
                        {
                            //calling the AddDetails method
                            AddDetails(operation.BookName(addressDictionary));
                        }
                        catch (ArgumentNullException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case 3:
                        //display the details in particular dictionary
                        book = operation.BookName(addressDictionary);
                        if (book != null)
                        {
                            book.DisplayContact();
                        }
                        else
                        {
                            Console.WriteLine("No such book name is available");
                        }
                        break;

                    case 4:

                        try
                        {
                            book = operation.BookName(addressDictionary);
                            //gets input from the user such as name and number that has to be changed
                            Console.WriteLine("Enter the first name of person to edit number:");
                            name = Console.ReadLine();
                            Console.Write("Enter the new number:");
                            long number = Convert.ToInt64(Console.ReadLine());
                            //calling edit contact method
                            book.EditContact(name, number);
                        }
                        catch (NullReferenceException e)
                        {
                            Console.WriteLine("No dictionary available");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Enter valid input");
                        }
                        break;

                    case 5:
                        try
                        {
                            book = operation.BookName(addressDictionary);
                            //Deleting the user contact with first name
                            Console.WriteLine("Enter the name to delete contact:");
                            name = Console.ReadLine();
                            book.DeleteContact(name);
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Address book is not available");
                        }
                        break;

                    case 6:
                        //deleting the entire address book
                        Console.WriteLine("Enter address book name to delete:");
                        string Name = Console.ReadLine();
                        addressDictionary.Remove(Name);
                        break;

                    case 7:
                        AddressBookCompute.DisplayPerson(addressDictionary);                       
                        break;

                    case 8:
                        CONTINUE = false;
                        break;

                    default:
                        break;
                }
            }
        }

        //gets the user detail from the user
        public static void AddDetails(AddressBookCompute addressBookCompute)
        {
            try
            {
                Console.WriteLine("Enter first Name");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter Address");
                string address = Console.ReadLine();
                Console.WriteLine("Enter City");
                string city = Console.ReadLine();
                Console.WriteLine("Enter State");
                string state = Console.ReadLine();
                Console.WriteLine("Enter Zipcode");
                long zipCode = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter Phone Number");
                long phoneNumber = Convert.ToInt64(Console.ReadLine());
                //passing the details to add contact detail method
                addressBookCompute.AddContactDetails(firstName, lastName, address, city, state, zipCode, phoneNumber);
                
            }
            // exception when the object is null 
            catch (NullReferenceException aE)
            {
                Console.WriteLine("No Address book is available {0} ", aE.Message);
            }
            //catches when the user input the invalid data
            catch (FormatException )
            {
                Console.WriteLine("Detail entered is not in correct format");
            }
        }

       //method to find the address of particular address book 
        public AddressBookCompute BookName(Dictionary<string, AddressBookCompute> adBook)
        {
            //enter the name of address book
            Console.WriteLine("Enter address book name:");
            AddressBookCompute address;
            string Name = Console.ReadLine();
            //checks whether the adress book contains the record or not 
            try
            {
                address = adBook[Name];
                //return the address of particular  book
                return address;

            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return default;
            }

        }
    }
}



