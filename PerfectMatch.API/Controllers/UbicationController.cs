using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectMatch.API.Data;
using PerfectMatch.Shared.Entities;
namespace PerfectMatch.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("/api/ubication")]
    public class UbicationController: ControllerBase
    {
        private readonly DataContext _context;

        public UbicationController(DataContext context)
        {
            _context = context;
        }

        //Get con lista
        //Select * From owners

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Ubications.ToListAsync());

        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            //200 Ok
            var ubication = await _context.Ubications.FirstOrDefaultAsync(x => x.Id == id);

            if (ubication == null)
            {
                return NotFound();
            }

            return Ok(ubication);
        }

        //POST (CREAR)
        [HttpPost]
        public async Task<ActionResult> Post(Ubication ubication)
        {
            _context.Add(ubication);
            await _context.SaveChangesAsync();
            return Ok(ubication);
        }

        //PUT (ACTUALIZAR)
        [HttpPut]
        public async Task<ActionResult> Put(Ubication ubication)
        {
            _context.Update(ubication);
            await _context.SaveChangesAsync();
            return Ok(ubication);
            
        }
        // Delete (Eliminar)
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filaAfectada = await _context.Ubications
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
