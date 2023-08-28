using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace interrapidisimo.Models
{
    [Table("Subject")]
    public class Subject
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public int CreditsNumber {get; set;} = 3;
        public int TeacherId {get; set;}
        public Teacher? Teacher {get; set;}
        public ICollection<UserSubject> UserSubjects { get; set; }

    }
}