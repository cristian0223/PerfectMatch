using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectMatch.API.Data;
using PerfectMatch.Shared.Entities;

namespace PerfectMatch.API.Controllers
{

    [ApiController]
    [Route("/api/notification")]
    public class NotificationController: ControllerBase
    {
        private readonly DataContext _context;

        public NotificationController(DataContext context)
        {
            _context = context;
        }

        //Get con lista
        //Select * From owners

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Notifications.ToListAsync());

        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            //200 Ok
            var notification = await _context.Notifications.FirstOrDefaultAsync(x => x.Id == id);

            if (notification == null)
            {
                return NotFound();
            }

            return Ok(notification);
        }

        //POST (CREAR)
        [HttpPost]
        public async Task<ActionResult> Post(Notification notification)
        {
            _context.Add(notification);
            await _context.SaveChangesAsync();
            return Ok(notification);
        }

        //PUT ACTUALIZAR PERFIL
        [HttpPut]
        public async Task<ActionResult> Put(Notification notification)
        {
            _context.Update(notification);
            await _context.SaveChangesAsync();
            return Ok(notification);
        }

        //DELETE (ELIMINAR)

        [HttpDelete ("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var FilaAfectada = await _context.Notifications
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            if(FilaAfectada == 0)
            {

                return NotFound();
            }
            return NoContent();
        }




    }
}
