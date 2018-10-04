using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientControllerTest
  {

    [TestMethod]
    public void AllClients_ReturnsCorrectView_True()
    {
      //Arrange
      ClientController controller = new ClientController();

      //Act
      ActionResult indexView = controller.AllClients();

      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void CreateForm_ReturnsCorrectView_True()
    {
      //Arrange
      ClientController controller = new ClientController();

      //Act
      ActionResult indexView = controller.CreateForm(1);

      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void Details_ReturnsCorrectView_True()
    {
      //Arrange
      ClientController controller = new ClientController();
      Client testClient = new Client("connor");

      //Act
      ActionResult indexView = controller.Details(testClient.GetId());

      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void UpdateForm_ReturnsCorrectView_True()
    {
      //Arrange
      ClientController controller = new ClientController();

      //Act
      ActionResult indexView = controller.UpdateForm(100);

      //Assert
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

  }
}
