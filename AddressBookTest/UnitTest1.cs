using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBook;
using System.Collections.Generic;
using System;

namespace AddressBookTest
{
    [TestClass]
    public class AddressBookTest
    {
        Operations operations;
        [TestInitialize]
        public void TestSetUp()
        {
            operations = new Operations();
        }
        //UC16-Retrive all data from database
        [TestMethod]
        public void RetrivingtheDataFromDataBaseTest()
        {
            int expected = 3;
            List<ContactDetails> list = operations.RetrivingDataFromDataBase();
            Assert.AreEqual(expected, list.Count);
        }
        //UC17-Update contact data from database
        [TestMethod]
        public void UpdateDataTest()
        {
            int expected = 1;
            int actual = operations.updateContact(3, "Stephan", 9845625362);
            Assert.AreEqual(expected, actual);
        }
        //UC18-Retrival based on date range
        [TestMethod]
        public void DateRangeRetrivalTest()
        {
            int expected = 2;
            DateTime startDate = new DateTime(2017, 01, 01);
            DateTime enddate = new DateTime(2019, 01, 01);
            List<ContactDetails> actual = operations.RetrivingDataBasedOnDate(startDate, enddate);
            Assert.AreEqual(expected, actual.Count);
        }
        //UC19-Retrive the data based on city or state
        [TestMethod]
        public void StateCityRetrivalTest()
        {
            int expected = 2;
            List<ContactDetails> actual = operations.RetrivingDataBasedOnStateCity("Tamil Nadu", "chennai");
            Assert.AreEqual(expected, actual.Count);
        }
        //UC20-Adding data to the address book
        [TestMethod]
        public void InsertIntoAddressBookTest()
        {
            int expected = 2;
            ContactDetails contactDetails = new ContactDetails { personId = 10, firstName = "siva", lastName = "bala", address = "mgr road", city = "madurai", state = "Tamil Nadu", zipCode = "896541", number = "9856234561", emailAddress = "siva@gmail.com", typeId = 2, addressBookId = 1, addedDate = "2020-06-30" };
            int actual = operations.AddDetailsToAddressBook(contactDetails);
            Assert.AreEqual(expected, actual);
        }
        //UC21 adding multiple data
        [TestMethod]
        public void AddingMultipleDataToAddtessBook()
        {
            int expected = 0;
            List<ContactDetails> contactList = new List<ContactDetails> { new ContactDetails { personId = 16, firstName = "sss", lastName = "hary", address = "mr road", city = "madurai", state = "Tamil Nadu", zipCode = "625009", number = "9630258741", emailAddress = "marcys@gmail.com", typeId = 2, addressBookId = 1, addedDate = "2021-07-28" } ,
                                                                         new ContactDetails { personId =15, firstName = "yyyy", lastName = "tom", address = "rs road", city = "madurai", state = "Tamil Nadu", zipCode = "625009", number = "9630258741", emailAddress = "marcys@gmail.com", typeId = 2, addressBookId = 1, addedDate = "2021-07-28" },
                                                                         new ContactDetails { personId =14, firstName = "vvvv", lastName = "jerry", address = "psk road", city = "madurai", state = "Tamil Nadu", zipCode = "625009", number = "9630258741", emailAddress = "marcys@gmail.com", typeId = 2, addressBookId = 1, addedDate = "2021-07-20" }};
            contactList = operations.AddMultiplecontactToDataBase(contactList);
            Assert.AreEqual(expected, contactList);
        }
    }
}
