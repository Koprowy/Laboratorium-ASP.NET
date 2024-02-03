using Data.Entities;
using Laboratorium_3___App_ns.Models;

namespace Laboratorium_3___App_ns.Mappers
{
    public class PhotoMapper
    {
        public static Photo FromEntity(PhotoEntity entity)
        {
            return new Photo()
            {
                Id = entity.Id,
                DateTaken = entity.DateTaken,
                Description = entity.Description,
                Camera = entity.Camera,
                Author = entity.Author,
                Resolution = entity.Resolution,
                Format = entity.Format,

            };
        }

        public static PhotoEntity ToEntity(Photo model)
        {
            return new PhotoEntity()
            {
                Id = model.Id,
                DateTaken = model.DateTaken,
                Description = model.Description,
                Camera = model.Camera,
                Author = model.Author,
                Resolution = model.Resolution,
                Format = model.Format,

            };
        }
    }
}
