using System;
using System.Collections.Generic;

#nullable disable

namespace StudentManage.Model
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public int? Course { get; set; }
    }
}
