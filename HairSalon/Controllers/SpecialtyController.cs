using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

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

        // [HttpGet("/specialties/{id}")]
        // public ActionResult Details(int id)
        // {
        //     Dictionary<string, object> model = new Dictionary<string, object>();
        //     Specialty selectedSpecialty = Specialty.Find(id);
        //     List<Stylist> stylistStylist = selectedStylist.GetName();
        //     model.Add("selectedStylistylist", selectedStylist);
        //     model.Add("stylist", stylistSpecialty);
        //     return View(model);
        // }
    }
}
