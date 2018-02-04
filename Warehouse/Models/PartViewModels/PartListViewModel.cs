using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class PartListViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        public string NomenclatureCode { get; set; }       
        public string PartName { get; set; }
        public double Quantity { get; set; }
        public bool Special { get; set; }        
        public string ProductionDate { get; set; }
        public string RemovalDate { get; set; }      
        public string StoreKeeper { get; set; }
    }
}
