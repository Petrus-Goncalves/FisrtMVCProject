using FirstMVCProject.Enums;
using System.ComponentModel.DataAnnotations;

namespace FirstMVCProject.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Senha { get; set; }
        public string Email { get; set; }
        public EnumPerfilUsuario Perfil { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}