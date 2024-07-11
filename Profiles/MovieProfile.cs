using AutoMapper;
using WebApplication1.Data.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Profiles;

public class MovieProfile : Profile
{

     public MovieProfile() {
        CreateMap<CreateMovieDto, Movie>();
        CreateMap<UpdateMovieDto, Movie>();
        CreateMap<Movie, UpdateMovieDto>();
        CreateMap<Movie, ReadMovieDto>();
     }

}
