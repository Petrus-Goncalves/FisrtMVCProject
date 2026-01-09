using FirstMVCProject.Models;
using FirstMVCProject.Repositorys;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstMVCProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContacts _contacts;

        public ContactController(IContacts contactsRepository)
        {
            _contacts = contactsRepository;
        }

        public IActionResult Contacts()
        {
            List<ContactModel> listaContatos = _contacts.BuscarTodos();

            return View(listaContatos);
        }

        public IActionResult AddContacts()
        {
            return View();
        }

        public IActionResult EditContacts()
        {
            return View();
        }

        public IActionResult DeleteContacts(int id)
        {
            ContactModel contact = _contacts.BuscarContato(id);

            return View(contact);
        }

        [HttpPost]
        public IActionResult AddContacts(ContactModel contact)
        {
            _contacts.AddContact(contact);

            return RedirectToAction("Contacts");
        }

        [HttpDelete]
        public IActionResult DeleteContacts(ContactModel contact)
        {
           _contacts.DeleteContact(contact);

            return RedirectToAction("Contacts");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}