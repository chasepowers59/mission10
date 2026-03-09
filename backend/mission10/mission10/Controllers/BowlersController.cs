using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mission10.Data;

namespace mission10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlersController : ControllerBase
    {
        private readonly BowlerDbContext _context;

        public BowlersController(BowlerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBowlers()
        {
            var bowlers = await _context.Bowlers
                .Include(b => b.Team)
                .Where(b => b.Team != null &&
                       (b.Team.TeamName == "Marlins" ||
                        b.Team.TeamName == "Sharks"))
                .Select(b => new
                {
                    FirstName = b.BowlerFirstName,
                    MiddleInitial = b.BowlerMiddleInit,
                    LastName = b.BowlerLastName,
                    TeamName = b.Team!.TeamName,
                    Address = b.BowlerAddress,
                    City = b.BowlerCity,
                    State = b.BowlerState,
                    Zip = b.BowlerZip,
                    Phone = b.BowlerPhoneNumber
                })
                .ToListAsync();

            return Ok(bowlers);
        }
    }
}