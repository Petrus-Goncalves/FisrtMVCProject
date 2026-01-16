using FirstMVCProject.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstMVCProject.Models.User
{
    public class EditUserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O login do usuário é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O email do usuário é obrigatório")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmarSenha { get; set; }

        [Required(ErrorMessage = "O perfil do usuário é obrigatório")]
        public EnumPerfilUsuario? Perfil { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}