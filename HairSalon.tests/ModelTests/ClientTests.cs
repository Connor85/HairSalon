using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{

    [TestClass]
    public class ClientTests : IDisposable
    {
        public void Dispose()
        {
            Client.DeleteAll();
        }
        public ClientTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=connor_mccarthy_test;";
        }

        [TestMethod]
       public void GetAll_ClientsEmptyAtFirst_0()
       {
         //Arrange, Act
         int result = Client.GetAll().Count;

         //Assert
         Assert.AreEqual(0, result);
       }
       [TestMethod]
public void Save_SavesToDatabase_Client()
{
    //Arrange
    Client testClient = new Client("Mow the lawn", "", 1);

    //Act
    testClient.Save();
    List<Client> result = Client.GetAll();
    List<Client> testList = new List<Client>{testClient};

    //Assert
    CollectionAssert.AreEqual(testList, result);
    }
    }
}
