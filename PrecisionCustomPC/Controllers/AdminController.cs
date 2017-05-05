using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PrecisionCustomPC.Models;
using PrecisionCustomPC.Models.PartsViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace PrecisionCustomPC.Controllers
{
    [Authorize(Policy = "RequireAdminRole")]
    public class AdminController : Controller
    {
        private readonly PartsDbContext _context;

        public AdminController(PartsDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Tower
        public IActionResult Towers()
        {
            var model = _context.Towers.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult TowerAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TowerAdd(Tower tower)
        {
            if (ModelState.IsValid)
            {
                _context.Towers.Add(tower);
                _context.SaveChanges();
                return RedirectToAction("Towers");
            }

            return View(tower);
        }
        public IActionResult TowerDetails(string modelNum)
        {
            var model = _context.Towers.FirstOrDefault(e => e.Model == modelNum);
            return View(model);
        }
        [HttpGet]
        public IActionResult TowerEdit(string modelNum)
        {
            var model = _context.Towers.FirstOrDefault(e => e.Model == modelNum);
            return View(model);
        }
        [HttpPost]
        public IActionResult TowerEdit(Tower tower)
        {
            if (ModelState.IsValid)
            {
                var model = _context.Entry(tower).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Towers");
            }

            return View(tower);
        }
        public IActionResult TowerDelete(string modelNum)
        {
            var original = _context.Towers.FirstOrDefault(e => e.Model == modelNum);
            if (original != null)
            {
                _context.Towers.Remove(original);
                _context.SaveChanges();
            }
            return RedirectToAction("Towers");
        }
        #endregion

        #region Motherboard
        public IActionResult Motherboards()
        {
            var model = _context.Motherboards.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult MotherboardAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MotherboardAdd(Motherboard motherboard)
        {
            if (ModelState.IsValid)
            {
                _context.Motherboards.Add(motherboard);
                _context.SaveChanges();
                return RedirectToAction("Motherboards");
            }

            return View(motherboard);
        }
        public IActionResult MotherboardDetails(string modelNum)
        {
            var model = _context.Motherboards.FirstOrDefault(e => e.Model == modelNum);
            return View(model);
        }
        [HttpGet]
        public IActionResult MotherboardEdit(string modelNum)
        {
            var model = _context.Motherboards.FirstOrDefault(e => e.Model == modelNum);
            return View(model);
        }
        [HttpPost]
        public IActionResult MotherboardEdit(Motherboard motherboard)
        {
            if (ModelState.IsValid)
            {
                var model = _context.Entry(motherboard).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Motherboards");
            }

            return View(motherboard);
        }
        public IActionResult MotherboardDelete(string modelNum)
        {
            var original = _context.Motherboards.FirstOrDefault(e => e.Model == modelNum);
            if (original != null)
            {
                _context.Motherboards.Remove(original);
                _context.SaveChanges();
            }
            return RedirectToAction("Motherboards");
        }
        #endregion
    }
}