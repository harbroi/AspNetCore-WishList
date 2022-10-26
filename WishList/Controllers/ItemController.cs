using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private ApplicationDbContext _context { get; set; }

        public ItemController(ApplicationDbContext _context)
        {

        }

        public IActionResult Index()
        {
            return View(_context.Items);
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
