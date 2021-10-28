using System.Collections.Generic;
using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Summary>>> GetSummary()
        {
            return await _context.Summary.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<Summary>>> GetSummary(int Id)
        {
            var summary = await _context.Summary.FromSqlRaw("EXEC dbo.GetPlansDeviceByUserID {0}", Id).ToListAsync();
            if (summary == null)
            {
                return NotFound();
            }
            return summary;
        }

        [HttpPost]
        public async Task<ActionResult<UserPlanDevice>> PostUserPlanDevice(UserPlanDevice userplandevice)
        {
            _context.UserPlanDevice.Add(userplandevice);
            await _context.SaveChangesAsync();
            return userplandevice;
        }

    }
}
