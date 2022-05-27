using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        //Add endpoints for all and 1 user 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            //to get the results of a task, make sure the use the "await" keyword.
            return await _context.Users.ToListAsync();
        }

        // api/users/3 this gets the user with id of 3
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            //Dont need to have a var user when we are not going to do anything with it. 
            //We just return the results of the operation. 
            return await _context.Users.FindAsync(id);
        }
    }
}