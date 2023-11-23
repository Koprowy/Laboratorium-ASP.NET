using Laboratorium_3___App_ns.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium3___App_ns.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View(_contactService.FindAll());
        }

        //zwracanie formularza dodawania kontaktu:
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if (ModelState.IsValid) { }
            {
                //zapamietanie kontaktu - modelu
                _contactService.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var contact = _contactService.Find(id);

            if (contact == null)
            {
                return NotFound();
            }

            _contactService.RemoveById(id);
            return RedirectToAction("Index");
            return View();
        }
    }
}
