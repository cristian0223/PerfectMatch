using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectMatch.API.Data;
using PerfectMatch.Shared.Entities;
using Microsoft.Extensions.Logging;


namespace PerfectMatch.API.Controllers
{
    [ApiController]
    [Route("/api/Comment")]
    public class CommentController: ControllerBase
    {

        private readonly DataContext _context;

        public CommentController(DataContext context)
        {
            _context = context;
        }

        //Get con lista
        //Select * From owners

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Comments.ToListAsync());

        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            //200 Ok
            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        //POST (INGRESAR PERFIL)
        [HttpPost]
        public async Task<ActionResult> Post(Comment comment)
        {
            _context.Add(comment);
            await _context.SaveChangesAsync();
            return Ok(comment);
        }

    }
}
