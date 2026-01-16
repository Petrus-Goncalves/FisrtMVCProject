using System.ComponentModel.DataAnnotations;

namespace FirstMVCProject.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O login é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }
    }
}