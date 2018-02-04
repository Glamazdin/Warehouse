using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.DAL;
using Warehouse.Models;
using AutoMapper;

namespace Warehouse.Services
{
    public class PartsService
    {
        IUnitOfWork unitOfWork;

        public PartsService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public IEnumerable<PartListViewModel> GetPatsList()
        {           

            var parts = unitOfWork.PartRepositoy.Get(null, p=>p.OrderBy(item=>item.NomenclatureCode), "StoreKeeper");
            return Mapper.Map<IEnumerable<PartListViewModel>>(parts);
        }


    }
}
