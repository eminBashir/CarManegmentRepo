using CarManagmentAPI.Data.Entity;
using CarManagmentAPI.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly MyDbContext _context;
        public PersonController(MyDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePerson(PersonDTO personDTO)
        {
            Person person = new Person();
            person.Name = personDTO.Name;
            person.Age = personDTO.Age;
            person.SpecialModelId = personDTO.SpecialModelId;

            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<List<PersonDTO>>> GetPerson()
        {
            {
                var persons = await _context.Persons.Include(x => x.SpecialModel).ToListAsync();

                return Ok(persons);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDTO>> GetPersonId(int id)
        {
            var person = await _context.Persons.Include(m => m.SpecialModel).Where(m => m.Id == id).ToListAsync();

            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PersonDTO personDto)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            person.Name = personDto.Name;
            person.Age = personDto.Age;
            person.SpecialModelId = personDto.SpecialModelId;

            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
