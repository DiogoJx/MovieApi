using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Dtos
{
    public class ReadEnderecoDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Logradouro { get; set; }
        [Required]
        public int Numero { get; set; }

    }
}
