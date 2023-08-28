using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace interrapidisimo.Models
{
    [Table("Teacher")]
    public class Teacher
    {
        public int Id {get; set;}
        public string? FullName {get; set;}
    }
}