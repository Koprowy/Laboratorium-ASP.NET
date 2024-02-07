using Laboratorium_3___App_ns.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Labolatorium3___App_ns.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_contactService.FindAll());
        }

        private void InitializeOrganizations(Contact model)
        {
            model.Organizations = _contactService
                .FindAllOrganizationsForVieModel() // Użyj poprawnej nazwy metody
                .Select(o => new SelectListItem { Value = o.Id.ToString(), Text = o.Title })
                .ToList();
        }
        [HttpGet]
        public IActionResult Create()
        {
            Contact model = new Contact();
            InitializeOrganizations(model);
            return View(model);
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
            InitializeOrganizations(model);
            return View(model);
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
