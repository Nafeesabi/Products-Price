using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Category.Models;

namespace WebApplication7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebItemsController : ControllerBase
    {
        private readonly WebContext _context;

        public WebItemsController(WebContext context)
        {
            _context = context;
            if (!_context.WebItems.Any())
            {

                var webItems = new List<WebItems>
                {

                    new  WebItems { Id = 001, Name="Laptop",PName="Lenovo",Date="27-feb-2023",Price=40000  },
                    new  WebItems { Id = 002, Name="Mobiles",PName="Vivo",Date="02-March-2023",Price=20000 },
                    new  WebItems { Id = 003, Name="Furniture",PName="Sofa",Date="04-March-2023",Price=40000 },
                    new  WebItems { Id = 004, Name="Watch",PName="Titan",Date="27-March-2023",Price=4000 }


                 };
                _context.WebItems.AddRange(webItems);
                _context.SaveChangesAsync();

            }
        }

        // GET: api/WebItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WebItems>>> GetWebItems()
        {
          if (_context.WebItems == null)
          {
              return NotFound();
          }
            return await _context.WebItems.ToListAsync();
        }

        // GET: api/WebItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WebItems>> GetWebItems(long id)
        {
          if (_context.WebItems == null)
          {
              return NotFound();
          }
            var webItems = await _context.WebItems.FindAsync(id);

            if (webItems == null)
            {
                return NotFound();
            }

            return webItems;
        }



        // PUT: api/WebItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWebItems(long id, WebItems webItems)
        {
            if (id != webItems.Id)
            {
                return BadRequest();
            }
            
            _context.Entry(webItems).State = EntityState.Modified;
            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebItemsExists(id))
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

        // POST: api/WebItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WebItems>> PostWebItems(WebItems webItems)
        {
          if (_context.WebItems == null)
          {
              return Problem("Entity set 'WebContext.WebItems'  is null.");
          }
            _context.WebItems.Add(webItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWebItems), new { id = webItems.Id }, webItems);
        }

        // DELETE: api/WebItems/5
        [HttpDelete]
        [Route("DeleteWebItems/{id:long}")]
        public async Task<IActionResult> DeleteWebItems(long id)
        {
            if (_context.WebItems == null)
            {
                return NotFound();
            }
            var webItems = await _context.WebItems.FindAsync(id);
            if (webItems == null)
            {
                return NotFound();
            }

            _context.WebItems.Remove(webItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WebItemsExists(long id)
        {
            return (_context.WebItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
