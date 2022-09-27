using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1
{
    internal class Class: People 
    {
        public int TeacherId { get; set; }
        public Class() : base()
        {

        }
        public Class(int Id,string Name,int teacherId) : base(Id,Name)
        {
            this.TeacherId = teacherId;
            ClassMenu.classs.Add(this);

            var classJson = JsonConvert.SerializeObject(ClassMenu.classs, Formatting.Indented);
            try
            {
                File.WriteAllText(ClassMenu.datafile, classJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
            ClassMenu classmenu = new ClassMenu();
            classmenu.loginfile("them", this);
            
        }

    }
   
}
