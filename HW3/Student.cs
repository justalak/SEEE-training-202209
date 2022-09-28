using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    
    public class Student
    {
        public string name { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public int id { get; set; }
        public double score { get; set; }
        public string classId { get; set; }

        public Student()
        {

        }

        public Student(int id, string name, string gender, string email, string phoneNumber, double score, string classid)
        {
            this.id = id;
            this.name = name;
            this.gender = gender;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.score = score;
            this.classId = classid;
        }
    }
}

