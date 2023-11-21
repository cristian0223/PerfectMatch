using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectMatch.API.Data;
using PerfectMatch.Shared.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace PerfectMatch.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        //POST (CREAR)
        [HttpPost]
        public async Task<ActionResult> Post(Appointment appointment)
        {
            _context.Add(appointment);
            await _context.SaveChangesAsync();
            return Ok(appointment);
        }

        //PUT (ACTUALIZAR)
        [HttpPut]
        public async Task<ActionResult> Put(Appointment appointment)
        {
            _context.Update(appointment);
            await _context.SaveChangesAsync();
            return Ok(appointment);
        }

        //DELETE (ELIMINAR)
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filaAfectada = await _context.Appointments
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            if(filaAfectada == 0)
            {

                return NotFound();
            }
            return NoContent();


        }

    }
}
