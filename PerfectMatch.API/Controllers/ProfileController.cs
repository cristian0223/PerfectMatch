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
    [Route("/api/profile")]
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

        //POST (CREAR)
        [HttpPost]
        public async Task<ActionResult> Post(Profile profile)
        {
            _context.Add(profile);
            await _context.SaveChangesAsync();
            return Ok(profile);
        }

        //PUT (ACTUALIZAR)
        [HttpPut]
        public async Task<ActionResult> Put(Profile profile)
        {
             _context.Update(profile);
            await _context.SaveChangesAsync();
            return Ok(profile);
        }

        //Delete (ELIMINAR)
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filaAfectada = await _context.Profiles
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            if (filaAfectada == 0)
            {

                return NotFound();
            }
            return NoContent();
        }
        
        

    }
}
