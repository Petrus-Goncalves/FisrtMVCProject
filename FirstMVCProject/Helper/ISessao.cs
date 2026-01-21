using FirstMVCProject.Models.User;

namespace FirstMVCProject.Helper
{
    public interface ISessao
    {
        void CriarSessaoUsuario(UserModel user);
        void RemoverSessaoUsuario();
        UserModel BuscarSessaoUsuario();
    }
}