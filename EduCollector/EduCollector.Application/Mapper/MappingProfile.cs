using AutoMapper;
using EduCollector.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCollector.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post,PostInListViewModel>().ReverseMap();
            CreateMap<Post, PostDetailViewModel>().ReverseMap();
            CreateMap<Category, CategoryDto>();

            CreateMap<Category, CategoryInListViewModel>();
            CreateMap<Category, CategoryPostDto>();
            CreateMap<Category, CategoryPostListViewModel>();

            CreateMap<Post, CreatedPostCommand>().ReverseMap();
            CreateMap<Post, UpdatePostCommand>().ReverseMap();
            CreateMap<Post, DeletePostCommand>().ReverseMap();

            CreateMap<Category, CreatedCategoryCommand>().ReverseMap();

            CreateMap<Webinar, WebinarsByDateViewModel>().ReverseMap();

            CreateMap<Webinar, CreatedWebinarCommand>().ReverseMap();
            CreateMap<Webinar, WebinarViewModel>().ReverseMap();

            CreateMap<Webinar, UpdateWebinarCommand>().ReverseMap();
        }
    }
}
