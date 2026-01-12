using FirstMVCProject.Models;
using FirstMVCProject.Repositorys;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public IActionResult EditContacts(int id)
        {
            ContactModel contact = _contacts.BuscarContato(id);

            return View(contact);
        }

        public IActionResult DeleteContacts(int id)
        {
            ContactModel contact = _contacts.BuscarContato(id);

            return View(contact);
        }

        [HttpPost]
        public IActionResult AddContacts(ContactModel contact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(contact);
                }

                _contacts.AddContact(contact);
                TempData["SucessMessage"] = "Contato cadastrado com sucesso";

                return RedirectToAction("Contacts");
            }
            catch (Exception erro)
            {
                TempData["ErrorMessage"] = $"Ops, não conseguimos cadastrar seu contato. Tente novamente. Erro: {erro.Message}";
                return View(contact);
            }
        }

        [HttpPost]
        public IActionResult ConfirmationEditContact(ContactModel contact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("EditContacts", contact);
                }

                _contacts.EditContact(contact);
                TempData["SucessEditMessage"] = "Contato editado com sucesso";

                return View("EditContacts", contact);
            }
            catch (Exception erro)
            {
                TempData["ErrorEditMessage"] = $"Ops, não conseguimos atualizar o seu contato. Tente novamente. Erro: {erro.Message}";
                return View("EditContacts", contact);
            }
        }

        [HttpPost]
        public IActionResult ConfirmationDeleteContact(int id)
        {
            try
            {
                ContactModel contact = _contacts.BuscarContato(id);
                _contacts.DeleteContact(contact);

                TempData["SucessDeleteMessage"] = "Contato excluído com sucesso";

                return RedirectToAction("Contacts");
            }
            catch (Exception erro)
            {
                TempData["ErrorDeleteMessage"] = $"Ops, não foi possível excluir o contato. Tente novamente. Erro: {erro.Message}";

                return RedirectToAction("Contacts");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}