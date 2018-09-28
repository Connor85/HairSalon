using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {
        [HttpGet("/stylists")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAll();
            return View(allStylists);
        }

        [HttpGet("/stylists/new")]
        public ActionResult CreateForm()
        {
            return View();
        }

        [HttpPost("/stylists")]
        public ActionResult Create(string StylistName, string hireDate)
        {
            Stylist newStylist = new Stylist(StylistName, hireDate);
            newStylist.Save();
            List<Stylist> allStylists = Stylist.GetAll();
            return View ("Index", allStylists);
        }

        [HttpGet("/stylist/{id}")]
        public ActionResult Details(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist selectedStylist = Stylist.Find(id);
            List<Client> stylistClient = selectedStylist.GetClients();
            model.Add("stylist", selectedStylist);
            model.Add("client", stylistClient);
            return View(model);
        }

        [HttpPost("/client")]
        public ActionResult CreateClient(string stylist_id, string clientName)
        {
            int stylistId = int.Parse(stylist_id);
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist foundStylist = Stylist.Find(stylistId);
            Client newClient = new Client(clientName, stylistId);
            newClient.Save();
            List<Client> stylistClient = foundStylist.GetClients();
            model.Add("client", stylistClient);
            model.Add("stylist", foundStylist);
            return View("Details", model);
        }
        [HttpGet("/stylists/{id}/specialties/new")]
        public ActionResult CreateStylistForm()
        {
            return View("~/Views/Stylist/CreateForm.cshtml");
        }

        [HttpPost("/stylists/{stylistId}/specialties/new")]
        public ActionResult AddClient(int stylistId)
        {
            Stylist stylist = Stylist.Find(stylistId);
            Client client = Client.Find(Int32.Parse(Request.Form["client-id"]));
            client.AddClient(client);
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/{stylistId}/delete")]
        public ActionResult DeleteStylist(int stylistId)
        {
            Stylist newStylist = Stylist.Find(stylistId);
            newStylist.Delete();
            return RedirectToAction("Index");
        }
    }
}
