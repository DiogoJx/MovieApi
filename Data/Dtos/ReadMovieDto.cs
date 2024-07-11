using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.Dtos
{
    public class ReadMovieDto
    {
        public string Title { get; set; }

        public string Gender { get; set; }

        public string Director { get; set; }
        public int Duration { get; set; }

        public DateTime ConsultationTime { get; set; } = DateTime.Now;
    }
}
