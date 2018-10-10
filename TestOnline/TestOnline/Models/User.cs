using System;
using System.Collections.Generic;
using System.Text;

namespace TestOnline.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserCode { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Bird {get; set; }
        public string Exams { get; set; }
        public int Times { get; set; }
        public int SemesterCode { get; set; }
        public int SubjectCode{ get; set; }
        public bool bLogin { get; set; }
    }
}
