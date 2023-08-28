using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace interrapidisimo.Models
{
    [Table("UserSubject")]
    public class UserSubject
    {
        public string? UserId {get; set;}
        public int SubjectId {get; set;}
        public ApplicationUser? User {get; set;}
        public Subject? subject {get; set;}
    }
}