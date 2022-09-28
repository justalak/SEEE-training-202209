using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSchool
{
    [Serializable]
    public class Class
    {
        public int IdClass { get; set; }
        public string NameClass { get; set; }
        public int TeacherId { get; set; }

    }
}
