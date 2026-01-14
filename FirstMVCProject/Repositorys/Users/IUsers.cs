using FirstMVCProject.Models;

namespace FirstMVCProject.Repositorys.Users
{
    public interface IUsers
    {
        UserModel ExisteUsuarioEmailSenha(LoginModel model);
        UserModel AddUser(UserModel model); 
        UserModel EditUser(UserModel model);
        UserModel DeleteUser(UserModel model);
        List<UserModel> BuscarTodos(UserModel model);
    }
}