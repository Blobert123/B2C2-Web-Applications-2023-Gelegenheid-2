using B2C2_Web_Applications_2023_Gelegenheid_2.Data;
using B2C2_Web_Applications_2023_Gelegenheid_2.Models;
using Microsoft.AspNetCore.Mvc;

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
            IEnumerable<CollectionItem> objCollectionItemList = _db.CollectionItems;
            return View(objCollectionItemList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CollectionItem obj)
        {
            _db.CollectionItems.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
