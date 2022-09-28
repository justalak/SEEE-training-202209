using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSchool
{
    [Serializable]
    internal class StudentClass
    {
        public int IdStudent { get; set; }
        public string NameStudent { get; set; }
        public string GenderStudent { get; set; }
        public string EmailStudent { get; set; }
        public string PhoneNumberStudent { get; set; }
        public string ScoreStudent { get; set; }
        public int IdClassStudent { get; set; }

    }
}
