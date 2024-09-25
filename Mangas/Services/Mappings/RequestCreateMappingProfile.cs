using AutoMapper;
using manga.Domain.Dtos;
using Mangas.Domain.Entities;

namespace manga.Serivices.Mappings;

public class RequestCreateMappingProfile : Profile
{
    public RequestCreateMappingProfile()
    {
        CreateMap<MangaCreateDTO,Manga>()
        .AfterMap
        (
            (src,dest)=>
            {
                dest.PublicationDate=DateTime.Now;
            }
        );
    }

}