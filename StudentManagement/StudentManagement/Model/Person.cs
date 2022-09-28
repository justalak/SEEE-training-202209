using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model
{
    internal class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Person()
        {

        }

        public Person(string Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

    }
}
