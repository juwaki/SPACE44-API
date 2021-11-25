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
    public class DataController : BaseApiController
    {
        private DataContext _context;
        public DataController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        [AllowAnonymous]
        public async  Task<ActionResult<IEnumerable<Space44Data>>> GetData() 
        {

            return await _context.SpaceData.ToListAsync();
        }

    }
}