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


            CreateMap<Product, ProductDTO>();
                

        }
    }
}
