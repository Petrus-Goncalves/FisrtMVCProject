using FirstMVCProject.Models;
using FirstMVCProject.Repositorys.Contacts;
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

        public IActionResult EditContacts(ContactModel model)
        {
            ContactModel contact = _contacts.BuscarContato(model);

            return View(contact);
        }

        public IActionResult DeleteContacts(ContactModel model)
        {
            ContactModel contact = _contacts.BuscarContato(model);

            return View(contact);
        }

        [HttpPost]
        public IActionResult AddContacts(ContactModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                _contacts.AddContact(model);
                TempData["SucessMessage"] = "Contato cadastrado com sucesso";

                return RedirectToAction("Contacts");
            }
            catch (Exception erro)
            {
                TempData["ErrorMessage"] = $"Ops, não conseguimos cadastrar seu contato. Tente novamente. Erro: {erro.Message}";
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult ConfirmationEditContact(ContactModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("EditContacts", model);
                }

                _contacts.EditContact(model);
                TempData["SucessEditMessage"] = "Contato editado com sucesso";

                return View("EditContacts", model);
            }
            catch (Exception erro)
            {
                TempData["ErrorEditMessage"] = $"Ops, não conseguimos atualizar o seu contato. Tente novamente. Erro: {erro.Message}";
                return View("EditContacts", model);
            }
        }

        [HttpPost]
        public IActionResult ConfirmationDeleteContact(ContactModel model)
        {
            try
            {
                ContactModel contact = _contacts.BuscarContato(model);
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