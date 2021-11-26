using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.DTOs
{
    public class CreateDTO
    {
        [Required]
        public string First { get; set; }

        [Required]
        public string Last { get; set; }
        
        [Required]       
        public string Email { get; set; }
        
        [Required]
        public string Phone { get; set; }
        
        [Required]
        public string Location { get; set; }

        [Required]
        public string Hobby { get; set; }
    }
}