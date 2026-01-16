using FirstMVCProject.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstMVCProject.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do contato é obrigatório")]
        public string Nome { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [Required]
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmarSenha { get; set; }
        public string Email { get; set; }
        public EnumPerfilUsuario? Perfil { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}