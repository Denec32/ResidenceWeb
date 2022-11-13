using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResidenceService.Dto;
using ResidenceService.Models;

namespace ResidenceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private ResidenceDbContext context;

        public HousesController(ResidenceDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HouseDto>>> GetHousesPopulation()
        {
            if (context.Houses is null)
            {
                return BadRequest();
            }

            var houses = from h in context.Houses
                         select new HouseDto()
                         {
                             Id = h.Id,
                             Number = h.Number,
                             Address = h.City + ", " + h.Street
                         };

            var result = await houses.ToListAsync();

            foreach (var house in result)
            {
                if (house.Number % 2 == 0)
                {
                    var population = context.Residences.Where(r => r.HouseId == house.Id).Count();
                    house.Population = population;
                }
                else
                {
                    house.Population = -1;
                }
            }

            return Ok(result);
        }
    }
}
