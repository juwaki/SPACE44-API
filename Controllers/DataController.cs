using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CRUD.Data;
using CRUD.Entities;
using Microsoft.EntityFrameworkCore;
using CRUD.DTOs;
using CRUD.Interfaces;

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
        

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Space44Data>> GetData(int id) 
        {
            return await _context.SpaceData.FindAsync(id);

        }

        [HttpPost("add")]
        [AllowAnonymous]
        public async Task<ActionResult<CreateDTO>> Register(CreateDTO createDTO)
        {

            if (await EmailExists(createDTO.Email))
            {
                return BadRequest("Email is Taken");
            }

            var add = new Space44Data
            {
                First = createDTO.First.ToLower(),
                Last = createDTO.Last.ToLower(),
                Email = createDTO.Email.ToLower(),
                Phone = createDTO.Phone.ToLower(),
                Location = createDTO.Location.ToLower(),
                Hobby = createDTO.Hobby.ToLower()

                
            };

            _context.SpaceData.Add(add);
            await _context.SaveChangesAsync();

            return new CreateDTO {
                First = add.First,
                Last = add.Last,
                Email = add.Email,
                Phone = add.Phone,
                Location = add.Hobby
            };

        }
       
        private async Task<bool> EmailExists(string email)
        {
            return await _context.SpaceData.AnyAsync(x => x.Email == email.ToLower());
        }

        // [HttpPut("{id}")]
        // public async Task<ActionResult> UpdateData(UpdateDTO updateDto)
        // {

        // }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
        var todoItem = await _context.SpaceData.FindAsync(id);
        if (todoItem == null)
         {
          return NotFound();
         }

         _context.SpaceData.Remove(todoItem);
        await _context.SaveChangesAsync();

         return NoContent();
        }   


    }
}