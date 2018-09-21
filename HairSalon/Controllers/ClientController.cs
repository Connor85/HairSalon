using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet("/stylists/{stylistId}/client/new")]
        public ActionResult CreateForm(int stylistId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Client stylist = Client.Find(stylistId);
            return View(stylist);
        }
    }
}
