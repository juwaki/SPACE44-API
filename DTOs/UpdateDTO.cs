using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.DTOs
{
    public class UpdateDTO
    {
        public string First { get; set; }

        public string Last { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public string Location { get; set; }

        public string Hobby { get; set; }
    }
}