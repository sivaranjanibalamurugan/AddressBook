using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class AddressBookCompute
    {
        private LinkedList<ContactDetails> contactList;
        bool AVAILABLE = false;

        //creates the object linked list 
        public AddressBookCompute()
        {
            this.contactList = new LinkedList<ContactDetails>();
        }

        //this method add details to the address book
        public void AddContactDetails(string firstName, string lastName, string address, string city, string state, long zipCode, long phoneNumber)
        {
            ContactDetails contactDetails = new ContactDetails(firstName, lastName, address, city, state, zipCode, phoneNumber);
            this.contactList.AddLast(contactDetails);
        }

        // the display method
        public void DisplayContact()
        {
            foreach (ContactDetails contact in this.contactList)
            {
                contact.Display();
            }
        }


        //Delete the particular object
        public void DeleteContact(string name)
        {
            AVAILABLE = false;
            foreach (ContactDetails contact in this.contactList)
            {
                if (contact.firstName.Equals(name))
                {
                    this.contactList.Remove(contact);
                    break;
                }
            }
            if (!AVAILABLE)
            {
                Console.WriteLine("{0} such records arenot available in this address book", name);
            }
        }

        public void EditContact(string name, long number)
        {
            AVAILABLE = false;
            //checks for every object whether the name is equal to  the given name
            foreach (ContactDetails contact in this.contactList)
            {
                if (contact.firstName.Equals(name))
                {
                    //calls the setdetail method
                    contact.SetDetail(number);
                }
            }
            if (!AVAILABLE)
            {
                Console.WriteLine("{0} such records arenot available in this address book", name);
            }

        }


    }

}




