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
    public class UserPlanDevicesController : ControllerBase
    {
        private readonly TelecomCustomerPortalContext _context;

        public UserPlanDevicesController(TelecomCustomerPortalContext context)
        {
            _context = context;
        }

        // GET: api/UserPlanDevices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPlanDevice>>> GetUserPlanDevice()
        {
            return await _context.UserPlanDevice.ToListAsync();
        }

        // GET: api/UserPlanDevices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPlanDevice>> GetUserPlanDevice(int id)
        {
            var userPlanDevice = await _context.UserPlanDevice.FindAsync(id);

            if (userPlanDevice == null)
            {
                return NotFound();
            }

            return userPlanDevice;
        }

        // PUT: api/UserPlanDevices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPlanDevice(int id, UserPlanDevice userPlanDevice)
        {
            if (id != userPlanDevice.Id)
            {
                return BadRequest();
            }

            _context.Entry(userPlanDevice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPlanDeviceExists(id))
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

        // POST: api/UserPlanDevices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserPlanDevice>> PostUserPlanDevice(UserPlanDevice userPlanDevice)
        {
            _context.UserPlanDevice.Add(userPlanDevice);
            await _context.SaveChangesAsync();
            return userPlanDevice;
        }

        // DELETE: api/UserPlanDevices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserPlanDevice(int id)
        {
            var userPlanDevice = await _context.UserPlanDevice.FindAsync(id);
            if (userPlanDevice == null)
            {
                return NotFound();
            }

            _context.UserPlanDevice.Remove(userPlanDevice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserPlanDeviceExists(int id)
        {
            return _context.UserPlanDevice.Any(e => e.Id == id);
        }
    }
}
