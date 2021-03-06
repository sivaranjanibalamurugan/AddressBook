using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class AddressBookCompute
    {
        //private List<ContactDetails> contactList;
        private List<ContactDetails> stateList;
        private List<ContactDetails> cityList;
        bool AVAILABLE = false;
        //this method add details to the address book
        public void AddContactDetails(string firstName, string lastName, string address, string city, string state, long zipCode, long number, Dictionary<string, List<ContactDetails>> stateDic, Dictionary<string, List<ContactDetails>> cityDic, List<ContactDetails> contactList)
        {
            //find the data that already has the same value 
            ContactDetails details = contactList.Find(x => x.firstName.Equals(firstName));

            //if no sush record is available then add the data
            if (details == null)
            {
               
                contactList.Add(ContactDetails);
                if (!stateDic.ContainsKey(state))
                {

                    stateList = new List<ContactDetails>();
                    stateList.Add(ContactDetails);
                    stateDic.Add(state, stateList);
                }
                else
                {
                    List<ContactDetails> c = stateDic[state];
                    c.Add(ContactDetails);
                }
                if (!cityDic.ContainsKey(city))
                {

                    cityList = new List<ContactDetails>();
                    cityList.Add(ContactDetails);
                    cityDic.Add(city, cityList);
                }
                else
                {
                    List<ContactDetails> c = cityDic[city];
                    c.Add(ContactDetails);
                }
            }
            //else print record is already available
            else
            {
                Console.WriteLine("record with same name as {0} is available in the address book", firstName);
            }


        }

        //calls the display method
        public static void DisplayContact(List<ContactDetails> contactList)
        {
            foreach (ContactDetails contact in contactList)
            {
                contact.Display();
            }
        }
        //Delete the particular object
        public void DeleteContact(string name, List<ContactDetails> contactList)
        {
            try
            {
                contactList.Remove(contactList.Find(x => x.firstName.Equals(name)));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}'s record is not avaliable");
            }
        }

        public void EditContact(string name, long number, List<ContactDetails> contactList)
        {
            AVAILABLE = false;
            //checks for every object whether the name is equal the given name
            foreach (ContactDetails contact in contactList)
            {
                if (contact.firstName.Equals(name))
                {
                    //calls the setdetail method
                    contact.SetDetail(number);
                    AVAILABLE = true;
                    break;
                }
            }
            if (!AVAILABLE)
            {
                Console.WriteLine("{0} record not available in the address book", name);
            }

        }

        //method to find the record of persons in particular state or city
        public static void FindPerson(Dictionary<string, List<ContactDetails>> addressDictionary)
        {
            List<ContactDetails> list = null;
            string SCName;
            //get input from the user
            Console.WriteLine("Enter City or State name:");
            SCName = Console.ReadLine();
            foreach (var l in addressDictionary)
            {
                //in each address book
                //find all the record with particular state or city value and store it in the new list
                list = l.Value.FindAll(x => x.city.Equals(SCName) || x.state.Equals(SCName));
                if (list.Count > 0)
                {
                    //if list contatins value display the list
                    DisplayContact(list);
                }
            }

        }

        //method to find the number of item in th particular address book
        public static void CountOfPersons(Dictionary<string, List<ContactDetails>> Dic)
        {
            foreach (var l in Dic)
            {
                Console.WriteLine("Total number of person in {0} is: {1}", l.Key, l.Value.Count);
            }
        }
        //method to sort data in the list based on zipcode
        public static void SortData(Dictionary<string, List<ContactDetails>> Dic)
        {
            //store the result inthe list and display the result
            List<ContactDetails> list = new List<ContactDetails>();
            foreach (var d in Dic)
            {
                foreach (var i in d.Value)
                {
                    list.Add(i);
                }
            }
           
            Console.WriteLine("\nDisplaying the list based on zipcode");
            //display the sorted value based on city
            foreach (var i in list.OrderBy(detail => detail.zipCode))
            {
                i.Display();
            }
            
            Console.WriteLine("\nDisplaying the list based on state");
            //display the sorted value based on city
            foreach (var i in list.OrderBy(detail => detail.state))
            {
                i.Display();
            }
           
            Console.WriteLine("\nDisplaying the list based on city");
            //display the sorted value based on city
            foreach (var i in list.OrderBy(detail => detail.city))
            {
                i.Display();
            }

        }

        internal void AddContactDetails(Dictionary<string, List<ContactDetails>> stateRecord, Dictionary<string, List<ContactDetails>> cityRecord, List<ContactDetails> list, ContactDetails contactDetails, string firstName, string state, string city)
        {
            throw new NotImplementedException();
        }
    }
}
