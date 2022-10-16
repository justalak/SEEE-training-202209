using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Model
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
