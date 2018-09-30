using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class SpecialtyController : Controller
    {
        [HttpGet("/specialties")]
        public ActionResult Index()
        {
            List<Specialty> allSpecialtys = Specialty.GetAll();
            return View(allSpecialtys);
        }

        [HttpGet("/specialties/new")]
        public ActionResult CreateForm()
        {
            return View();
        }

        [HttpPost("/specialties/details")]
        public ActionResult Create()
        {
            Specialty newSpecialty = new Specialty(Request.Form["SpecialtyName"]);
            newSpecialty.Save();
            return RedirectToAction("Index");
        }

        [HttpGet("/specialties/{specialytIdid}")]
        public ActionResult Details(int specialytId)
        {
          Dictionary<string, object> model = new Dictionary <string, object>();
          Specialty selectedSpecialty = Specialty.Find(specialytId);
          List<Stylist> specialtyStylists = selectedSpecialty.GetStylists();
          List<Stylist> allStylists = Stylist.GetAll();
          model.Add("selectedSpecialty", selectedSpecialty);
          model.Add("specialtyStylists", specialtyStylists);
          model.Add("allStylists", allStylists);
          return View(model);
        }

        [HttpPost("/specialties/{stylistId}/stylists/new")]
        public ActionResult AddStylist(int stylistId, int specialtyId)
        {
          Specialty foundSpecialty = Specialty.Find(specialtyId);
          Stylist foundStylist = Stylist.Find(stylistId);
          foundSpecialty.AddStylist(foundStylist);
          return RedirectToAction("Index");
        }
    }
}
