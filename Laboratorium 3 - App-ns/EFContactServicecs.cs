using Laboratorium_3___App_ns.Mappers;
using Laboratorium_3___App_ns.Models;
using Data;
using Data.Entities;
namespace Laboratorium_3___App_ns
{
    public class EFContactService : IContactService
    {
        private AppDbContext _context;

        public EFContactService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Contact contact)
        {
            var e = _context.Contacts.Add(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
            return e.Entity.Id;
        }

        public void RemoveById(int Id)
        {
            ContactEntity? find = _context.Contacts.Find(Id);
            if (find != null)
            {
                _context.Contacts.Remove(find);
            }
        }

        public List<Contact> FindAll()
        {
            return _context.Contacts.Select(e => ContactMapper.FromEntity(e)).ToList(); ;
        }

        public Contact? Find(int Id)
        {
            return ContactMapper.FromEntity(_context.Contacts.Find(Id));
        }

        public void Update(Contact contact)
        {
            _context.Contacts.Update(ContactMapper.ToEntity(contact));
        }
    }
}
