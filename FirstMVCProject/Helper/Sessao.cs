using FirstMVCProject.Models.User;
using Newtonsoft.Json;

namespace FirstMVCProject.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext; 
        }

        public UserModel BuscarSessaoUsuario()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<UserModel>(sessaoUsuario);
        }

        public void CriarSessaoUsuario(UserModel user)
        {
            string usuario = JsonConvert.SerializeObject(user);

            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", usuario);
        }

        public void RemoverSessaoUsuario()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}