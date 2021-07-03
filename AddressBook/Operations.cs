using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class Operations
    {
        public static void ReadInput()
        {
            AddressBookCompute AddressBookCompute = new AddressBookCompute();
            AddressBookCompute.AddContactDetails("Siva", "Ranjani", "Nattukkal raja street","Rajapalayam", "Tamil Nadu",626117, 866736142);
            AddressBookCompute.AddContactDetails("Rathna ", "Priyanga ", "Jeyalani street", "toothukodi", "Tamil Nadu", 625462, 9659048416);
            AddressBookCompute.DisplayContact();
        }
    }
}
    

