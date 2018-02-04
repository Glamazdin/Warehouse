using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.DAL;
using Warehouse.Models;
using AutoMapper;

namespace Warehouse.Services
{
    public static class MapperConfiguration
    {
        public static void Configue()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Part, PartListViewModel>()
                    .ForMember(P => P.Id, opt => opt.MapFrom(src => src.PartId))
                    .ForMember(p => p.StoreKeeper, opt => opt.MapFrom(src => src.StoreKeeper.Name))
                    .ForMember(p => p.ProductionDate, opt => opt.MapFrom(src => src.ProductionDate.ToLongDateString()))
                    .ForMember(p => p.RemovalDate,
                                    opt => opt.MapFrom(src => src.RemovalDate == null
                                                ? ""
                                                : src.RemovalDate.Value.ToLongDateString()));
            });
        }
    }
}
