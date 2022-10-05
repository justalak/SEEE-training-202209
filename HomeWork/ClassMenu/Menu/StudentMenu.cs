using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ManageSchool.Menu
{
    [Serializable]
    internal class StudentMenu : BaseMenu
    {
        public List<StudentClass> listStudent = null;
        public StudentMenu()
        {
            var dataStudent = File.ReadAllText(@"../../Menu/Student.json");
            listStudent = JsonConvert.DeserializeObject<List<StudentClass>>(dataStudent);
        }
        private int CreateID()
        {
            int maxId = 1;
            foreach (StudentClass student in listStudent)
            {
                if (student.IdStudent > maxId)
                {
                    maxId = student.IdStudent;
                }
            }
            maxId += 1;
            return maxId;
        }
        public override void AddNew()
        {
            StudentClass student = new StudentClass();

            student.IdStudent = CreateID();

            Console.Write("Nhap ten hoc sinh: ");
            student.NameStudent = Console.ReadLine();

            Console.Write("Gioi tinh: ");
            student.GenderStudent = Console.ReadLine();

            Console.Write("Email: ");
            student.EmailStudent = Console.ReadLine();

            Console.Write("So dien thoai: ");
            student.PhoneNumberStudent = Console.ReadLine();

            Console.Write("Diem: ");
            student.ScoreStudent = Console.ReadLine();

            Console.Write("Lop hoc: ");
            string idClass = Console.ReadLine();
            student.IdClassStudent = Convert.ToInt16(idClass);

            listStudent.Add(student);
            SaveFile(listStudent);
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
                listStudent.RemoveAt(index);
                Console.WriteLine("Đã xóa sinh viên có ID là:" + id + "\n");
            }
            else
            {
                Console.WriteLine("Không có sinh viên có ID là:  " + id + "\n");
            }
        }

        public override int FindObject(int id, bool showObject)
        {
            int index = -1;
            for (int i = 0; i < listStudent.Count; i++)
            {
                if (listStudent[i].IdStudent == id)
                {
                    index = i;
                    if (showObject)
                    {
                        Console.WriteLine("{0, -10} {1, -10} {2, -10} {3, -10} {4, -10} {5, -10} {6, -10}",
                            "ID", "Name", "Gender", "Email", "Phone Number", "Score", "ID Class");
                        Console.WriteLine("{0, -10} {1, -10} {2, -10} {3, -10} {4, -10} {5, -10} {6, -10}",
                            listStudent[i].IdStudent, listStudent[i].NameStudent, listStudent[i].GenderStudent,
                            listStudent[i].EmailStudent, listStudent[i].PhoneNumberStudent, listStudent[i].ScoreStudent,
                            listStudent[i].IdClassStudent);
                    }
                    break;
                }
            }
            return index;
        }

        public override void ShowList()
        {
            Console.WriteLine("Hiện tại đang có {1} lớp", listStudent.Count);
            Console.WriteLine("{0, -10} {1, -10} {2, -10} {3, -10} {4, -10} {5, -10} {6, -10}",
                            "ID", "Name", "Gender", "Email", "Phone Number", "Score", "ID Class");
            foreach (StudentClass student in listStudent)
            {
                Console.WriteLine("{0, -10} {1, -10} {2, -10} {3, -10} {4, -10} {5, -10} {6, -10}",
                            student.IdStudent, student.NameStudent, student.GenderStudent,
                            student.EmailStudent, student.PhoneNumberStudent, student.ScoreStudent,
                            student.IdClassStudent);
            }
            Console.WriteLine();
        }

        public override void ShowMenu()
        {
            Console.WriteLine("1. Xem danh sách sinh viên");
            Console.WriteLine("2. Tìm kiếm sinh viên");
            Console.WriteLine("3. Thêm sinh viên");
            Console.WriteLine("4. Cập nhật sinh viên theo ID");
            Console.WriteLine("5. Xóa sinh viên");
            Console.WriteLine("6. Thoat!");
            Console.WriteLine("0. Trở lại Menu trước");
        }

        public override void Update(int id)
        {
            int index = FindObject(id, false);
            if (index != -1)
            {
                Console.Write("Nhập tên: ");
                listStudent[index].NameStudent = Console.ReadLine();

                Console.Write("Giới tính: ");
                listStudent[index].GenderStudent = Console.ReadLine();

                Console.Write("Email: ");
                listStudent[index].EmailStudent = Console.ReadLine();

                Console.Write("Só điện thoại: ");
                listStudent[index].GenderStudent = Console.ReadLine();

                Console.Write("Điểm: ");
                listStudent[index].ScoreStudent = Console.ReadLine();

                Console.Write("Mã lớp học: ");
                string idClass = Console.ReadLine();
                listStudent[index].IdClassStudent = Convert.ToInt32(idClass);
            }
            else
            {
                Console.WriteLine("Không có sinh viên có ID là:  " + id + "\n");
            }
            SaveFile(listStudent);

        }
        static void SaveFile(List<StudentClass> listStudent)
        {
            foreach(StudentClass studentClass in listStudent)
            {
                using (Stream stream = File.Open(@"../../Menu/Student.json", FileMode.Create))
                {
                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binaryFormatter.Serialize(stream, studentClass);
                }
            }
        }
    }
}
