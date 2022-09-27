using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace BT1
{
    internal class Teacher : People 
    {
       public  Teacher() : base()
        {

        }
        public Teacher(int Id,string Name) : base (Id, Name)
        {
            TeacherMenu.teachers.Add(this);

            var teacherJson = JsonConvert.SerializeObject(TeacherMenu.teachers, Formatting.Indented);
            try
            {
                File.WriteAllText(TeacherMenu.datafile, teacherJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
            TeacherMenu teachermenu = new TeacherMenu();
            teachermenu.loginfile("them", this);
        }

    }
}
