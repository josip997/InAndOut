using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly InAndOutDbContext inAndOutDbContext;

        public ExpenseController(InAndOutDbContext inAndOutDbContext)
        {
            this.inAndOutDbContext = inAndOutDbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> objList = inAndOutDbContext.Expenses;
            return View(objList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //check if we stil have token
        public IActionResult Create(Expense obj)
        {
            if (ModelState.IsValid)
            {
                inAndOutDbContext.Expenses.Add(obj);
                inAndOutDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = inAndOutDbContext.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //check if we stil have token
        public IActionResult DeletePost(int? id)
        {
            var obj = inAndOutDbContext.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            inAndOutDbContext.Expenses.Remove(obj);
            inAndOutDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = inAndOutDbContext.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //check if we stil have token
        public IActionResult Update(Expense obj)
        {
            if (ModelState.IsValid)
            {
                inAndOutDbContext.Expenses.Update(obj);
                inAndOutDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }
    }
}
