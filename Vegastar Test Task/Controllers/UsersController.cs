using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vegastar_Test_Task.Models;

namespace Vegastar_Test_Task.Controllers
{
    [ApiController]
    [Route("Users")]
    public class UsersController : Controller
    {
        private readonly UserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users
                        .Include(g => g.UserGroup)
                        .Include(st => st.UserState)
                        .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users
                            .Include(g => g.UserGroup)
                            .Include(st => st.UserState)
                            .FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }


        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDTO user)
        {
            if (GlobalVariables.UsedLogins.Contains(user.Login)
                || _context.Users.Where(u => u.Login == user.Login).Any())
            {
                return BadRequest($"Login {user.Login} is taken by another user");
            }

            if(_context.Users.Where(u => u.UserGroup.Code == GroupOption.Admin
                && u.UserState.Code != StateOption.Blocked).Any()
                && user.UserGroupId == GroupOption.Admin)
            {
                return BadRequest("User with Admin role already exists");
            }

            GlobalVariables.UsedLogins.Add(user.Login);

            var userNew = new User { Login = user.Login,
                            Password = user.Password,
                            CreatedDate = DateTime.UtcNow,
                            UserId = _context.Users.Count() + 1,
                            UserState = _context.UserStates.First(state => state.Code == StateOption.Active),
                            UserGroup = _context.UserGroups.First(group => group.Code == user.UserGroupId)};


            Thread.Sleep(5000);
            _context.Users.Add(userNew);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = userNew.UserId }, user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            { 
                return NotFound();
            }

            user.UserState = _context.UserStates.First(state => state.Code == StateOption.Blocked);
            await _context.SaveChangesAsync();

            return Ok(user);
        }
    }
}
