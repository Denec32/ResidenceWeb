using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResidenceService.Dto;
using ResidenceService.Models;

namespace ResidenceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmptyHousesController : ControllerBase
    {
        private ResidenceDbContext context;

        public EmptyHousesController(ResidenceDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmptyHouseDto>>> GetEmptyHouses()
        {
            if (context.Houses is null) 
            {
                return BadRequest();
            }

            var houses = from h in context.Houses.Where(h => !context.Residences.Any(r => r.HouseId == h.Id))
                         select new EmptyHouseDto()
                         {
                             Id = h.Id,
                             City = h.City,
                             Street = h.Street,
                             Number = h.Number
                         };

            return Ok(await houses.ToListAsync());
        }
    }
}
