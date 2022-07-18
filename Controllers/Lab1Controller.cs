using Lab1.Models;
using Lab1.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Lab1.Controllers
{
    public class Lab1Controller : Controller
    {
        private Lab1Context _db { get; set; }
        public Lab1Controller (Lab1Context context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            List<Customer> c = new List<Customer>(_db.Customers);
            return View(c);
        }

        public IActionResult Check(int id)
        {
            Customer c = _db.Customers.First(c => c.Id == id);
            return View(c);
        }

        public IActionResult Rental()
        {
            List<Rental> r = new List<Rental>(_db.Rentals.Include(r => r.Equipment).Include(r => r.Customer));
            IEnumerable<Rental> r2 = r.OrderBy(r => r.Customer.UserName);
            return View(r2);
        }

        [HttpPost]
        public ActionResult End(int id)
        {
            Rental r = _db.Rentals.First(r => r.Id == id);
            r.IsCurrent = false;
            _db.SaveChanges();
            return RedirectToAction("Rental");
        }

        public IActionResult NewRental()
        {
            EquipmentSelectViewModel vm = new EquipmentSelectViewModel(_db.Equipment.ToList());
            return View(vm);
        }

        [HttpPost]
        public IActionResult CreateNewRental(string customer,int hours)
        {
            return RedirectToAction("Rental");
        }
    }
}
