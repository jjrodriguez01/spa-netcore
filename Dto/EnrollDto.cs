using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace interrapidisimo.Dto
{
    public class EnrollDto
    {
        [Required]
        public string? UserId {get; set;}

        [Required]
        public int SubjectId {get; set;}
    }
}