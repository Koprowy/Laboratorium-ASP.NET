namespace Laboratorium_3___App_ns.Models
{
    public interface IPhotoService
    {
        int Add(Photo photo);
        void Delete(int photoId);
        void Update(Photo photo);
        Photo GetById(int photoId);
        IEnumerable<Photo> GetByCategory(PhotoCategory category);

    }
}
