using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TelecomCustomerPortal.Data;
using TelecomCustomerPortal.Domain;


namespace TelecomCustomerPortal.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TelecomCustomerPortalContext _context;

        public UsersController(TelecomCustomerPortalContext context)
        {
            _context = context;

        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        //public List<User> LogIn(string email)
        //{
            
            

        //    List<User> user;

        //    //user = _context.User.Where(p => (p.Email == email && p.Password == password)).ToList();
        //   // user = _context.User.Where(p => p.Email == email).ToList();
        //    user = _context.User.Where(p => p.Email == email).ToList();



        //    return user;

            
        //}

      /*  public List<User> LogIn(string email,string password)
        {
            
            

            List<User> user;

            //user = _context.User.Where(p => (p.Email == email && p.Password == password)).ToList();
            user = _context.User.Where(p => p.Email == email).ToList();



            return user;

            
        }*/
       

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            
            //var aa = _context.UsersPlansDevices.Where(p => p.UserId == id).ToList();
            //foreach (var person in aa)
            //{
            //    Console.WriteLine(person.Id);
            //    Console.WriteLine(person.PlanId);
            //    var person2 = _context.Plan.Find(person.PlanId);
            //    plans.Add(person2);
            //    Console.WriteLine(person.PhoneNumber);                
            //}
            var user = await _context.User.FindAsync(id);
            
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost("Login")]
        public async Task<ActionResult<User>> LoginUser(User user)
        {          
            var tempUser = _context.User.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            if (tempUser == null)
            {
                //Not Authenticated
                return tempUser;
            }

            return tempUser;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User newuser)
        {
            

            _context.User.Add(newuser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = newuser.Id }, newuser);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
