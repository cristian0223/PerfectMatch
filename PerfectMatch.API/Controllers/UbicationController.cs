﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfectMatch.API.Data;
using PerfectMatch.Shared.Entities;

namespace PerfectMatch.API.Controllers
{
    [ApiController]
    [Route("/api/Ubication")]
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

        //POST (INGRESAR PERFIL)
        [HttpPost]
        public async Task<ActionResult> Post(Ubication ubication)
        {
            _context.Add(ubication);
            await _context.SaveChangesAsync();
            return Ok(ubication);
        }

    }
}
