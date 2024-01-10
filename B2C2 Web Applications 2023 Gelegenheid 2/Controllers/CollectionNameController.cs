using B2C2_Web_Applications_2023_Gelegenheid_2.Data;
using B2C2_Web_Applications_2023_Gelegenheid_2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace B2C2_Web_Applications_2023_Gelegenheid_2.Controllers
{
    public class CollectionNameController : Controller
    {
        private readonly CollectionDBContext _db;

        public CollectionNameController(CollectionDBContext db)
        {
            _db = db;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            IEnumerable<CollectionName> objCollectionNameList = _db.CollectionNames;
            return View(objCollectionNameList);
        }

        public IActionResult Create()
        {
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
