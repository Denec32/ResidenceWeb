using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResidenceService.Dto;
using ResidenceService.Models;
using System.Text;

namespace ResidenceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerritoriesController : ControllerBase
    {
        private ResidenceDbContext context;

        public TerritoriesController(ResidenceDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{address}")]
        public async Task<ActionResult<TerritoryDto>> GetTerritory(string address = "")
        {
            if (context.Houses is null)
            {
                return BadRequest();
            }

            string[] adrresses = address.Split(", ");
            TerritoryDto? territory;
            
            // Process address query
            switch (adrresses.Length)
            {
                case 0:
                    territory =  await GetHousesFromContext().FirstOrDefaultAsync();
                    break;
                case 1:
                    territory = await GetHousesFromContext(adrresses[0]).FirstOrDefaultAsync();
                    break;
                case 2:
                    territory = await GetHousesFromContext(adrresses[0], Convert.ToInt32(adrresses[1])).FirstOrDefaultAsync();
                    break;
                default:
                    return UnprocessableEntity();
            }

            if (territory is null) 
            {
                return NotFound();
            }

            return territory;
        }

        private IQueryable<TerritoryDto> GetHousesFromContext(string street = "", int number = 0)
        {
            var houses = from house in context.Houses
                         select house;

            if (street != "")
            {
                houses = houses.Where(h => h.Street == street);
            }
            if (number != 0)
            {
                houses = houses.Where(h => h.Number == number);
            }

            return houses.Select(house => new TerritoryDto()
            {
                Id = house.Id,
                ARCPS = house.ARCPS,
                FTSI = house.FTSI,
                PostCode = house.PostCode
            });
        }
    }
}
