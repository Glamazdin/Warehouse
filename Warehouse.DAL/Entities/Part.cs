using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.DAL
{
    public class Part
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PartId { get; set; }
        [Required]
        public string NomenclatureCode { get; set; }
        [Required]
        public string PartName { get; set; }
        public double Quantity { get; set; }
        public bool Special { get; set; }
        [Required]
        public DateTime ProductionDate { get; set; }

        public DateTime? RemovalDate { get; set; }

        [Required]
        [ForeignKey("StoreKeeper")]
        public int StoreKeeperId { get; set; }
        public StoreKeeper StoreKeeper { get; set; }
    }
}
