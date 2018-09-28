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

        [HttpPost("/specialties")]
        public ActionResult Create(string SpecialtyName)
        {
            Specialty newSpecialty = new Specialty(SpecialtyName);
            newSpecialty.Save();
            List<Specialty> allSpecialtys = Specialty.GetAll();
            return View ("Index", allSpecialtys);
        }

        // [HttpGet("/specialties/{id}")]
        // public ActionResult Details(int id)
        // {
        //     Dictionary<string, object> model = new Dictionary<string, object>();
        //     Specialty selectedSpecialty = Specialty.Find(id);
        //     List<Stylist> stylistStylist = selectedStylist.GetName();
        //     model.Add("stylist", selectedStylist);
        //     model.Add("specialty", stylistSpecialty);
        //     return View(model);
        // }
    }
}
