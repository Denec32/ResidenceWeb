using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResidenceService.Dto;
using ResidenceService.Models;

namespace ResidenceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentsController : ControllerBase
    {
        private ResidenceDbContext context;

        public ResidentsController(ResidenceDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResidentDto>>> GetResidents()
        {
            if (context.Residents is null)
            {
                return BadRequest();
            }

            var residents = await GetResidentsFromContext().ToListAsync();
            return Ok(residents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResident(int id)
        {
            if (context.Residents is null)
            {
                return BadRequest();
            }

            var resident = await GetResidentsFromContext().FirstOrDefaultAsync(r => r.Id == id);

            if (resident is null) {
                return NotFound();
            }

            return Ok(resident);
        }

        private IQueryable<ResidentDto> GetResidentsFromContext() 
        {
            return from resident in context.Residents
                               join residence in context.Residences on resident.Id equals residence.ResidentId
                               join house in context.Houses on residence.HouseId equals house.Id
                               select new ResidentDto()
                               {
                                   Id = resident.Id,
                                   HouseNumber = house.Number,
                                   Name = resident.SecondName + " " + resident.FirstName + " " + resident.FatherName,
                                   PassportCode = resident.PassportCode
                               };
        }
    }
}
