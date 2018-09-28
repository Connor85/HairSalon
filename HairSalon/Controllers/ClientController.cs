using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet("/clients/all")]
        public ActionResult AllClients()
        {
            List<Client> allClients = Client.GetAll();
            return View(allClients);

        }

        [HttpGet("/stylists/{id}/client/new")]
        public ActionResult CreateForm(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist stylist = Stylist.Find(id);
            return View(stylist);
        }

        [HttpGet("/stylists/{stylistId}/clients/{clientId}")]
        public ActionResult Details(int stylistId, int clientId)
        {
            Client client = Client.Find(clientId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist stylist = Stylist.Find(stylistId);
            model.Add("client", client);
            model.Add("stylist", stylist);
            return View(model);
        }
        [HttpPost("/clients/new")]
        public ActionResult Create(string name, int stylistId)
        {
            Client newClient = new Client(name, stylistId);
            newClient.Save();
            return RedirectToAction("Index", new {controller="Stylist"});
        }

        [HttpGet("/stylists/{stylistId}/{clientId}/delete")]
        public ActionResult DeleteClient(int clientId)
        {
            Client newClient = Client.Find(clientId);
            newClient.Delete();
            return RedirectToAction("Details");
        }

        [HttpGet ("/clients/delete/all")]
        public ActionResult DeleteAll () {
            Client.DeleteAll ();
            return Redirect ("/");
        }
    }
}
