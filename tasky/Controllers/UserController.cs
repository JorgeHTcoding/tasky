using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tasky.Models;
using tasky.DataAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tasky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TaskyDBContext _context;

        public UserController(TaskyDBContext context)
        {
            _context = context;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            if (_context.User == null)
            {
                return NotFound();
            }
            return await _context.User.ToArrayAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            if (_context == null)
            {
                return NotFound();
            }
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUser(UserModel user)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'TaskyDBContext.User is n ull'");
            }
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = user.Id_User }, user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> PutUser(int id, UserModel user)
        {
            if (id != user.Id_User)
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

        private bool UserExists(int id)
        {
            throw new NotImplementedException();
        }



        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}