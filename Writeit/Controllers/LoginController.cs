using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Security.Claims;
using Writeit.Models;

namespace Writeit.Controllers
{
    public class LoginController : Controller
    {
       
        public IActionResult Inde()
        {
            //var users = getUsers("sad","fsdf");
            
            /*if (anvandare.Usernamn == "admin" && anvandare.Password == "1234")
            {
                return View(anvandare);
            }
            else
            {
                Console.WriteLine("Fel användarnamn/lösenird");
                return View();
            }*/


            return View();
        }
       
        
        

       /* public void getUsers(string user, string pass)
        {
            using (AnvandareContext database = new AnvandareContext())
            {
                
                var users = database.anvandares.Where(p => p.Usernamn == "user" && p.Password=="pass");

                
            }
            
        }*/
        public IActionResult Index(string returnUrl = "")
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Anvandare user, string returnUrl = "")
        {
            //Kontrollera användarnamn
            bool userOk = CheckUserFromDB(user);
            if (userOk == true)
            {
                // Allt stämmer, logga in användaren
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Usernamn));
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));
                // Skicka användaren vidare till returnUrl om den finns annars till startsidan
                if (returnUrl != "")
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("SkyddadSida", "Home");
            }
            ViewBag.ErrorMessage = "Inloggningen inte godkänd";
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
       

        private bool CheckUserFromDB(Anvandare userInfo)
        {
            int count = 0;
            using (AnvandareContext database = new AnvandareContext())
            {
                var validUsers = database.anvandares.Where(u => u.Usernamn == userInfo.Usernamn).
                Where(u => u.Password == userInfo.Password);
                count = validUsers.Count();
            }
            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task<IActionResult> Loggaut()
        {
            await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }




}

