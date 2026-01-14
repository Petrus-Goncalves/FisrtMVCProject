using FirstMVCProject.Data;
using FirstMVCProject.Models;

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

        public UserModel BuscarUsuarioId(UserModel model)
        {
            return _bancoContext.Users.Find(model.Id);
        }
        public List<UserModel> BuscarTodos(UserModel model)
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
            user.DataAlteracao = DateTime.Now;

            _bancoContext.Update(user);
            _bancoContext.SaveChanges();

            return model;
        }

        public UserModel DeleteUser(UserModel model)
        {
            UserModel user = _bancoContext.Users.Find(model.Id);

            _bancoContext.Users.Remove(user);
            _bancoContext.SaveChanges();

            return model;
        }
    }
}
