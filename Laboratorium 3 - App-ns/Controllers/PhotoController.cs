using Laboratorium_3___App_ns.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3___App_ns.Controllers
{
    public class PhotoController : Controller
    {
        private static List<Photo> photos = new List<Photo>();
        private static int nextId = 1;

        [HttpPost]
        public IActionResult Create(Photo photo)
        {
            if (ModelState.IsValid)
            {
                // Tutaj logika dodawania zdjęcia do bazy danych lub kolekcji
                return RedirectToAction("Index"); // Przekierowanie do widoku listy zdjęć
            }

            return View(photo); // Ponowne wyświetlenie formularza z błędami walidacji
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var photo = photos.FirstOrDefault(p => p.Id == id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var photo = photos.FirstOrDefault(p => p.Id == id);
            if (photo == null)
            {
                return NotFound();
            }

            photos.Remove(photo);

            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var photo = photos.FirstOrDefault(p => p.Id == id);
            if (photo == null)
            {
                return NotFound();
            }

            return View(photo);
        }

    }
}