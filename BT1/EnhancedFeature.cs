using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BT1
{
    internal class EnhancedFeature
    {  
        public static  string logfile = "..//..//..//log.json";
        public ArrayList ClassOfTeacher(int Id)
        {
            var classjson = File.ReadAllText(ClassMenu.datafile);
            var classList = JsonConvert.DeserializeObject<List<Class>>(classjson);
            ArrayList classofteacher = new ArrayList();
            foreach ( var cl in classList )
            {
                if ( cl.TeacherId == Id )
                {
                    classofteacher.Add(cl.TeacherId);
                }
            }
            return classofteacher;
        }
        public List<Student> StudentOfTeacher(ArrayList classofteacher)
        {
            List<Student> studentofteacher = new List<Student>();
            var studenjson = File.ReadAllText(StudentMenu.datafile);
            var studenList = JsonConvert.DeserializeObject<List<Student>>(studenjson);
            foreach (var student in studenList)
            {
                if (classofteacher.Contains(student.ClassId) == true)
                {
                    studentofteacher.Add(student);
                }
            }
            return studentofteacher;
        }
        public string getNameTeacher(int Id)
        {
            string name = "";
            var teacherjson = File.ReadAllText(TeacherMenu.datafile);
            var teacherList = JsonConvert.DeserializeObject<List<Teacher>>(teacherjson);
            foreach (var teacher in teacherList)
            {
                if (teacher.Id == Id)
                {
                    name = teacher.Name;
                }

            }
            return name;
        }
        public void AllStudentOfTeacher()
        {
            int Id = InputHandling.getId();
            string name = getNameTeacher(Id);
            List<Student> st = StudentOfTeacher(ClassOfTeacher(Id));
            Console.WriteLine("Giao vien "+name +" day cac hoc sinh sau: ");
            foreach (var student in st)
            {
                Console.WriteLine("Id: " + student.Id + " Name: " + student.Name + " Gender: " + student.Gender + " Email: "
                 + student.Email + " Phone Number: " + student.PhoneNumber + " Score: " + student.Score + " Class: "
                 + FindNameClass(student.ClassId));
            }

        }
        public List<int> ClassOfAllStudent()
        {
            var studenjson = File.ReadAllText(StudentMenu.datafile);
            var studenList = JsonConvert.DeserializeObject<List<Student>>(studenjson);
            List<int> classofallstudent = new List<int>();
            foreach (var student in studenList)
            {
                if (classofallstudent.Contains(student.ClassId) == false)
                {
                    classofallstudent.Add(student.ClassId);
                }
            }
            return classofallstudent;
        }
        public string FindNameClass(int Id)
        {
            string name = "";
            var classjson = File.ReadAllText(ClassMenu.datafile);
            var classList = JsonConvert.DeserializeObject<List<Class>>(classjson);
            foreach (var class1 in classList)
            {
                if (class1.Id == Id)
                {
                    name= class1.Name;
                }
            }
            return name;
        }
        public void StudentSameClass()
        { List<int> ClassList = ClassOfAllStudent();
            var studenjson = File.ReadAllText(StudentMenu.datafile);
            var studenList = JsonConvert.DeserializeObject<List<Student>>(studenjson);
            foreach (var classId in ClassList )
            {
                Console.WriteLine("****************************************");
                Console.WriteLine("Cac sinh vien sau hoc lop " + FindNameClass(classId));
                foreach (var student in studenList)
                {
                    if (student.ClassId == classId)
                    {
                        Console.WriteLine("Id: " + student.Id + " Name: " + student.Name + " Gender: " + student.Gender + " Email: "
                 + student.Email + " Phone Number: " + student.PhoneNumber + " Score: " + student.Score );
                    }
                }
            }
        }

    }
}
