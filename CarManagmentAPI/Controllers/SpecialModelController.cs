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
    public class SpecialModelController : ControllerBase
    {
        private readonly MyDbContext _context;
        public SpecialModelController(MyDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateModel(SpModelDTO modelDto)
        {
            SpecialModel specialModel = new SpecialModel();
            specialModel.Name = modelDto.Name;
            specialModel.Year = modelDto.Year;
            specialModel.Color = modelDto.Color;

            await _context.SpecialModels.AddAsync(specialModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<List<SpModelDTO>>> GetModel()
        {
            var model = _context.SpecialModels.Select(m => new SpModelDTO
            {

                Name = m.Name,
                Year = m.Year,
                Color = m.Color,

            }).ToListAsync();

            return await model;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SpModelDTO model)
        {
            var mdl = await _context.SpecialModels.FindAsync(id);
            if (mdl == null)
            {
                return NotFound();
            }
            mdl.Name = model.Name;
            mdl.Year = model.Year;
            mdl.Color = model.Color;

            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var md = await _context.SpecialModels.FindAsync(id);
            
            if (md == null)
            {
                return NotFound();
            }
            _context.SpecialModels.Remove(md);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }

}

