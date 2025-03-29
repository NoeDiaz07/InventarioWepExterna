using AutoMapper;
using InventarioWepExterna.Models;
using Microsoft.Extensions.Options;

namespace InventarioWepExterna.DTO.BookAutoMapp
{
    public class BookAutoMapp : Profile
    {
        public BookAutoMapp()
        {
            CreateMap<Book, CreateBookDTO>()
                    .ForMember(dest => dest.Author, options => options.MapFrom(dest => dest.Author))
                    .ForMember(dest => dest.Title, Options => Options.MapFrom(dest => dest.Title))
                    .ReverseMap();
    }
    }
}
