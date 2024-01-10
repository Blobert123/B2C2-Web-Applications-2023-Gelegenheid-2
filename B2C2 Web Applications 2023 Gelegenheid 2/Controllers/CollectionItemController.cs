using B2C2_Web_Applications_2023_Gelegenheid_2.Data;
using B2C2_Web_Applications_2023_Gelegenheid_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace B2C2_Web_Applications_2023_Gelegenheid_2.Controllers
{
    public class CollectionItemController : Controller
    {
        private readonly CollectionDBContext _db;

        public CollectionItemController(CollectionDBContext db)
        {
            _db = db;        
        }

        public IActionResult Index()
        {
            var collectionItems = _db.CollectionItems
                .Include(ci => ci.CollectionName)
                .ToList();

            return View(collectionItems);
        }

        public IActionResult Create()
        {
            var collectionNames = _db.CollectionNames
            .Select(cn => new SelectListItem
            {
                Value = cn.Id.ToString(),
                Text = cn.Name
            })
            .ToList();

            ViewBag.CollectionNames = collectionNames;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CollectionItem obj)
        {
            if (ModelState.IsValid)
            {
                _db.CollectionItems.Add(obj);
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

            var itemFromDB = _db.CollectionItems.Find(id);

            if (itemFromDB == null)
            {
                return NotFound();
            }

            var collectionNames = _db.CollectionNames
            .Select(cn => new SelectListItem
            {
                Value = cn.Id.ToString(),
                Text = cn.Name
            })
            .ToList();

            ViewBag.CollectionNames = collectionNames;

            return View(itemFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CollectionItem obj)
        {
            if (ModelState.IsValid) 
            {
                _db.CollectionItems.Update(obj);
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

            var itemFromDB = _db.CollectionItems.Find(id);

            if (itemFromDB == null)
            {
                return NotFound();
            }

            var collectionNames = _db.CollectionNames
            .Select(cn => new SelectListItem
            {
                Value = cn.Id.ToString(),
                Text = cn.Name
            })
            .ToList();

            ViewBag.CollectionNames = collectionNames;

            return View(itemFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.CollectionItems.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.CollectionItems.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
