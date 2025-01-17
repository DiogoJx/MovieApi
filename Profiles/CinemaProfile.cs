﻿using AutoMapper;
using WebApplication1.Data.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Profiles;

public class CinemaProfile : Profile
{   

    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDto>();
        CreateMap<UpdateCinemaDto, Cinema>();

    }

 

}
