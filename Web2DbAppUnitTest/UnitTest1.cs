using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Web2DbApp.DataAccess;
using Web2DbApp.Entities;
using Web2DbApp.Services;

namespace Web2DbApp.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        MockDataProvider CSM = new MockDataProvider();
        Repository CDR = new Repository();

        [TestMethod]
        //Tests wether uppercase first letter is corrected
        public void TestMethod1()
        {
            //Arrange
            string first = "jens";
            string last = "petersen";
            string title = "mr";
            string expected = "Mr Jens Petersen";
            Person person;

            //act
            person = new Person(first, last, title);

            //assert
            string actual = person.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        //Tests wether digits are removed, and spaces are replased with dashes
        public void TestMethod2()
        {
            //Arrange
            string first = "jens1 peter";
            string last = "petersen7 buchme27ier";
            string title = "mr7";
            string expected = "Mr Jens-peter Petersen-buchmeier";
            Person person;

            //act
            person = new Person(first, last, title);

            //assert
            string actual = person.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        //Tests, wether empty fields is registered correctly in object (persons with empty fields are exempted from being written to database)
        public void TestMethod3()
        {
            //Arrange
            string first = "";
            string last = "";
            string title = "";
            string expected = "  ";
            Person person;

            //act
            person = new Person(first, last, title);

            //assert
            string actual = person.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        //Tests, that data is received in expected amount from API
        public void TestMethod4()
        {
            //Arrange
            int expected = 10;
            List<Person> persons;

            //act
            persons = CSM.GetPeople(10);

            //assert
            int actual = persons.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        //Tests, that data is received from database
        public void TestMethod5()
        {
            //Arrange
            bool expected = false;
            List<Person> persons;

            //act
            persons = CDR.GetAll();

            //assert
            bool actual = persons.Equals(null);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        //Tests, that rows is written to database
        public void TestMethod6()
        {
            //Arrange
            int expected = 2;
            List<Person> persons = new List<Person>();
            Person p = new Person("anders", "hansen", "mr");
            Person q = new Person("hans", "nielsen", "mr");
            persons.Add(p);
            persons.Add(q);

            //act
            CDR.SavePersons(persons);
            persons = CDR.GetAll();

            //assert
            int actual = persons.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
