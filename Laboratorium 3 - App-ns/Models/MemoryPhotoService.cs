using System.Collections.Generic;
using System.Linq;

namespace Laboratorium_3___App_ns.Models
{
    public class MemoryPhotoService : IPhotoService
    {
        private readonly List<Photo> _photos = new List<Photo>();
        private int nextId = 1;

        public int Add(Photo photo)
        {
            photo.Id = nextId++;
            _photos.Add(photo);
            return photo.Id;
        }

        public void Delete(int photoId)
        {
            var photo = _photos.FirstOrDefault(p => p.Id == photoId);
            if (photo != null)
            {
                _photos.Remove(photo);
            }
        }

        public void Update(Photo photo)
        {
            var existingPhoto = _photos.FirstOrDefault(p => p.Id == photo.Id);
            if (existingPhoto != null)
            {
                // Zaktualizuj właściwości istniejącego zdjęcia
                existingPhoto.DateTaken = photo.DateTaken;
                existingPhoto.Description = photo.Description;
                existingPhoto.Camera = photo.Camera;
                existingPhoto.Author = photo.Author;
                existingPhoto.Resolution = photo.Resolution;
                existingPhoto.Format = photo.Format;
            }
        }

        public Photo GetById(int photoId)
        {
            return _photos.FirstOrDefault(p => p.Id == photoId);
        }

        public IEnumerable<Photo> GetByCategory(PhotoCategory category)
        {
            return _photos.Where(p => p.Category == category).ToList();
        }
    }
}
