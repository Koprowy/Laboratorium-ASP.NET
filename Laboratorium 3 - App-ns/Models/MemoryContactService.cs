using Data.Entities;

namespace Laboratorium_3___App_ns.Models
{
    public class MemoryContactService : IContactService
    {
        private readonly Dictionary<int, Contact> _items = new Dictionary<int, Contact>()
        {
            {1, new Contact() {Id = 1, Name = "Krystian", Email = "Krystian@wsei.edu.pl",Phone = 111222333, Birth = new DateTime(2001,6,6) } },
            {2, new Contact() {Id = 2, Name = "Ola", Email = "Ola@wsei.edu.pl",Phone = 222444555, Birth = new DateTime(2003,3,21) } }
        };
        private int Id = 3;
        private readonly IDateTimeProvider _timeProvider;

        private readonly List<OrganizationEntity> _organizations = new List<OrganizationEntity>()
        {
            new OrganizationEntity { Id = 1, Title = "WSEI", Regon = "Św. Filipa 17", Nip = "1241565"},
            new OrganizationEntity { Id = 2, Title = "Kraków", Regon = "Św. Filipa 17", Nip = "12415125"}
        };
        
        public MemoryContactService(IDateTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }


        public int Add(Contact contact)
        {
            contact.Id = Id++;  
            contact.Created = _timeProvider.GetCurrentDateTime();  

            _items[contact.Id] = contact;  

            return contact.Id;  
        }

        public Contact? Find(int id)
        {
            return _items[id];

        }

        public List<Contact> FindAll()
        {
            return _items.Values.ToList();
        }

        public void RemoveById(int Id)
        {
            _items.Remove(Id);
        }

        public void Update(Contact contact)
        {
            _items[contact.Id] = contact;
        }
        public List<OrganizationEntity> FindAllOrganizationsForVieModel()
        {
            return _organizations;
        }
    }
}
