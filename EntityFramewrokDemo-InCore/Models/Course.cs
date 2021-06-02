using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramewrokDemo_InCore.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
    }

}
