using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectMatch.API.Data;
using PerfectMatch.Shared.Entities;
using Microsoft.Extensions.Logging;

namespace PerfectMatch.API.Controllers
{
    [ApiController]
    [Route("/api/Message")]
    public class MesaggeController: ControllerBase
    {

        private readonly DataContext _context;

        public MesaggeController(DataContext context)
        {
            _context = context;
        }

        //Get con lista
        //Select * From owners

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Messages.ToListAsync());

        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            //200 Ok
            var message = await _context.Messages.FirstOrDefaultAsync(x => x.Id == id);

            if (message == null)
            {
                return NotFound();
            }

            return Ok(message);
        }

        //POST (INGRESAR PERFIL)
        [HttpPost]
        public async Task<ActionResult> Post(Message message)
        {
            _context.Add(message);
            await _context.SaveChangesAsync();
            return Ok(message);
        }

    }
}
