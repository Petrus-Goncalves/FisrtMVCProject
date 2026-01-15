using FirstMVCProject.Models;

namespace FirstMVCProject.Repositorys.Contacts
{
    public interface IContacts
    {
        ContactModel BuscarContato(ContactModel contact);
        ContactModel AddContact(ContactModel contact);
        ContactModel EditContact(ContactModel contact);
        ContactModel DeleteContact(ContactModel contact);
        List<ContactModel> BuscarTodos();
    }
}
