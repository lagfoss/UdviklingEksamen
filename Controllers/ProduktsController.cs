using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdviklingEksamen.Data;
using UdviklingEksamen.Models;
using Microsoft.AspNetCore.JsonPatch;
using UdviklingEksamen.Dtos;
using AutoMapper;

namespace UdviklingEksamen.Controllers
{
    [Route("api/produkts")]
    [ApiController]
    public class ProduktsController : ControllerBase
    {
        private readonly IProdukterRepo _repository;
        private readonly IMapper _mapper;

        public ProduktsController(IProdukterRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/produkts
        [HttpGet]
        public ActionResult<IEnumerable<ProduktReadDto>> GetAllProdukts()
        {
            var produktItems = _repository.GetAllProdukts();

            return Ok(_mapper.Map<IEnumerable<ProduktReadDto>>(produktItems));
        }

        //GET api/produkts/{id}
        [HttpGet("{id}", Name = "GetProduktById")]
        public ActionResult<ProduktReadDto> GetProduktById(int id)
        {
            var produktItem = _repository.GetProduktById(id);

            if (produktItem != null)
            {
                return Ok(_mapper.Map<ProduktReadDto>(produktItem));
            }

            return NotFound();

        }

        //POST api/produkts
        [HttpPost]
        public ActionResult<ProduktReadDto> CreateProdukt(ProduktCreateDto produktCreateDto)
        {
            var produktModel = _mapper.Map<Produkt>(produktCreateDto);
            _repository.CreateProdukt(produktModel);
            _repository.SaveChanges();

            var produktReadDto = _mapper.Map<ProduktReadDto>(produktModel);

            return CreatedAtRoute(nameof(GetProduktById), new { Id = produktReadDto.Id }, produktReadDto);
        }

        //PUT api/produkts/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateProdukt(int id, ProduktUpdateDto produktUpdateDto)
        {
            var produktFromRepo = _repository.GetProduktById(id);
            if (produktFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(produktUpdateDto, produktFromRepo);

            _repository.UpdateProdukt(produktFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/produkts/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialProduktUpdate(int id, JsonPatchDocument<ProduktUpdateDto> patchDoc)
        {
            var produktFromRepo = _repository.GetProduktById(id);
            if (produktFromRepo == null)
            {
                return NotFound();
            }

            var produktToPatch = _mapper.Map<ProduktUpdateDto>(produktFromRepo);
            patchDoc.ApplyTo(produktToPatch, ModelState);

            if (!TryValidateModel(produktToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(produktToPatch, produktFromRepo);

            _repository.UpdateProdukt(produktFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/produkts/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteProdukt(int id)
        {
            var produktFromRepo = _repository.GetProduktById(id);
            if (produktFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteProdukt(produktFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
