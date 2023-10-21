using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectMatch.API.Data;
using PerfectMatch.Shared.Entities;
using PerfectMatch.API.Data;

namespace PerfectMatch.API.Controllers
{
    [ApiController]
    [Route("/api/Appointment")]
    public class AppointmentController : ControllerBase
    {
        private readonly DataContext _context;

        public AppointmentController(DataContext context)
        {
            _context = context;
        }

        //Get con lista
        //Select * From owners

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Appointments.ToListAsync());

        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            //200 Ok
            var appointment = await _context.Appointments.FirstOrDefaultAsync(x => x.Id == id);

            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        //POST (INGRESAR PERFIL)
        [HttpPost]
        public async Task<ActionResult> Post(Appointment appointment)
        {
            _context.Add(appointment);
            await _context.SaveChangesAsync();
            return Ok(appointment);
        }

    }
}
