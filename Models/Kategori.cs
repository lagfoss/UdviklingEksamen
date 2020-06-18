using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UdviklingEksamen.Models
{
    public class Kategori
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Navn { get; set; }

        [Required]
        public string Beskrivelse { get; set; }
    }
}
