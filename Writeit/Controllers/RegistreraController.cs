using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Writeit.Models;

namespace Writeit.Controllers
{
    public class RegistreraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Adduser(Anvandare nyAnvandare)
        {
            using (AnvandareContext database = new AnvandareContext())
            {
                database.anvandares.Add(nyAnvandare);
                database.SaveChanges();
            }
           

            return RedirectToAction("Index");
        }
    }
}
