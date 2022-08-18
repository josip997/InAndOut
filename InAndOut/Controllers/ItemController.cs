using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        private readonly InAndOutDbContext inAndOutDbContext;

        public ItemController(InAndOutDbContext inAndOutDbContext)
        {
            this.inAndOutDbContext = inAndOutDbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> objList = inAndOutDbContext.Items;
            return View(objList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //check if we stil have token
        public IActionResult Create(Item obj)
        {
            inAndOutDbContext.Items.Add(obj);
            inAndOutDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
