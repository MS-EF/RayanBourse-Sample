using Application.Products.Commands.Create;
using Application.Products.Queries.GetAll;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<string, string>().ConstructUsing(str => (str ?? "").Trim());


            CreateMap<Product, ProductDTO>()
                .ForMember(q => q.AppUserName, q => q.MapFrom(q => q.AppUser.UserName));


            CreateMap<CreateProduct, Product>()
                .ForMember(q => q.ProduceDate, q => q.MapFrom(q => DateTime.Now));

        }
    }
}
