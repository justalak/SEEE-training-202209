using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model
{
    internal class Class
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TeacherId { get; set; }

        public Class()
        {

        }

        public Class(string Id,string Name, string TeacherId)
        {
            this.Id = Id;
            this.Name = Name;
            this.TeacherId = TeacherId;
        }

    }


}
