using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Dtos
{
    public class CreateCinemaDto
    {

        [Required(ErrorMessage = "O campo nome é Obrigatório")]      
        public string Nome { get; set; }

        public int EnderecoId {  get; set; }



    }
}
