using FirstMVCProject.Data;
using FirstMVCProject.Models;
using FirstMVCProject.Models.User;

namespace FirstMVCProject.Repositorys.Users
{
    public class UsersRepository : IUsers
    {
        private readonly BDContext _bancoContext;

        public UsersRepository(BDContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public UserModel ExisteUsuarioEmailSenha(LoginModel model)
        {
            return _bancoContext.Users.Where(x => x.Email == model.Email && x.Senha == model.Senha).FirstOrDefault();
        }

        public UserModel BuscarUsuarioId(int id)
        {
            return _bancoContext.Users.Find(id);
        }
        public List<UserModel> BuscarTodos()
        {
            List<UserModel> lista = _bancoContext.Users.ToList();

            return lista;
        }
        public UserModel AddUser(UserModel model)
        {   
            _bancoContext.Users.Add(model);
            _bancoContext.SaveChanges();

            return model;
        }

        public UserModel EditUser(UserModel model)
        {
            UserModel user = _bancoContext.Users.FirstOrDefault(x => x.Id == model.Id);

            user.Nome = model.Nome;
            user.Login = model.Login;
            user.Email = model.Email;
            user.Perfil = model.Perfil;
            user.Senha = model.Senha;
            user.DataAlteracao = DateTime.Now;

            _bancoContext.Update(user);
            _bancoContext.SaveChanges();

            return model;
        }

        public UserModel DeleteUser(int id)
        {
            UserModel user = _bancoContext.Users.Find(id);

            _bancoContext.Users.Remove(user);
            _bancoContext.SaveChanges();

            return user;
        }
    }
}
