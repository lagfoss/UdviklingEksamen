using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdviklingEksamen.Models
{
    public class Produkt
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Navn { get; set; }

        [Required]
        public string Beskrivelse { get; set; }

        [Required]
        public string Enhed { get; set; }

        [Required]
        [Display(Name = "Mængde i pakningen")]
        public int AntalPak { get; set; }

        [Required]
        public int Pris { get; set; }

        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
    }
}
