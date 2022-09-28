using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace StudentManagement.Model.Menu
{
    
    internal class ClassMenu : BaseMenu
    {
        PathFile pathFile = new PathFile();
        public override void AddNew()
        {
            //Read json:
            ReadJson readJson = new ReadJson();
            //string studentId;
            List<Class> classes = readJson.LoadClassJson();
            if (classes == null)
            {
                classes = new List<Class>();
            }
            Console.WriteLine("Nhap thong tin lop hoc : ");
            Console.WriteLine("Nhap thong tin Id : ");
            string classId = Console.ReadLine();
            Console.WriteLine("Nhap thong tin Name : ");
            string className = Console.ReadLine();
            Console.WriteLine("Nhap thong tin TeacherId : ");
            string teacherId = Console.ReadLine();

            Class ClassAdd = new Class(classId, className, teacherId);
            classes.Add(ClassAdd);
            string json = JsonSerializer.Serialize(classes);
            File.WriteAllText(pathFile.ClassPath, json);
            Console.WriteLine("Đa them lop hoc");
        }

        public override void Delete()
        {
            //Read json:
            ReadJson readJson = new ReadJson();
            //string studentId;
            List<Class> classes = readJson.LoadClassJson();
            if (classes == null)
            {
                classes = new List<Class>();
            }
            Console.WriteLine("Chọn Id để xóa : ");
            String CLassIdDelete = Console.ReadLine();
            foreach (Class delete in classes.ToList())
            {
                Console.WriteLine(delete.Id);
                if (delete.Id == CLassIdDelete)
                {
                    //students.Remove(delete);
                    int deleteId = classes.IndexOf(delete);
                    //students.RemoveAt(deleteId);
                    //Console.WriteLine(deleteId);
                    classes.RemoveAt(deleteId);
                }
            }
            string json = JsonSerializer.Serialize(classes);
            File.WriteAllText(pathFile.ClassPath, json);
            Console.WriteLine("Đã xóa lop hoc có Id : " + CLassIdDelete);
        }

        public override void FindObject()
        {
            //Read json:
            ReadJson readJson = new ReadJson();
            //string studentId;
            List<Class> classes = readJson.LoadClassJson();
            if (classes == null)
            {
                classes = new List<Class>();
            }
            Console.WriteLine("Chọn Id để tim kiem : ");
            String CLassIdDelete = Console.ReadLine();
            foreach (Class delete in classes.ToList())
            {
                Console.WriteLine(delete.Id);
                if (delete.Id == CLassIdDelete)
                {
                    Console.WriteLine("Da tim lop hoc co Id : " + CLassIdDelete);
                    Console.WriteLine("Id : " + delete.Id);
                    Console.WriteLine("Name : " + delete.Name);
                    Console.WriteLine("TeacherId : " + delete.TeacherId);
                }
            }
            string json = JsonSerializer.Serialize(classes);
            File.WriteAllText(pathFile.ClassPath, json);
        }

        public override void ShowList()
        {
            //Read json:
            ReadJson readJson = new ReadJson();
            //string studentId;
            List<Class> classes = readJson.LoadClassJson();
            if (classes == null)
            {
                classes = new List<Class>();
            }
            Console.WriteLine("Danh sach lop hoc : ");
            Console.WriteLine("=============================================");
            foreach (Class delete in classes.ToList())
            {
                    Console.WriteLine("Da tim lop hoc co Id : " + delete.Id);
                    Console.WriteLine("Id : " + delete.Id);
                    Console.WriteLine("Name : " + delete.Name);
                    Console.WriteLine("TeacherId : " + delete.TeacherId);
                    Console.WriteLine("=============================================");
            }
            string json = JsonSerializer.Serialize(classes);
            File.WriteAllText(pathFile.ClassPath, json);
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
