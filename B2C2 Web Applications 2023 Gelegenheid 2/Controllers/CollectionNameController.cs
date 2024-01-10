using B2C2_Web_Applications_2023_Gelegenheid_2.Data;
using B2C2_Web_Applications_2023_Gelegenheid_2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace B2C2_Web_Applications_2023_Gelegenheid_2.Controllers
{
    public class CollectionNameController : Controller
    {
        private readonly CollectionDBContext _db;

        public CollectionNameController(CollectionDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var collectionName = _db.CollectionNames
                .Include(ci => ci.Admin)
                .ToList();

            return View(collectionName);
        }

        public IActionResult Create()
        {
            var admins = _db.Admins
            .Select(cn => new SelectListItem
            {
                Value = cn.Id.ToString(),
                Text = cn.Name
            })
            .ToList();

            ViewBag.Admins = admins;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CollectionName obj)
        {
            if (ModelState.IsValid)
            {
                _db.CollectionNames.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var itemFromDB = _db.CollectionNames.Find(id);

            if (itemFromDB == null)
            {
                return NotFound();
            }

            var admins = _db.Admins
            .Select(cn => new SelectListItem
            {
                Value = cn.Id.ToString(),
                Text = cn.Name
            })
            .ToList();
            ViewBag.Admins = admins;

            return View(itemFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CollectionName obj)
        {
            if (ModelState.IsValid)
            {
                _db.CollectionNames.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var itemFromDB = _db.CollectionNames.Find(id);

            if (itemFromDB == null)
            {
                return NotFound();
            }

            var admins = _db.Admins
            .Select(cn => new SelectListItem
            {
                Value = cn.Id.ToString(),
                Text = cn.Name
            })
            .ToList();

            ViewBag.Admins = admins;

            return View(itemFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.CollectionNames.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.CollectionNames.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
