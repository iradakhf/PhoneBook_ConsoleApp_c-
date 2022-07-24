using CoreLibrary;
using DataLibrary.Base;


namespace DataLibrary.Implementations
{
    public class ContactRepository : IRepository<Contact>
    {
        public static int Id { get; set; }
        public Contact Create(Contact entity)
        {
            Id++;
            entity.Id = Id;
            Data.Contacts.Add(entity);
            return entity;
        }

        public void Delete(Contact entity)
        {
            Data.Contacts.Remove(entity);
                        
        }

        public Contact Get(Predicate<Contact> filter=null)
        {
            if (filter == null)
            {
                return Data.Contacts[0];
            }
            else
            {
                return Data.Contacts.Find(filter);
            }
        }

        public List<Contact> GetAll(Predicate<Contact> filter=null)
        {
            if (filter == null)
            {
                return Data.Contacts;
            }
            else
            {
                return Data.Contacts.FindAll(filter);
            }
        }

        public void Update(Contact entity)
        {
            var contact = Data.Contacts.Find(c => c.Id == entity.Id);
            if (contact != null)
            {
            contact.Id = entity.Id;
            contact.Name = entity.Name;
            contact.Surname = entity.Surname;
            contact.Number = entity.Number;

            }

        }
    }
}