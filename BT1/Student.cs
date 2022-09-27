using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BT1
{
    internal class Student : People 
    {
        public String Gender { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public int Score { get; set; }
        public int ClassId { get; set; } 
        public Student() : base()
        {
            
        }
        public Student(int Id, String Name, String Gender, string Email, String PhoneNumber, int Score, int ClassId): base(Id,Name)
        {
            
            this.Gender = Gender;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.Score = Score;
            this.ClassId = ClassId;
           
            StudentMenu.students.Add(this);

            var studentJson = JsonConvert.SerializeObject(StudentMenu.students, Formatting.Indented);
            try
            {
                File.WriteAllText(StudentMenu.datafile, studentJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
            StudentMenu studentmenu = new StudentMenu();
            studentmenu.loginfile("them", this);
        }

    }
}
