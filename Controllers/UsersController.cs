using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CRUD.Data;
using CRUD.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{

    public class UsersController : BaseApiController
    {
        private DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        [AllowAnonymous]
        public async  Task<ActionResult<IEnumerable<AppUser>>> GetUsers() 
        {

            return await _context.Users.ToListAsync();
        }

        // api/users/3
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id) 
        {
            return await _context.Users.FindAsync(id);

        }
    }
}