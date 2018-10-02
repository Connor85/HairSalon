// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using System.Collections.Generic;
// using System;
// using HairSalon.Models;
//
// namespace HairSalon.Tests
// {
//
//     [TestClass]
//     public class ClientTests : IDisposable
//     {
//         public void Dispose()
//         {
//             Client.DeleteAll();
//             Stylist.DeleteAll();
//         }
//         public ClientTests()
//         {
//             DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=connor_mccarthy_test;";
//         }
//
//         [TestMethod]
//         public void GetAll_ClientsEmptyAtFirst_0()
//         {
//             //Arrange, Act
//             int result = Client.GetAll().Count;
//
//             //Assert
//             Assert.AreEqual(0, result);
//         }
//
//         [TestMethod]
//         public void GetAll_DbStartsEmpty_0()
//         {
//             //Arrange
//             //Act
//             int result = Client.GetAll().Count;
//
//             //Assert
//             Assert.AreEqual(0, result);
//         }
//
//         [TestMethod]
//         public void Equals_ReturnsTrueIfDescriptionsAreTheSame_True()
//         {
//             // Arrange, Act
//             Client firstClient = new Client("Connor", 1);
//             Client secondClient = new Client("Connor", 1);
//
//             // Assert
//             Assert.AreEqual(firstClient, secondClient);
//         }
//
//         [TestMethod]
//         public void Save_SavesToDatabase_Client()
//         {
//             //Arrange
//             Stylist testStylist = new Stylist("chan", "");
//             testStylist.Save();
//             Client testClient = new Client("connor");
//             testClient.Save();
//             Stylist.AddClient(testClient);
//             List<Client> testlist = new List<Client>{testClient};
//
//             //Act
//             List<Stylist> result = testStylist.GetClients();
//
//             //Assert
//             CollectionAssert.AreEqual(testlist, result);
//         }
//
//         [TestMethod]
//         public void Find_FindsClientInDatabase_Client()
//         {
//             //Arrange
//             Client testClient = new Client("connor");
//             testClient.Save();
//
//             //Act
//             Client foundClient = Client.Find(testClient.GetId());
//
//             //Assert
//             Assert.AreEqual(testClient, foundClient);
//         }
//     }
// }
