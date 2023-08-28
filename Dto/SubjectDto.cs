using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace interrapidisimo.Dto
{
    public class SubjectDto
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public int CreditsNumber {get; set;} = 3;
        public int TeacherId {get; set;}
        public string? TeacherName {get; set;}
    }
}