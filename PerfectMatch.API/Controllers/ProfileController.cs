using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectMatch.API.Data;
using PerfectMatch.Shared.Entities;
using PerfectMatch.API.Data;

namespace PerfectMatch.API.Controllers
{
    [ApiController]
    [Route("/api/Profile")]
    public class ProfileController : ControllerBase
    {
        private readonly DataContext _context;

        public ProfileController(DataContext context)
        {
            _context = context;
        }

        //Get con lista
        //Select * From owners

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Profiles.ToListAsync());

        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
                           //200 Ok
            var profile = await _context.Profiles.FirstOrDefaultAsync(x => x.Id == id);

            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        //POST (INGRESAR PERFIL)
        [HttpPost]
        public async Task<ActionResult> Post(Profile profile)
        {
            _context.Add(profile);
            await _context.SaveChangesAsync();
            return Ok(profile);
        }


    }
}
