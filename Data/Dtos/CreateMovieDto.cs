using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Dtos
{
    public class CreateMovieDto
    {

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [StringLength(50, ErrorMessage = "Gender size cannot exceed 50 characters ")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Director is required")]
        public string Director { get; set; }

        [Required(ErrorMessage = "The Duration is required")]
        [Range(70, 600, ErrorMessage = "the durarion must be between 70 minutes and 600 minutes")]
        public int Duration { get; set; }
    }
}
