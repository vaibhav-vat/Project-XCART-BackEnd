using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XCart.DAL;
using XCart.DBEntities;

namespace XCartBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class USERSController : ControllerBase
    {
        private readonly DbXCART _context;

        public USERSController(DbXCART context)
        {
            _context = context;
        }

        // GET: api/USERS
        [HttpGet]
        public IEnumerable<USERS> GetUSERS()
        {
            return _context.USERS;
        }

        // GET: api/USERS/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUSERS([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var uSERS = await _context.USERS.FindAsync(id);

            if (uSERS == null)
            {
                return NotFound();
            }

            return Ok(uSERS);
        }

        // PUT: api/USERS/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUSERS([FromRoute] int id, [FromBody] USERS uSERS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uSERS.UserId)
            {
                return BadRequest();
            }

            _context.Entry(uSERS).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USERSExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/USERS
        [HttpPost]
        public async Task<IActionResult> PostUSERS( USERS uSERS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.USERS.Add(uSERS);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUSERS", new { id = uSERS.UserId }, uSERS);
        }

        // DELETE: api/USERS/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUSERS([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var uSERS = await _context.USERS.FindAsync(id);
            if (uSERS == null)
            {
                return NotFound();
            }

            _context.USERS.Remove(uSERS);
            await _context.SaveChangesAsync();

            return Ok(uSERS);
        }

        private bool USERSExists(int id)
        {
            return _context.USERS.Any(e => e.UserId == id);
        }
    }
}