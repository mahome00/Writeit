using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Writeit.Models;

namespace Writeit.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult SkyddadSida()
        {
            //Visar böcker 

            using (AnvandareContext database = new AnvandareContext())
            {
                var bocker = database.bockers.ToList();
                return View(bocker);
            }

            
        }

        [Authorize]
        public IActionResult LaggTillBok()

        {


            return View();

        }
        [HttpPost]
        public IActionResult LaggTillEnBok(Bocker nybok)

        {
           //Lägg till en ny bok
            using (AnvandareContext database = new AnvandareContext())
            {
                database.bockers.Add(nybok);
                database.SaveChanges();
            }
            //Gå till sidan som visar listan över böcker

            return RedirectToAction("SkyddadSida");
        }

            

        
    }
}
