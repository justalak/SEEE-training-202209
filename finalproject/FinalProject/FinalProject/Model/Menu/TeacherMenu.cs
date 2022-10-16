using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace FinalProject.Model.Menu
{
    internal class TeacherMenu : BaseMenu
    {
        PathFile pathFile = new PathFile();
        public override void AddNew()
        {
            //Read json:
            ReadJson readJson = new ReadJson();
            //string studentId;
            List<Teacher> teachers = readJson.LoadTeacherJson();
            if (teachers == null)
            {
                teachers = new List<Teacher>();
            }
            Console.WriteLine("Nhap thong tin giao vien : ");
            Console.WriteLine("Nhap thong tin Id : ");
            string teacherId = Console.ReadLine();
            Console.WriteLine("Nhap thong tin Name : ");
            string teacherName = Console.ReadLine();
            
            Teacher TeacherAdd = new Teacher(teacherId, teacherName);
            teachers.Add(TeacherAdd);
            string json = JsonSerializer.Serialize(teachers);
            File.WriteAllText(pathFile.TeacherPath, json);
            Console.WriteLine("Đa them giao vien");
        }

        public override void Delete()
        {
            //Read json:
            ReadJson readJson = new ReadJson();
            //string studentId;
            List<Teacher> teachers = readJson.LoadTeacherJson();
            Console.WriteLine("Chọn Id để xóa : ");
            String TeacherIdDelete = Console.ReadLine();
            foreach (Teacher delete in teachers.ToList())
            {
                Console.WriteLine(delete.Id);
                if (delete.Id == TeacherIdDelete)
                {
                    //students.Remove(delete);
                    int deleteId = teachers.IndexOf(delete);
                    //students.RemoveAt(deleteId);
                    //Console.WriteLine(deleteId);
                    teachers.RemoveAt(deleteId);
                }
            }
            string json = JsonSerializer.Serialize(teachers);
            File.WriteAllText(pathFile.TeacherPath, json);
            Console.WriteLine("Đã xóa giao vien có Id : " + TeacherIdDelete);
        }

        public override void FindObject()
        {
            //Read json:
            ReadJson readJson = new ReadJson();
            //string studentId;
            List<Teacher> teachers = readJson.LoadTeacherJson();
            Console.WriteLine("Chon Id de tim kiem : ");
            String TeacherIdDelete = Console.ReadLine();
            foreach (Teacher delete in teachers.ToList())
            {
                Console.WriteLine(delete.Id);
                if (delete.Id == TeacherIdDelete)
                {
                    Console.WriteLine("Da tim giao vien co Id : " + TeacherIdDelete);
                    Console.WriteLine("Id : " + delete.Id);
                    Console.WriteLine("Name : " + delete.Name);
                }
            }
            string json = JsonSerializer.Serialize(teachers);
            File.WriteAllText(pathFile.TeacherPath, json);
        }

        public override void ShowList()
        {
            //Read json:
            ReadJson readJson = new ReadJson();
            //string studentId;
            List<Teacher> teachers = readJson.LoadTeacherJson();
            Console.WriteLine("Danh sach giao vien : ");
            Console.WriteLine("=============================================");
            foreach (Teacher delete in teachers.ToList())
            {
                Console.WriteLine("Giao Vien co Id : " + delete.Id);
                Console.WriteLine("Id : " + delete.Id);
                Console.WriteLine("Name : " + delete.Name);
                Console.WriteLine("=============================================");
            }
            string json = JsonSerializer.Serialize(teachers);
            File.WriteAllText(pathFile.TeacherPath, json);
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
