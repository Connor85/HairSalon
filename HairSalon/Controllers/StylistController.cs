using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

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
        public ActionResult Create(string StylistName)
        {
            Stylist newStylist = new Stylist(StylistName);
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
    }
}
