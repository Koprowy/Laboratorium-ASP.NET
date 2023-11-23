namespace Laboratorium_3___App_ns.Models
{
    public interface IContactService
    {
        void Add(Contact contact);
        void RemoveById(int Id);
        void Update(Contact contact);
        List<Contact> FindAll();
        Contact? Find(int Id);
    }
}
