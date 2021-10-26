using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TelecomCustomerPortal.Data;
using TelecomCustomerPortal.Domain;

namespace TelecomCustomerPortal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersPlansController : ControllerBase
    {
        private readonly TelecomCustomerPortalContext _context;

        public UsersPlansController(TelecomCustomerPortalContext context)
        {
            _context = context;
        }

        // GET: api/UsersPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersPlans>>> GetUsersPlans()
        {
            return await _context.UsersPlans.ToListAsync();
        }

        // GET: api/UsersPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersPlans>> GetUsersPlans(int id)
        {
            var usersPlans = await _context.UsersPlans.FindAsync(id);

            if (usersPlans == null)
            {
                return NotFound();
            }

            return usersPlans;
        }

        // PUT: api/UsersPlans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersPlans(int id, UsersPlans usersPlans)
        {
            if (id != usersPlans.Id)
            {
                return BadRequest();
            }

            _context.Entry(usersPlans).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersPlansExists(id))
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

        // POST: api/UsersPlans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsersPlans>> PostUsersPlans(UsersPlans usersPlans)
        {
            _context.UsersPlans.Add(usersPlans);
            await _context.SaveChangesAsync();
            return usersPlans;
        }

        // DELETE: api/UsersPlans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsersPlans(int id)
        {
            var usersPlans = await _context.UsersPlans.FindAsync(id);
            if (usersPlans == null)
            {
                return NotFound();
            }

            _context.UsersPlans.Remove(usersPlans);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersPlansExists(int id)
        {
            return _context.UsersPlans.Any(e => e.Id == id);
        }
    }
}
