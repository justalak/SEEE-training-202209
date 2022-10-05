using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageSchool.Menu
{
    [Serializable]
    public class ClassMenu : BaseMenu
    {
        public List<Class> listClass = null;
        public ClassMenu()
        {
            var dataClass = File.ReadAllText(@"../../Menu/Class.json");
            listClass = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Class>>(dataClass);
        }
        private int CreateID()
        {
            int maxId = 1;
            foreach (Class cl in listClass)
            {
                if (cl.IdClass > maxId)
                {
                    maxId = cl.IdClass;
                }
            }
            maxId += 1;
            return maxId;
        }
        public override void AddNew()
        {
            Class cl = new Class();

            cl.IdClass = CreateID();

            Console.Write("Input name: ");
            cl.NameClass = Console.ReadLine();

            Console.Write("Input teacherId: ");
            string teacherIdinClass = Console.ReadLine();

            cl.TeacherId = Convert.ToInt32(teacherIdinClass);

            listClass.Add(cl);
            SaveFile(listClass);
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
                listClass.RemoveAt(index);
                Console.WriteLine("Đã xóa lớp có ID là:" + id + "\n");
            }
            else
            {
                Console.WriteLine("Không có lớp có ID là:  " + id + "\n");
            }
        }

        public override int FindObject(int id, bool showObject)
        {
            int index = -1;
            for (int i = 0; i < listClass.Count; i++)
            {
                if (listClass[i].IdClass == id)
                {
                    index = i;
                    if (showObject)
                    {
                        Console.WriteLine("{0, -10} {1, -10} {2, -10}", "ID", "Name", "TeacherId");
                        Console.WriteLine("{0, -10} {1, -10} {2, -10}", listClass[i].IdClass, listClass[i].NameClass, listClass[i].TeacherId);
                    }
                    break;
                }
            }
            return index;
        }

        public override void ShowList()
        {
            Console.WriteLine("Hiện tại đang có {1} lớp", listClass.Count);
            Console.WriteLine("{0, -10} {1, -10} {2, -10}", "ID", "Name", "TeacherId");
            foreach (Class cl in listClass)
            {
                Console.WriteLine("{0, -10} {1, -10} {2, -10}", cl.IdClass, cl.NameClass, cl.TeacherId);
            }
            Console.WriteLine();
        }

        public override void ShowMenu()
        {
            Console.WriteLine("1. Xem danh sách lớp học");
            Console.WriteLine("2. Tìm kiếm lớp học");
            Console.WriteLine("3. Thêm lớp học");
            Console.WriteLine("4. Cập nhật lớp theo ID");
            Console.WriteLine("5. Xóa lớp");
            Console.WriteLine("0. Trở lại menu trước");
        }
        public override void Update(int id)
        {
            int index = FindObject(id, false);
            if (index != -1)
            {
                Console.Write("Nhập tên: ");

                listClass[index].NameClass = Console.ReadLine();

                Console.Write("Nhập ID giáo viên: ");
                string idTeacher = Console.ReadLine();
                listClass[index].TeacherId = Convert.ToInt32(idTeacher);
            }
            else
            {
                Console.WriteLine("Không có lớp có ID là:  " + id + "\n");
            }
            SaveFile(listClass);

        }
        static void SaveFile(List<Class> listClass)
        {
            foreach (Class cl in listClass)
            {
                using (Stream stream = File.Open(@"../../Menu/Class.json", FileMode.Create))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binaryFormatter.Serialize(stream, cl);
                }
            }
        }

    }
}
