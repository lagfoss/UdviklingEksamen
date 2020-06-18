using UdviklingEksamen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdviklingEksamen.Data
{
    public interface IProdukterRepo
    {
        bool SaveChanges();

        IEnumerable<Produkt> GetAllProdukts();
        Produkt GetProduktById(int id);
        void CreateProdukt(Produkt pdt);
        void UpdateProdukt(Produkt pdt);
        void DeleteProdukt(Produkt pdt);
    }
}
