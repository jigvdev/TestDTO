using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestDTO.Context;
using TestDTO.Entities;
using TestDTO.Models;

namespace TestDTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        public IMapper Mapper { get; }
        private readonly ApplicationDbContext context;

        public AutoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            Mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorDTO>>> Get()
        {
            var autores = await context.Autores.ToListAsync();
            var autoresDTO = Mapper.Map<List<AutorDTO>>(autores);
            return autoresDTO;
        }


        [HttpGet("{id}", Name = "GetAutor")]
        public async Task<ActionResult<AutorDTO>> Get(int id)
        {
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);

            if (autor == null)
                return NotFound();

            var autorDTO = Mapper.Map<AutorDTO>(autor);

            return autorDTO;
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AutorCreacionDTO autorCreacion)
        {
            var autor = Mapper.Map<Autor>(autorCreacion);
            context.Add(autor);
            await context.SaveChangesAsync();
            var autorDTO = Mapper.Map<AutorDTO>(autor);
            return new CreatedAtRouteResult("GetAutor", new { id = autor.Id }, autorDTO);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] AutorCreacionDTO autorCreacionDTO, int id)
        {
            var autor = Mapper.Map<Autor>(autorCreacionDTO);
            autor.Id = id;

            context.Entry(autor).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<Autor> patchDocument)
        {
            if (patchDocument == null)
                return BadRequest();

            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);
            if (autor == null)
                return BadRequest();

            patchDocument.ApplyTo(autor, ModelState);
            var isValid = TryValidateModel(autor);

            if (!isValid)
                return BadRequest(ModelState);

            await context.SaveChangesAsync();

            return Ok();
        }

    }
}
