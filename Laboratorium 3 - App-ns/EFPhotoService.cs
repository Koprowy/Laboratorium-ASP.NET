using Laboratorium_3___App_ns.Mappers;
using Laboratorium_3___App_ns.Models;
using Data;
using Data.Entities;

namespace Laboratorium_3___App_ns
{
    public class EFPhotoService : IPhotoService
    {
        private readonly AppDbContext _context;

        public EFPhotoService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Photo photo)
        {
            var entity = PhotoMapper.ToEntity(photo);
            _context.Photos.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Delete(int photoId)
        {
            var photo = _context.Photos.Find(photoId);
            if (photo != null)
            {
                _context.Photos.Remove(photo);
                _context.SaveChanges();
            }
        }

        public void Update(Photo photo)
        {
            var entity = PhotoMapper.ToEntity(photo);
            _context.Photos.Update(entity);
            _context.SaveChanges();
        }

        public Photo GetById(int photoId)
        {
            var entity = _context.Photos.Find(photoId);
            return entity != null ? PhotoMapper.FromEntity(entity) : null;
        }

        public IEnumerable<Photo> GetAll()
        {
            return _context.Photos
                .Select(p => PhotoMapper.FromEntity(p))
                .ToList();
        }
    }
}
