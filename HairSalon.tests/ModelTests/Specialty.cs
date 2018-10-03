using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{

    [TestClass]
    public class SpecialtyTests : IDisposable
    {
        public void Dispose()
        {
            Client.DeleteAll();
            Stylist.DeleteAll();
            Specialty.DeleteAll();
        }
        public SpecialtyTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=connor_mccarthy_test;";
        }

        [TestMethod]
        public void GetAll_SpecialtysEmptyAtFirst_0()
        {
            //Arrange, Act
            int result = Specialty.GetAll().Count;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetAll_DbStartsEmpty_0()
        {
            //Arrange
            //Act
            int result = Specialty.GetAll().Count;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfDescriptionsAreTheSame_True()
        {
            // Arrange, Act
            Specialty firstSpecialty = new Specialty("Connor");
            Specialty secondSpecialty = new Specialty("Connor");

            // Assert
            Assert.AreEqual(firstSpecialty, secondSpecialty);
        }

        [TestMethod]
        public void Find_FindsSpecialtyInDatabase_Specialty()
        {
            //Arrange
            Specialty testSpecialty = new Specialty("connor");
            testSpecialty.Save();

            //Act
            Specialty foundSpecialty = Specialty.Find(testSpecialty.GetId());

            //Assert
            Assert.AreEqual(testSpecialty, foundSpecialty);
        }

        // [TestMethod]
        // public void Getstylists_GetsStylistsstylists_True()
        // {
        //     //Arrange
        //     Stylist firstStylist = new Stylist("connor", " ", 1);
        //     firstStylist.Save();
        //     Specialty firstSpecialty = new Specialty("long hair");
        //     firstSpecialty.Save();
        //     //Act
        //     List<Specialty> specialtyList = firstStylist.GetStylists();
        //     List<Specialty> result = new List<Specialty> {specialtyList};
        //     //Assert
        //     Assert.AreEqual(result, specialtyList);
        // }
    }
}
