using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Model
{
    internal class Student : Person
    {
        //Quan hệ giữa Student và Class là one to one 
        //Quan hệ giũa Class với Teacher là one to many
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Score { get; set; }
        public string ClassId { get; set; }

        public Student()
        {

        }
        public Student(string Id, string Name, string Gender, string Email, string PhoneNumber, string Score, string ClassId)
        {
            this.Id = Id;
            this.Name = Name;
            this.Gender = Gender;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.Score = Score;
            this.ClassId = ClassId;
        }
    }
}
