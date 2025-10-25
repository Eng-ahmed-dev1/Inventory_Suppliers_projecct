using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventor_2.Model
{
    class InventoryDB : DbContext
    {
        public InventoryDB(){ }
        public InventoryDB(DbContextOptions<InventoryDB> options) : base(options){ }

        public DbSet<Products> products { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Suppliers> suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-2008HFE\\SQLEXPRESS;Initial Catalog=InventoryDB;Integrated Security=True;Trust Server Certificate=True");
            }
        }

    }
}
