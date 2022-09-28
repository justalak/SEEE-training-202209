using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSchool.Menu
{
    [Serializable]
    internal class TeacherMenu : BaseMenu
    {
        public List<Teacher> listTeacher = null;
        public TeacherMenu()
        {
            var dataTeacher = File.ReadAllText(@"Teacher.json");
            listTeacher = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Teacher>>(dataTeacher);
        }
        private int CreateID()
        {
            int maxId = 1;
            foreach (Teacher teacher in listTeacher)
            {
                if (teacher.IdTeacher > maxId)
                {
                    maxId = teacher.IdTeacher;
                }
            }
            maxId += 1;
            return maxId;
        }
        public override void AddNew()
        {
            Teacher teacher = new Teacher();
            teacher.IdTeacher = CreateID();

            Console.Write("Input name: ");
            teacher.NameTeacher = Console.ReadLine();

            listTeacher.Add(teacher);
            SaveFile(listTeacher);
        }

        public override void Back()
        {
            throw new NotImplementedException();
        }

        public override void Delete(int id)
        {
            int index = FindObject(id, false);
            if (index != -1)
            {
                listTeacher.RemoveAt(index);
                Console.WriteLine("Đã xóa giáo viên có id là:" + id + "\n");
            }
            else
            {
                Console.WriteLine("Không có giáo ciên có ID là " + id + "\n");
            }
        }

        public override int FindObject(int id, bool showObject)
        {
            int index = -1;
            for (int i = 0; i < listTeacher.Count; i++)
            {
                if (listTeacher[i].IdTeacher == id)
                {
                    index = i;
                    if (showObject)
                    {
                        Console.WriteLine("{0, -10} {1, -10}", "ID", "Name");
                        Console.WriteLine("{0, -10} {1, -10}", listTeacher[i].IdTeacher, listTeacher[i].NameTeacher);
                    }
                    break;
                }
            }
            return index;
        }

        public override void ShowList()
        {
            Console.WriteLine("Hiện tại đang có {0} giáo viên ", listTeacher.Count);
            Console.WriteLine("{0, -10} {1, -10} ", "ID", "Name");
            foreach (Teacher cl in listTeacher)
            {
                Console.WriteLine("{0, -10} {1, -10}", cl.IdTeacher, cl.NameTeacher);
            }
            Console.WriteLine();
        }
        public override void ShowMenu()
        {
            Console.WriteLine("1. Xem danh sách giáo viên");
            Console.WriteLine("2. Tìm kiếm giáo viên");
            Console.WriteLine("3. Thêm giáo viên ");
            Console.WriteLine("4. Cập nhật giáo viên  theo ID");
            Console.WriteLine("5. Xóa giáo viên ");
            Console.WriteLine("0. Trở lại menu trước");
        }

        public override void Update(int id)
        {
            int index = FindObject(id, false);
            if (index != -1)
            {
                Console.Write("Nhập tên: ");
                listTeacher[index].NameTeacher = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Không có giáo viên có ID là:  " + id + "\n");
            }
            SaveFile(listTeacher);
        }
        static void SaveFile(List<Teacher> listTeacher)
        {
            foreach (Teacher teacher in listTeacher)
            {
                using (Stream stream = File.Open(@"Teacher.json", FileMode.Create))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binaryFormatter.Serialize(stream, teacher);
                }
            }
        }
    }
}
