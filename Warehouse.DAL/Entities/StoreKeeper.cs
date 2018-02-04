using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Warehouse.DAL
{
    public class StoreKeeper
    {
        public StoreKeeper()
        {
            Parts = new List<Part>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StoreKeeperId { get; set; }
        public string Name { get; set; }

        public ICollection<Part> Parts { get; set; }
    }
}
