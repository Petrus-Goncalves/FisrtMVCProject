using AspNetCoreGeneratedDocument;
using System.ComponentModel.DataAnnotations;

namespace FirstMVCProject.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do contato é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email do contato é obrigatório")]
        [EmailAddress(ErrorMessage =$"O email informado não é válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O celular do contato é obrigatório")]
        [Phone(ErrorMessage ="O celular informado não é válido")]
        public string Celular { get; set; }
    }
}