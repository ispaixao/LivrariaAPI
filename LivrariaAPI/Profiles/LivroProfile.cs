using AutoMapper;
using LivrariaAPI.Data.DTOs;
using LivrariaAPI.Models;

namespace LivrariaAPI.Profiles
{
    public class LivroProfile : Profile
    {
        public LivroProfile()
        {
            CreateMap<CreateLivroDTO, Livro>();
            CreateMap<Livro, ReadLivroDTO>();
            CreateMap<UpdateLivroDTO, Livro>();


        }
    }
}
