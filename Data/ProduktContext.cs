using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdviklingEksamen.Models;

namespace UdviklingEksamen.Data
{
    public class ProduktContext : DbContext
    {
        public ProduktContext(DbContextOptions<ProduktContext> opt) : base(opt)
        {

        }

        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Produkt> Produkts { get; set; }

    }
}
