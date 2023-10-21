using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectMatch.API.Data;
using PerfectMatch.Shared.Entities;
using PerfectMatch.API.Data;
using Microsoft.Extensions.Logging;


namespace PerfectMatch.API.Controllers
{
    [ApiController]
    [Route("/api/Event")]
    public class EventController: ControllerBase
    {

        private readonly DataContext _context;

        public EventController(DataContext context)
        {
            _context = context;
        }

        //Get con lista
        //Select * From owners

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Events.ToListAsync());

        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            //200 Ok
            var even = await _context.Events.FirstOrDefaultAsync(x => x.Id == id);

            if (even == null)
            {
                return NotFound();
            }

            return Ok(even);
        }

        //POST (INGRESAR PERFIL)
        [HttpPost]
        public async Task<ActionResult> Post(Event even)
        {
            _context.Add(even);
            await _context.SaveChangesAsync();
            return Ok(even);
        }

    }
}
