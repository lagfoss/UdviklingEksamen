using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdviklingEksamen.Dtos;
using UdviklingEksamen.Models;

namespace UdviklingEksamen.Profiles
{
    public class ProduktsProfile : Profile
    {
        public ProduktsProfile()
        {
            //Source -> Target
            CreateMap<Produkt, ProduktReadDto>();
            CreateMap<ProduktCreateDto, Produkt>();
            CreateMap<ProduktUpdateDto, Produkt>();
            CreateMap<Produkt, ProduktUpdateDto>();
        }
    }
}
