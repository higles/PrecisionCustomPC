using System;
using System.Linq;
using System.Collections;
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
        #region Part
        [HttpGet]
        [Route("Part/{partType}/Add")]
        public IActionResult PartAdd(string partType)
        {
            ViewData["Part"] = partType;
            var type = GetDbSetType(partType);
            return View(Activator.CreateInstance(type));
        }

        #region ColoredPart
        [HttpGet]
        [Route("Colored/{partType}/{id}/{mdl}/Details")]
        public IActionResult ColoredPartDetails(string partType, int id, string mdl)
        {
            ViewData["Part"] = partType;
            var model = (PMV.Base.ColoredPart)GetDbEntry(partType, id);
            return View(model);
        }
        [HttpGet]
        [Route("Colored/{partType}/{id}/{mdl}/Edit")]
        public IActionResult ColoredPartEdit(string partType, int id, string mdl)
        {
            ViewData["Part"] = partType;
            var model = (PMV.Base.ColoredPart)GetDbEntry(partType, id);
            return View(model);
        }
        [HttpPost]
        public IActionResult ColoredPartDelete(string partType, int id)
        {
            var part = (PMV.Base.ColoredPart)GetDbEntry(partType, id);

            if (part != null)
            {
                RemoveAllColors(part);
                var entry = _context.Entry(part);
                entry.State = EntityState.Deleted;
                _context.SaveChanges();
            }
            string returnUrl;
            if (partType.Equals("Memory") || partType.Equals("Storage"))
                returnUrl = partType.Replace(" ", "");
            else
                returnUrl = partType.Replace(" ", "") + "s";

            return RedirectToAction(returnUrl);
        }

        #region Tower
        public IActionResult Towers()
        {
            var model = _context.Towers.ToList();
            return View(model);
        }        
        [HttpPost]
        [Route("Colored/Tower/Add")]
        public IActionResult TowerAdd(Tower tower)
        {
            ViewData["Part"] = "Tower";

            if (ModelState.IsValid)
            {
                _context.Towers.Add(tower);
                _context.SaveChanges();
                return RedirectToAction("Towers");
            }

            return View("PartAdd", tower);
        }
        [HttpPost]
        [Route("Colored/Tower/{id}/{mdl}/Edit")]
        public IActionResult TowerEdit(int id, string mdl, Tower tower)
        {
            ViewData["Part"] = "Tower";

            if (ModelState.IsValid)
            {
                var model = _context.Entry(tower).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Towers");
            }
            
            return View("ColoredPartEdit", tower);
        }
        #endregion
        #region Fan
        public IActionResult Fans()
        {
            var model = _context.Fans.ToList();
            return View(model);
        }
        [HttpPost]
        [Route("Colored/Fan/Add")]
        public IActionResult FanAdd(Fan fan)
        {
            ViewData["Part"] = "Fan";

            if (ModelState.IsValid)
            {
                _context.Fans.Add(fan);
                _context.SaveChanges();
                return RedirectToAction("Fans");
            }

            return View("PartAdd", fan);
        }
        [HttpPost]
        [Route("Colored/Fan/{id}/{mdl}/Edit")]
        public IActionResult FanEdit(int id, string mdl, Fan fan)
        {
            ViewData["Part"] = "Fan";

            if (ModelState.IsValid)
            {
                var model = _context.Entry(fan).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Fans");
            }

            return View("ColoredPartEdit", fan);
        }
        #endregion
        #region Memory
        public IActionResult Memory()
        {
            var model = _context.Memory.ToList();
            return View(model);
        }
        [HttpPost]
        [Route("Colored/Memory/Add")]
        public IActionResult MemoryAdd(Memory memory)
        {
            ViewData["Part"] = "Memory";

            if (ModelState.IsValid)
            {
                _context.Memory.Add(memory);
                _context.SaveChanges();
                return RedirectToAction("Memory");
            }

            return View("PartAdd", memory);
        }
        [HttpPost]
        [Route("Colored/Memory/{id}/{mdl}/Edit")]
        public IActionResult MemoryEdit(int id, string mdl, Memory memory)
        {
            ViewData["Part"] = "Memory";

            if (ModelState.IsValid)
            {
                var model = _context.Entry(memory).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Memory");
            }

            return View("ColoredPartEdit", memory);
        }
        #endregion
        #region Video Card
        public IActionResult VideoCards()
        {
            var model = _context.VideoCards.ToList();
            return View(model);
        }
        [HttpPost]
        [Route("Colored/Video Card/Add")]
        public IActionResult VideoCardAdd(VideoCard videoCard)
        {
            ViewData["Part"] = "Video Card";

            if (ModelState.IsValid)
            {
                _context.VideoCards.Add(videoCard);
                _context.SaveChanges();
                return RedirectToAction("VideoCards");
            }

            return View("PartAdd", videoCard);
        }
        [HttpPost]
        [Route("Colored/Video Card/{id}/{mdl}/Edit")]
        public IActionResult VideoCardEdit(int id, string mdl, VideoCard videoCard)
        {
            ViewData["Part"] = "Video Card";

            if (ModelState.IsValid)
            {
                var model = _context.Entry(videoCard).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("VideoCards");
            }

            return View("ColoredPartEdit", videoCard);
        }
        #endregion
        #endregion

        #region ColorlessPart
        [HttpGet]
        [Route("Colorless/{partType}/{id}/{mdl}/Details")]
        public IActionResult ColorlessPartDetails(string partType, int id, string mdl)
        {
            ViewData["Part"] = partType;
            var model = (PMV.Base.ColorlessPart)GetDbEntry(partType, id);
            return View(model);
        }
        [HttpGet]
        [Route("Colorless/{partType}/{id}/{mdl}/Edit")]
        public IActionResult ColorlessPartEdit(string partType, int id, string mdl)
        {
            ViewData["Part"] = partType;
            var part = (PMV.Base.ColorlessPart)GetDbEntry(partType, id);
            return View(part);
        }
        [HttpPost]
        public IActionResult ColorlessPartDelete(string partType, int id)
        {
            var part = (PMV.Base.ColorlessPart)GetDbEntry(partType, id);

            if (part != null)
            {
                RemoveColor(part.Color);
                var entry = _context.Entry(part);
                entry.State = EntityState.Deleted;
                _context.SaveChanges();
            }
            string returnUrl;
            if (partType.Equals("Memory") || partType.Equals("Storage"))
                returnUrl = partType.Replace(" ", "");
            else
                returnUrl = partType.Replace(" ", "") + "s";

            return RedirectToAction(returnUrl);
        }

        #region Motherboard
        public IActionResult Motherboards()
        {
            var model = _context.Motherboards.ToList();
            return View(model);
        }
        [HttpPost]
        [Route("Colorless/Motherboard/Add")]
        public IActionResult MotherboardAdd(Motherboard motherboard)
        {
            ViewData["Part"] = "Motherboard";

            if (ModelState.IsValid)
            {
                motherboard.Color = new Color { ColorValue = Options.Color.Black };
                _context.Motherboards.Add(motherboard);
                _context.SaveChanges();
                return RedirectToAction("Motherboards");
            }

            return View("PartAdd", motherboard);
        }
        [HttpPost]
        [Route("Colorless/Motherboard/{id}/{mdl}/Edit")]
        public IActionResult MotherboardEdit(int id, string mdl, Motherboard motherboard)
        {
            ViewData["Part"] = "Motherboard"; 

            if (ModelState.IsValid)
            {
                var model = _context.Entry(motherboard).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Motherboards");
            }

            return View("ColorlessPartEdit", motherboard);
        }
        #endregion
        #region Power Supply
        public IActionResult PowerSupplies()
        {
            var model = _context.PowerSupplies.ToList();
            return View(model);
        }
        [HttpPost]
        [Route("Colorless/Power Supply/Add")]
        public IActionResult PowerSupplyAdd(PowerSupply powerSupply)
        {
            ViewData["Part"] = "Power Supply";

            if (ModelState.IsValid)
            {
                powerSupply.Color = new Color { ColorValue = Options.Color.Black };
                _context.PowerSupplies.Add(powerSupply);
                _context.SaveChanges();
                return RedirectToAction("PowerSupplies");
            }

            return View("PartAdd", powerSupply);
        }
        [HttpPost]
        [Route("Colorless/Power Supply/{id}/{mdl}/Edit")]
        public IActionResult PowerSupplyEdit(int id, string mdl, PowerSupply powerSupply)
        {
            ViewData["Part"] = "Power Supply";

            if (ModelState.IsValid)
            {
                var model = _context.Entry(powerSupply).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("PowerSupplies");
            }

            return View("ColorlessPartEdit", powerSupply);
        }
        #endregion
        #region Processor
        public IActionResult Processors()
        {
            var model = _context.Processors.ToList();
            return View(model);
        }
        [HttpPost]
        [Route("Colorless/Processor/Add")]
        public IActionResult ProcessorAdd(Processor processor)
        {
            ViewData["Part"] = "Processor";

            if (ModelState.IsValid)
            {
                processor.Color = new Color { ColorValue = Options.Color.Black };
                _context.Processors.Add(processor);
                _context.SaveChanges();
                return RedirectToAction("Processors");
            }

            return View("PartAdd", processor);
        }
        [HttpPost]
        [Route("Colorless/Processor/{id}/{mdl}/Edit")]
        public IActionResult ProcessorEdit(int id, string mdl, Processor processor)
        {
            ViewData["Part"] = "Processor";

            if (ModelState.IsValid)
            {
                var model = _context.Entry(processor).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Processors");
            }

            return View("ColorlessPartEdit", processor);
        }
        #endregion
        #region Storage
        public IActionResult Storage()
        {
            var model = _context.Storage.ToList();
            return View(model);
        }
        [HttpPost]
        [Route("Colorless/Storage/Add")]
        public IActionResult StorageAdd(Storage storage)
        {
            ViewData["Part"] = "Storage";

            if (ModelState.IsValid)
            {
                storage.Color = new Color { ColorValue = Options.Color.Black };
                _context.Storage.Add(storage);
                _context.SaveChanges();
                return RedirectToAction("Storage");
            }

            return View("PartAdd", storage);
        }
        [HttpPost]
        [Route("Colorless/Storage/{id}/{mdl}/Edit")]
        public IActionResult StorageEdit(int id, string mdl, Storage storage)
        {
            ViewData["Part"] = "Storage";

            if (ModelState.IsValid)
            {
                var model = _context.Entry(storage).State = EntityState.Modified;
                _context.SaveChanges();

                return RedirectToAction("Storage");
            }

            return View("ColorlessPartEdit", storage);
        }
        #endregion
        #endregion
        #endregion

        #region Color
        [HttpPost]
        public IActionResult PartAddColor(int id, Options.Color colorModel, string partType)
        {
            var part = (PMV.Base.ColoredPart)GetDbEntry(partType, id);
            
            //Make sure the color is unique to this tower
            if (part.Colors.FirstOrDefault(c => c.ColorValue == colorModel) == null)
            {
                var color = new PMV.Color { ColorValue = colorModel };
                part.Colors.Add(color);
                _context.SaveChanges();
            }

            return RedirectToAction("ColoredPartEdit", new { PartType = partType, ID = id, mdl = part.Model });
        }
        [HttpPost]
        public IActionResult PartDeleteColor(int mID, int cID, string partType)
        {
            var part = (PMV.Base.ColoredPart)GetDbEntry(partType, mID);
            var color = _context.Colors.Include(e => e.Images).FirstOrDefault(e => e.ID == cID);

            if (part != null && color != null)
            {
                //Remove color from part
                part.Colors.Remove(color);
                //Remove color from database
                RemoveColor(color);

                _context.SaveChanges();
            }
            return RedirectToAction("ColoredPartEdit", new { PartType = partType, ID = mID, mdl = part.Model });
        }
        [HttpPost]
        public IActionResult ColorAddImage(int mID, int cID, string partType, string imagePath)
        {
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
            var part = GetDbEntry(partType, mID);
            var returnUrl = GetReturnPrefix(part) + "Edit";
            
            return RedirectToAction(returnUrl, new { PartType = partType, ID = mID, mdl = part.Model });
        }
        [HttpPost]
        public IActionResult ColorDeleteImage(int mID, int cID, int iID, string partType)
        {
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
            var part = GetDbEntry(partType, mID);
            var returnUrl = GetReturnPrefix(part) + "Edit";

            return RedirectToAction(returnUrl, new { PartType = partType, ID = mID, mdl = part.Model });
        }
        #endregion

        #region Helpers
        private PMV.Base.Part GetDbEntry(string partType, int id)
        {
            if (partType == null) return null;

            switch(partType)
            {
                case "Tower":
                    return _context.Towers.Include(e => e.Colors).ThenInclude(c => c.Images).FirstOrDefault(e => e.ID == id);
                case "Fan":
                    return _context.Fans.Include(e => e.Colors).ThenInclude(c => c.Images).FirstOrDefault(e => e.ID == id);
                case "Memory":
                    return _context.Memory.Include(e => e.Colors).ThenInclude(c => c.Images).FirstOrDefault(e => e.ID == id);
                case "Video Card":
                    return _context.VideoCards.Include(e => e.Colors).ThenInclude(c => c.Images).FirstOrDefault(e => e.ID == id);
                case "Motherboard":
                    return _context.Motherboards.Include(e => e.Color.Images).FirstOrDefault(e => e.ID == id);
                case "Power Supply":
                    return _context.PowerSupplies.Include(e => e.Color.Images).FirstOrDefault(e => e.ID == id);
                case "Processor":
                    return _context.Processors.Include(e => e.Color.Images).FirstOrDefault(e => e.ID == id);
                case "Storage":
                    return _context.Storage.Include(e => e.Color.Images).FirstOrDefault(e => e.ID == id);
            }

            return null;
        }
        private Type GetDbSetType(string partType)
        {
            if (partType == null) return null;

            switch (partType)
            {
                case "Tower":
                    return typeof(Tower);
                case "Fan":
                    return typeof(Fan);
                case "Memory":
                    return typeof(Memory);
                case "Video Card":
                    return typeof(VideoCard);
                case "Motherboard":
                    return typeof(Motherboard);
                case "Power Supply":
                    return typeof(PowerSupply);
                case "Processor":
                    return typeof(Processor);
                case "Storage":
                    return typeof(Storage);
            }

            return null;
        }
        private string GetReturnPrefix(PMV.Base.Part part)
        {
            if (part is PMV.Base.ColoredPart)
            {
                return "ColoredPart";
            }
            else
            {
                return "ColorlessPart";
            }
        }

        private void RemoveAllColors(PMV.Base.ColoredPart part)
        {
            //Remove all colors in tower from database
            foreach (var color in part.Colors)
            {
                RemoveColor(color);
            }
            part.Colors.Clear();
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