using CityGuide_WebApi.Pagination;
using CityGuide_WebApi.View_Layer;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityGuide_WebApi.MappingModels
{
    public class PaginationMapping : Profile
    {
        public PaginationMapping()
        {
            CreateMap<PaginatedQuery, PaginationFilter>();
        }
    }
}
