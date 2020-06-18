using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdviklingEksamen.Models;

namespace UdviklingEksamen.Data
{
    public class SqlProdukterRepo : IProdukterRepo
    {
        private readonly ProduktContext _context;

        public SqlProdukterRepo(ProduktContext context)
        {
            _context = context;
        }

        public void CreateProdukt(Produkt pdt)
        {
            if (pdt == null)
            {
                throw new ArgumentNullException(nameof(pdt));
            }

            _context.Produkts.Add(pdt);
        }

        public void DeleteProdukt(Produkt pdt)
        {
            if (pdt == null)
            {
                throw new ArgumentNullException(nameof(pdt));
            }
            _context.Produkts.Remove(pdt);
        }

        public IEnumerable<Produkt> GetAllProdukts()
        {
            return _context.Produkts.ToList();
        }

        public Produkt GetProduktById(int id)
        {
            return _context.Produkts.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateProdukt(Produkt pdt)
        {

        }
    }
}
