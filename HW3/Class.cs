using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    internal class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string Teacher_Name { get; set; }

        public Class()
        {

        }
        public Class(int id, string classname, string teacher_Name)
        {
            this.Id = id;
            this.ClassName = classname;
            this.Teacher_Name = teacher_Name;
        }   
    }
}
