using FirstMVCProject.Data;
using FirstMVCProject.Models;

namespace FirstMVCProject.Repositorys
{
    public class ContactsRepository : IContacts
    {
        private readonly BDContext _bancoContext;
        public ContactsRepository(BDContext bDContext)
        {
            _bancoContext = bDContext;
        }
        public List<ContactModel> BuscarTodos()
        {
            return _bancoContext.Contacts.ToList();
        }

        public ContactModel BuscarContato(int id)
        {
            return _bancoContext.Contacts.FirstOrDefault(x => x.Id == id);
        }
        public ContactModel AddContact(ContactModel contact)
        {
            _bancoContext.Contacts.Add(contact);
            _bancoContext.SaveChanges();

            return contact;
        }

        public ContactModel EditContact(ContactModel contact)
        {
            ContactModel contactEntity = BuscarContato(contact.Id);

            contactEntity.Celular = contact.Celular;
            contactEntity.Email = contact.Email;    
            contactEntity.Nome = contact.Nome;

            _bancoContext.Update(contactEntity);
            _bancoContext.SaveChanges();

            return contact;
        }

        public ContactModel DeleteContact(ContactModel contact)
        {
            _bancoContext.Contacts.Remove(contact);
            _bancoContext.SaveChanges();

            return contact;
        }
    }
}