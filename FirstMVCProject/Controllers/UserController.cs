using FirstMVCProject.Models.User;
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

        public IActionResult DeleteUser(int id)
        {
            UserModel user = _usersRepository.BuscarUsuarioId(id);

            EditUserModel editUserModel = new EditUserModel
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email,
                Login = user.Login,
                Perfil = user.Perfil
            };

            return View("DeleteUsers", editUserModel);
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            UserModel user = _usersRepository.BuscarUsuarioId(id);

            EditUserModel editUserModel = new EditUserModel
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email,
                Login = user.Login,
                Perfil = user.Perfil
            };

            return View("EditUsers", editUserModel);
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

                _usersRepository.AddUser(model);

                return RedirectToAction("Index");
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
                TempData["SucessEditMessage"] = "Usuário atualizado com sucesso";

                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["ErrorEditMessage"] = $"Ops, não conseguimos atualizar o usuário. Tente novamente. Erro: {erro.Message}";
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult DeleteUsers(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(id);
                }

                _usersRepository.DeleteUser(id);

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["ErrorMessage"] = $"Ops, não conseguimos criar um novo contato. Tente novamente. Erro: {erro.Message}";
                return View(id);
            }
        }
    }
}
