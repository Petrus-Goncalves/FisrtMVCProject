using FirstMVCProject.Models;
using FirstMVCProject.Repositorys.Users;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsers _usersRepository;
        public UserController(IUsers users)
        {
            _usersRepository = users;
        }

        public IActionResult Index()
        {
            List<UserModel> usuarios = _usersRepository.BuscarTodos();

            return View(usuarios);
        }

        public IActionResult AddUsers()
        {
            return View();
        }

        public IActionResult DeleteUsers()
        {
            return View();
        }

        public IActionResult EditUser(UserModel model)
        {
            UserModel user = _usersRepository.BuscarUsuarioId(model);

            return View(user);
        }

        [HttpPost]
        public IActionResult AddUsers(UserModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                return View("AddUsers");
            }
            catch (Exception erro)
            {
                TempData["ErrorMessage"] = $"Ops, não conseguimos criar um novo contato. Tente novamente. Erro: {erro.Message}";
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult EditUsers(UserModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                _usersRepository.EditUser(model);

                return View("EditUsers", model);
            }
            catch (Exception erro)
            {
                TempData["ErrorMessage"] = $"Ops, não conseguimos criar um novo contato. Tente novamente. Erro: {erro.Message}";
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult DeleteUsers(UserModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                _usersRepository.DeleteUser(model);

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["ErrorMessage"] = $"Ops, não conseguimos criar um novo contato. Tente novamente. Erro: {erro.Message}";
                return View(model);
            }
        }
    }
}
