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
        public void Find_FindsStudentFromDatabase_True()
        {
            //Arrange
            Stylist firstStylist = new Stylist ("Connor", " ", 1);
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
    }
}
