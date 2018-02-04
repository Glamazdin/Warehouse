using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions opt): base(opt)
        {
            Database.EnsureCreated();
            PopulateDb().Wait();
        }

        public DbSet<Part> Parts { get; set; }
        public DbSet<StoreKeeper> StoreKeepers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        private async Task PopulateDb()
        {
            var full = await Parts.AnyAsync();

            if (!full)
            {
                StoreKeepers.AddRange(new StoreKeeper[] {
                    new StoreKeeper{Name="Кладовщик 1"},
                    new StoreKeeper{Name="Кладовщик 2"},
                    new StoreKeeper{Name="Кладовщик 2"}
                });
                await SaveChangesAsync();

                var keeper1 = await StoreKeepers.FirstAsync(k => k.Name == "Кладовщик 1");

                List<Part> parts = new List<Part>
                {
                    new Part{ NomenclatureCode="ABC-123456789", PartName="Деталь 1", Quantity=2, ProductionDate=new DateTime(2017,2,11)},
                    new Part{ NomenclatureCode="VTR-789324989", PartName="Деталь 2", Quantity=1, ProductionDate=new DateTime(2017,5,10)},
                    new Part{ NomenclatureCode="LOW-983578274", PartName="Деталь 3", Quantity=4, ProductionDate=new DateTime(2016,6,20)}

                };
                parts.ForEach(p => keeper1.Parts.Add(p));
                
                var keeper2 = await StoreKeepers.FirstAsync(k => k.Name == "Кладовщик 2");
                parts = new List<Part>
                { 
                    new Part { NomenclatureCode = "BNT-478924648", PartName = "Деталь 4", Quantity = 2, ProductionDate = new DateTime(2016, 12, 01) },
                    new Part { NomenclatureCode = "JYR-103348048", PartName = "Деталь 5", Quantity = 1, ProductionDate = new DateTime(2017, 1, 25) }
                };

                parts.ForEach(p => keeper2.Parts.Add(p));

                await SaveChangesAsync();
            }
        }
    }
}
