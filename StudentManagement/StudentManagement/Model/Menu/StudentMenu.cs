using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
//using Newtonsoft.Json;

namespace StudentManagement.Model.Menu
{
    internal class StudentMenu : BaseMenu
    {
        PathFile pathFile = new PathFile();
        public override void AddNew()
        {
            //Read json:
            ReadJson readJson = new ReadJson();
            //string studentId;
            List<Student> students = readJson.LoadStudentJson();
            if(students == null)
            {
                students = new List<Student>();
            }
            Console.WriteLine("Nhập thông tin học sinh : ");
            Console.WriteLine("Nhập thông tin Id : ");
            string studentId = Console.ReadLine();
            Console.WriteLine("Nhập thông tin Name : ");
            string studentName = Console.ReadLine();
            Console.WriteLine("Nhập thông tin Gender : ");
            string studentGender = Console.ReadLine();
            Console.WriteLine("Nhập thông tin Email : ");
            string studentEmail = Console.ReadLine();
            Console.WriteLine("Nhập thông tin PhoneNumber : ");
            string studentPhoneNumber = Console.ReadLine();
            Console.WriteLine("Nhập thông tin Score : ");
            string studentScore = Console.ReadLine();
            Console.WriteLine("Nhập thông tin ClassId : ");
            string studentClassId = Console.ReadLine();
            Student studentAdd = new Student(studentId, studentName, studentGender, studentEmail, studentPhoneNumber, studentScore, studentClassId);
            students.Add(studentAdd);
            string json = JsonSerializer.Serialize(students);
            File.WriteAllText(pathFile.StudentPath, json);
            Console.WriteLine("Đã thêm học sinh");
        }

        public override void Delete()
        {
            //Read json:
            ReadJson readJson = new ReadJson();
            //string studentId;
            List<Student> students = readJson.LoadStudentJson();
            Console.WriteLine("Chọn Id để xóa : ");
            String StudentIdDelete = Console.ReadLine();
            foreach(Student delete in students.ToList())
            {
                Console.WriteLine(delete.Id);
                if (delete.Id == StudentIdDelete)
                {
                    //students.Remove(delete);
                    int deleteId = students.IndexOf(delete);
                    //students.RemoveAt(deleteId);
                    //Console.WriteLine(deleteId);
                    students.RemoveAt(deleteId);
                }
            }
            string json = JsonSerializer.Serialize(students);
            File.WriteAllText(pathFile.StudentPath, json);
            Console.WriteLine("Đã xóa học sinh có Id : " + StudentIdDelete);
        }

        public override void FindObject()
        {
            //Read json:
            ReadJson readJson = new ReadJson();
            //string studentId;
            List<Student> students = readJson.LoadStudentJson();
            Console.WriteLine("Chọn Id để tìm kiếm : ");
            String StudentIdFind = Console.ReadLine();
            foreach (Student find in students.ToList())
            {
                //Console.WriteLine(delete.Id);
                if (find.Id == StudentIdFind)
                {
                    Console.WriteLine("Đã tìm học sinh có Id : " + StudentIdFind);
                    Console.WriteLine("Id : " + find.Id);
                    Console.WriteLine("Name : " + find.Name);
                    Console.WriteLine("Gender : " + find.Gender);
                    Console.WriteLine("Email : " + find.Email);
                    Console.WriteLine("PhoneNumber : " + find.PhoneNumber);
                    Console.WriteLine("Score : " + find.Score);
                    Console.WriteLine("ClassId : " + find.ClassId);
                }
            }
            string json = JsonSerializer.Serialize(students);
            File.WriteAllText(pathFile.StudentPath, json);
            
        }

        public override void ShowList()
        {
            //Read json:
            ReadJson readJson = new ReadJson();
            //string studentId;
            List<Student> students = readJson.LoadStudentJson();
            Console.WriteLine("Danh sach hoc sinh : ");
            Console.WriteLine("=============================================");
            foreach (Student find in students.ToList())
            {
                    Console.WriteLine("Hoc sinh co Id : " + find.Id);
                    Console.WriteLine("Id : " + find.Id);
                    Console.WriteLine("Name : " + find.Name);
                    Console.WriteLine("Gender : " + find.Gender);
                    Console.WriteLine("Email : " + find.Email);
                    Console.WriteLine("PhoneNumber : " + find.PhoneNumber);
                    Console.WriteLine("Score : " + find.Score);
                    Console.WriteLine("ClassId : " + find.ClassId);
                    Console.WriteLine("=============================================");
            }
            string json = JsonSerializer.Serialize(students);
            File.WriteAllText(pathFile.StudentPath, json);

        }

        public override void Update()
        {
            //Read json:
            ReadJson readJson = new ReadJson();
            //string studentId;
            List<Student> students = readJson.LoadStudentJson();
            Console.WriteLine("Sửa thông tin học sinh có Id: ");
            string IdUpdate = Console.ReadLine();
            foreach(Student update in students.ToList())
            {
                if(update.Id == IdUpdate)
                {
                    Console.WriteLine("Nhập thông tin học sinh : ");
                    Console.WriteLine("Nhập thông tin Id : ");
                    string studentId = Console.ReadLine();
                    update.Id = studentId;
                    Console.WriteLine("Nhập thông tin Name : ");
                    string studentName = Console.ReadLine();
                    update.Name = studentName;
                    Console.WriteLine("Nhập thông tin Gender : ");
                    string studentGender = Console.ReadLine();
                    update.Gender = studentGender;
                    Console.WriteLine("Nhập thông tin Email : ");
                    string studentEmail = Console.ReadLine();
                    update.Email = studentEmail;
                    Console.WriteLine("Nhập thông tin PhoneNumber : ");
                    string studentPhoneNumber = Console.ReadLine();
                    update.PhoneNumber = studentPhoneNumber;
                    Console.WriteLine("Nhập thông tin Score : ");
                    string studentScore = Console.ReadLine();
                    update.Score = studentScore;
                    Console.WriteLine("Nhập thông tin ClassId : ");
                    string studentClassId = Console.ReadLine();
                    update.ClassId = studentClassId;
                }
            }
            string json = JsonSerializer.Serialize(students);
            File.WriteAllText(pathFile.StudentPath, json);
        }

        
    }
}
