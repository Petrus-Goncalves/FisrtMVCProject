using FirstMVCProject.Helper;
using FirstMVCProject.Models;
using FirstMVCProject.Models.User;
using FirstMVCProject.Repositorys.Users;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsers _usersRepository;
        private readonly ISessao _sessao;
        public LoginController(IUsers usersRepository, ISessao sessao)
        {
            _usersRepository = usersRepository;
            _sessao = sessao;
        }

        public IActionResult Login()
        {
            if(_sessao.BuscarSessaoUsuario() != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
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

                if (existeUsuario != null)
                {
                    _sessao.CriarSessaoUsuario(existeUsuario);

                    HomeModel view = new HomeModel() { Email = login.Email, Nome = existeUsuario.Nome };
                    return RedirectToAction("Index", "Home", view);
                }

                TempData["ErrorInvalidLoginMessage"] = $"Usuário ou senha não cadastrados";
                return View(login);
            }
            catch (Exception erro)
            {
                TempData["ErrorLoginMessage"] = $"Ops, não foi possível realizar o seu login. Tente novamente. Erro: {erro.Message}";
                return View(login);
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View("Logout");
        }

        [HttpPost]
        public IActionResult ConfirmLogout(int id)
        {
            _sessao.RemoverSessaoUsuario();
            return View("Login");
        }
    }
}