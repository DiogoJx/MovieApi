using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Dtos
{
    public class UpdateEnderecoDto
    {

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public int Numero {  get; set; }
    }
}
