using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model
{
    internal class Teacher : Person
    {
        public Teacher()
        {

        }

        public Teacher(string Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
