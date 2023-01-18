using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ActorModel>().ReverseMap();
            CreateMap<Film, FilmModel>().ReverseMap();
            CreateMap<Review, ReviewModel>().ReverseMap();
        }
    }
}
