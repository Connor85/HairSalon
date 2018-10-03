using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{

    [TestClass]
    public class StylistTests : IDisposable
    {
        public void Dispose()
        {
            Stylist.DeleteAll();
            Client.DeleteAll();
            Specialty.DeleteAll();
        }
        public StylistTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=connor_mccarthy_test;";
        }

        [TestMethod]
        public void GetAll_StylistsEmptyAtFirst_0()
        {
            //Arrange, Act
            int result = Stylist.GetAll().Count;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Same_TwoStylistsAreTheSame_True()
        {
            Stylist firstStylist = new Stylist("connor"," ", 1);
            Stylist secondStylist = new Stylist("connor"," ", 1);
            Assert.AreEqual(firstStylist, secondStylist);

        }

        [TestMethod]
        public void Save_SaveToDatabase_True()
        {
            //Arrange
            Stylist firstStylist = new Stylist("connor"," ", 1);
            //Act
            firstStylist.Save();
            List<Stylist>testList =Stylist.GetAll();
            //Assert
            Assert.AreEqual(firstStylist, testList[0]);
        }

        [TestMethod]
        public void GetClients_GetsStylistsClients_True()
        {
            //Arrange
            Stylist firstStylist = new Stylist("connor", " ");
            firstStylist.Save();
            Client firstClient = new Client("Mitch", firstStylist.GetId());
            firstClient.Save();
            //Act
            List<Client> clientList = firstStylist.GetClients();
            List<Client> result = new List<Client> {firstClient};
            //Assert
            CollectionAssert.AreEqual(result, clientList);
        }

        [TestMethod]
        public void GetSpecialties_SameSpecialtys_True()
        {
            //Arrange
            Stylist firstStylist = new Stylist ("connor","",1);
            firstStylist.Save();
            Specialty specialty1 = new Specialty("specialty1");
            specialty1.Save();
            Specialty specialty2 = new Specialty("specialty2");
            specialty2.Save();

            //Act
            firstStylist.AddSpecialty(specialty1);
            firstStylist.AddSpecialty(specialty2);
            List <Specialty> result = new List<Specialty>{specialty1, specialty2};
            List <Specialty> test = firstStylist.GetSpecialties();

            //Assert
            CollectionAssert.AreEqual(result, test);
        }

        [TestMethod]
        public void Find_FindsStudentFromDatabase_True()
        {
            //Arrange
            Stylist firstStylist = new Stylist ("Connor", "", 1);
            firstStylist.Save();
            int id = firstStylist.GetId();

            //Act
            Stylist foundStylist = Stylist.Find(id);

            //Assert
            Assert.AreEqual(foundStylist, firstStylist);
        }

        [TestMethod]
        public void Delete_DeletsStylistFromDatabase_True()
        {
            //Arrange
            Stylist testStylist = new Stylist("connor"," ", 0);
            testStylist.Save();

            //Act
            testStylist.Delete();
            List<Stylist> deleted = Stylist.GetAll();

            //Arrange
            Assert.AreEqual(0, deleted.Count);
        }

        [TestMethod]
        public void Edit_UpdatesStylist_True()
        {
            //Arrange
            Stylist testStylist = new Stylist ("connor", "",1);
            testStylist.Save();

            //Act
            testStylist.Edit("Lisa");
            Stylist result = Stylist.Find(testStylist.GetId());

            //Assert
            Assert.AreEqual(testStylist,result);
        }

        [TestMethod]
        public void GetSpecialtys_GetStylistSpecialty_True()
        {
            //Arrange
            Stylist firstStylist = new Stylist ("connor", "",1);
            firstStylist.Save();
            Specialty specialty = new Specialty("short hair");
            specialty.Save();

            //Act
            firstStylist.AddSpecialty(specialty);
            List <Specialty> result = new List<Specialty>{specialty};
            List <Specialty> GetSpecialties = firstStylist.GetSpecialties();

            //Assert
            CollectionAssert.AreEqual(result, GetSpecialties);
        }

    }
}
