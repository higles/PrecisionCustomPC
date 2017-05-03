using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrecisionCustomPC.Models;
using Microsoft.AspNetCore.Identity;

namespace PrecisionCustomPC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.Name == null)
            {
                return RedirectToAction("Register", "Account");
            }
            return View();
        }
        
        public IActionResult Submit(AdminForm form)
        {
            if (ModelState.IsValid)
            {
                if (form.isValid(form.Username, form.Password))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect Username or Password");
                }
            }

            return View("Index", form);
        }
    }
}