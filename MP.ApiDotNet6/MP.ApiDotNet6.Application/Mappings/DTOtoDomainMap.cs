using System;
using AutoMapper;
using MP.ApiDotNet6.Application.DTOs;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Application.Mappings
{
    public class DTOtoDomainMap : Profile 
    {
        public DTOtoDomainMap()
        {
            CreateMap<PersonDTO, Person>();
            CreateMap<ProductDTO, Product>();
            
        }
    }
}

