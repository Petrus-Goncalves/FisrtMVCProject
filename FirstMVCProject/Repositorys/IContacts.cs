using FirstMVCProject.Models;

namespace FirstMVCProject.Repositorys
{
    public interface IContacts
    {
        List<ContactModel> BuscarTodos();
        ContactModel BuscarContato(int id);
        ContactModel AddContact(ContactModel contact);
        ContactModel DeleteContact(ContactModel contact);
    }
}
