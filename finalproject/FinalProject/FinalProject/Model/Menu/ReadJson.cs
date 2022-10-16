using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FinalProject.Model.Menu
{
    internal class ReadJson
    {
        PathFile pathFile = new PathFile();
        public List<Student> LoadStudentJson()
        {
            using (StreamReader r = new StreamReader(pathFile.StudentPath))
            {
                string json = r.ReadToEnd();
                List<Student> students = JsonConvert.DeserializeObject<List<Student>>(json);
                return students;
            }
        }

        public List<Teacher> LoadTeacherJson()
        {
            using (StreamReader r = new StreamReader(pathFile.TeacherPath))
            {
                string json = r.ReadToEnd();
                List<Teacher> teachers = JsonConvert.DeserializeObject<List<Teacher>>(json);
                return teachers;
            }
        }

        public List<Class> LoadClassJson()
        {
            using (StreamReader r = new StreamReader(pathFile.ClassPath))
            {
                string json = r.ReadToEnd();
                List<Class> classes = JsonConvert.DeserializeObject<List<Class>>(json);
                return classes;
            }
        }
    }
}
