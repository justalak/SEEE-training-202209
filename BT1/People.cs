using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1
{
    internal class People
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public People()
        {

        }
        public People(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
