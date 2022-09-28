using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    public class Teacher
    {
        public string name { get; set; }
        public int TeacherId { get; set; }
        public Teacher()
        {

        }

        public Teacher(int TeacherId, string name)
        {
            this.TeacherId = TeacherId;
            this.name = name;

        }
    }
}
