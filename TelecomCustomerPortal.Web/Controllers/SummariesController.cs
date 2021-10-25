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
    public class SummariesController : ControllerBase
    {
        private readonly TelecomCustomerPortalContext _context;

        public SummariesController(TelecomCustomerPortalContext context)
        {
            _context = context;
        }

        // GET: api/Summaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Summary>>> GetSummary()
        {
            return await _context.Summary.ToListAsync();
        }

        // GET: api/Summaries/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<Summary>>> GetSummary(int Id)
        {
            var summary = await _context.Summary.FromSqlRaw("EXEC dbo.GetPlansDeviceByUserID {0}", Id).ToListAsync();
            //var summary = await _context.Summary.FindAsync(id);

            if (summary == null)
            {
                return NotFound();
            }

            return summary;
        }

        // PUT: api/Summaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSummary(int id, Summary summary)
        //{
        //    if (id != summary.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(summary).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SummaryExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Summaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        

        [HttpPost]
        public async Task<ActionResult<UserPlanDevice>> PostSummary(UserPlanDevice userplandevice)
        {
            _context.UserPlanDevice.Add(userplandevice);
            await _context.SaveChangesAsync();
            return userplandevice;
            //return CreatedAtAction("GetUserPlanDevice", new { id = userplandevice.Id }, userplandevice);
        }

        //// DELETE: api/Summaries/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteSummary(int id)
        //{
        //    var summary = await _context.Summary.FindAsync(id);
        //    if (summary == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Summary.Remove(summary);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool SummaryExists(int id)
        //{
        //    return _context.Summary.Any(e => e.Id == id);
        //}
    }
}
