using FirstMVCProject.Models;
using FirstMVCProject.Models.User;

namespace FirstMVCProject.Repositorys.Users
{
    public interface IUsers
    {
        UserModel ExisteUsuarioEmailSenha(LoginModel model);
        UserModel BuscarUsuarioId(int id);
        UserModel AddUser(UserModel model); 
        UserModel EditUser(UserModel model);
        UserModel DeleteUser(int id);
        List<UserModel> BuscarTodos();
    }
}