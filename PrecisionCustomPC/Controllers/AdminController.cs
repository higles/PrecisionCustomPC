using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PrecisionCustomPC.Models;
using PrecisionCustomPC.Models.PartsViewModels;
using PMV = PrecisionCustomPC.Models.PartsViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Text.RegularExpressions;

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
        [Route("Tower/{id}/{mdl}/Details")]
        public IActionResult TowerDetails(int id, string mdl)
        {
            var model = _context.Towers.Include(e => e.Colors).ThenInclude(c => c.Images).FirstOrDefault(e => e.ID == id);
            return View(model);
        }
        [HttpGet]
        [Route("Tower/{id}/{mdl}/Edit")]
        public IActionResult TowerEdit(int id, string mdl)
        {
            var model = _context.Towers.Include(e => e.Colors).ThenInclude(c => c.Images).FirstOrDefault(e => e.ID == id);
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
        public IActionResult TowerAddColor(int id, string colorHash)
        {
            var tower = _context.Towers.Include(e => e.Colors).FirstOrDefault(e => e.ID == id);
            Regex rgx = new Regex(@"^([#]{1}[a-fA-f0-9]{6})$");

            //Make sure color isn't null and is a color hash format
            if (colorHash != null && rgx.IsMatch(colorHash))
            {
                //Make sure the color is unique to this tower
                if (tower.Colors.FirstOrDefault(c => c.ColorHash == colorHash) == null)
                {
                    var color = new PMV.Color { ColorHash = colorHash };
                    tower.Colors.Add(color);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("TowerEdit", "Admin", new { ID = id, mdl = tower.Model });
        }
        public IActionResult TowerDeleteColor(int mID, int cID)
        {
            var tower = _context.Towers.Include(e => e.Colors).FirstOrDefault(e => e.ID == mID);
            var color = _context.Colors.Include(e => e.Images).FirstOrDefault(e => e.ID == cID);

            if (tower != null && color != null)
            {
                //Remove color from tower
                tower.Colors.Remove(color);
                //Remove color from database
                RemoveColor(color);

                _context.SaveChanges();
            }
            return RedirectToAction("TowerEdit", "Admin", new { ID = mID, mdl = tower.Model });
        }
        public IActionResult TowerDelete(int id)
        {
            var tower = _context.Towers.Include(e => e.Colors).ThenInclude(c => c.Images).FirstOrDefault(e => e.ID == id);
            if (tower != null)
            {
                RemoveAllColors(tower);

                _context.Towers.Remove(tower);
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
                motherboard.Color = new Color { ColorHash = "#000000" };
                _context.SaveChanges();
                return RedirectToAction("Motherboards");
            }

            return View(motherboard);
        }
        [Route("Motherboard/{id}/{mdl}/Details")]
        public IActionResult MotherboardDetails(int id, string mdl)
        {
            var model = _context.Motherboards.Include(e => e.Color.Images).FirstOrDefault(e => e.ID == id);
            return View(model);
        }
        [HttpGet]
        [Route("Motherboard/{id}/{mdl}/Edit")]
        public IActionResult MotherboardEdit(int id, string mdl)
        {
            var model = _context.Motherboards.Include(e => e.Color.Images).FirstOrDefault(e => e.ID == id);
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
        public IActionResult MotherboardDelete(int id)
        {
            var motherboard = _context.Motherboards.Include(e => e.Color.Images).FirstOrDefault(e => e.ID == id);
            if (motherboard != null)
            {
                //Remove motherboard's color from database
                RemoveColor(motherboard.Color);
                //Remove motherboard from database
                _context.Motherboards.Remove(motherboard);
                _context.SaveChanges();
            }
            return RedirectToAction("Motherboards");
        }
        #endregion

        #region Color
        public IActionResult ColorAddImage(int mID, int cID, string returnUrl, string imagePath)
        {
            ViewData["ReturnUrl"] = returnUrl;
            var color = _context.Colors.Include(e => e.Images).FirstOrDefault(e => e.ID == cID);
            Regex rgx = new Regex(@"^(((https\:\/\/)|(http\:\/\/))?(www[.][^.]*[.])?[^.]*[.]((jpg)|(jpeg)|(JPG)|(gif)|(png)|(bmp)))$");

            //Make sure imagePath isn't null and is an imagepath format
            if (imagePath != null && rgx.IsMatch(imagePath))
            {
                //Make sure the image is unique to this color
                if (color.Images.FirstOrDefault(i => i.ImagePath == imagePath) == null)
                {
                    var image = new PMV.Image { ImagePath = imagePath };
                    color.Images.Add(image);
                    _context.SaveChanges();
                }
            }
            var model = GetReturnModel(returnUrl, mID);
            return RedirectToAction(returnUrl, new { ID = mID, mdl = model });
        }
        public IActionResult ColorDeleteImage(int mID, int cID, int iID, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            
            var color = _context.Colors.Include(e => e.Images).FirstOrDefault(e => e.ID == cID);
            var image = _context.Images.FirstOrDefault(e => e.ID == iID);

            if (color != null && image != null)
            {
                //Remove image from color
                color.Images.Remove(image);
                //Remove image from database
                RemoveImage(image);

                _context.SaveChanges();
            }

            //Get model to return
            var model = GetReturnModel(returnUrl, mID);
            
            return RedirectToAction(returnUrl, new { ID = mID, mdl = model });
        }
        #endregion

        #region Helpers
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }
        private string GetReturnModel(string returnUrl, int id)
        {
            switch (returnUrl.Replace("Edit", ""))
            {
                case "Tower":
                    return _context.Towers.FirstOrDefault(e => e.ID == id).Model;
                case "Motherboard":
                    return _context.Motherboards.FirstOrDefault(e => e.ID == id).Model;
                default:
                    return null;
            }
        }

        private void RemoveAllColors(PMV.Tower tower)
        {
            //Remove all colors in tower from database
            foreach (var color in tower.Colors)
            {
                RemoveColor(color);
            }
            tower.Colors.Clear();
        }
        private void RemoveColor(PMV.Color color)
        {
            RemoveAllImages(color);

            var original = _context.Colors.FirstOrDefault(e => e.ID == color.ID);
            _context.Colors.Remove(original);
        }
        private void RemoveAllImages(PMV.Color color)
        {
            //Remove all images in color from database
            foreach (var image in color.Images)
            {
                RemoveImage(image);
            }
            color.Images.Clear();
        }
        private void RemoveImage(PMV.Image image)
        {
            var original = _context.Images.FirstOrDefault(e => e.ID == image.ID);
            _context.Images.Remove(original);
        }
        #endregion
    }
}