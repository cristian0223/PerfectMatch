using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectMatch.API.Data;
using PerfectMatch.Shared.Entities;
using PerfectMatch.API.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;

namespace PerfectMatch.API.Controllers
{
    [ApiController]
    [Route("/api/Post")]
    public class PostController: ControllerBase
    {

        private readonly DataContext _context;

        public PostController(DataContext context)
        {
            _context = context;
        }

        //Get con lista
        //Select * From owners

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Posts.ToListAsync());

        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            //200 Ok
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        //POST (INGRESAR PERFIL)
        [HttpPost]
        public async Task<ActionResult> Post(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
            return Ok(post);
        }

    }
}
