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
        }
    }
}
