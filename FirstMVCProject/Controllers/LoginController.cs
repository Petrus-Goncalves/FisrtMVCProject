using FirstMVCProject.Models;
using FirstMVCProject.Models.User;
using FirstMVCProject.Repositorys.Users;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FirstMVCProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsers _usersRepository;
        public LoginController(IUsers usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    if (login.Email == null)
                    {
                        TempData["ErrorLoginEmailMessage"] = "O login é obrigatório";
                    }

                    if (login.Senha == null)
                    {
                        TempData["ErrorLoginPasswordMessage"] = "A senha é obrigatória";
                    }

                    return View(login);
                }

                var existeUsuario = _usersRepository.BuscarUsuarioEmailSenha(login);

                if (existeUsuario == null)
                {
                    TempData["ErrorInvalidLoginMessage"] = $"Usuário ou senha não cadastrados";
                    return View(login);
                }

                HomeModel view = new HomeModel() { Email = login.Email, Nome = existeUsuario.Nome };
                return RedirectToAction("Index", "Home", view);
            }
            catch (Exception erro)
            {
                TempData["ErrorLoginMessage"] = $"Ops, não foi possível realizar o seu login. Tente novamente. Erro: {erro.Message}";
                return View(login);
            }
        }
    }
}