using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;
using ManageSchool.Menu;

namespace ManageSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choose;
            do
            {
                ShowOption();
                choose = int.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        StudentAction();
                        break;
                    case 2:
                        TeacherAction();
                        break;
                    case 3:
                        ClassAction();
                        break;
                    default:
                        Console.WriteLine("Nhap sai!!! Moi ban nhap lai.");
                        break;
                }
            } while (choose != 4);
        }



        static void ShowOption()
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("1. Hoc sinh");
            Console.WriteLine("2. Giao vien");
            Console.WriteLine("3. Lop hoc");
            Console.WriteLine("4. Exit");
            Console.WriteLine("--------------------------------------------");
        }
        static void StudentAction()
        {
            StudentMenu listStudent = new StudentMenu();
            int chooseStudent;

            /*Console.WriteLine("1. Xem danh sách sinh viên");
            Console.WriteLine("2. Tìm kiếm sinh viên");
            Console.WriteLine("3. Thêm sinh viên");
            Console.WriteLine("4. Cập nhật sinh viên theo ID");
            Console.WriteLine("5. Xóa sinh viên");
            Console.WriteLine("6. Thoat!");
            Console.WriteLine("0. Trở lại menu trước");*/
            do
            {
                listStudent.ShowMenu();

                chooseStudent = int.Parse(Console.ReadLine());

                switch (chooseStudent)
                {
                    case 1:
                        listStudent.ShowList();
                        break;
                    case 2:
                        Console.WriteLine("Moi ban nhap ID sinh vien tim kiem:");
                        int idStudentFind = int.Parse(Console.ReadLine());
                        listStudent.FindObject(idStudentFind, true);
                        break;
                    case 3:
                        listStudent.AddNew();
                        break;
                    case 4:
                        Console.WriteLine("Moi ban nhap ID sinh vien cap nhat:");
                        int idStudentUpdate = int.Parse(Console.ReadLine());
                        listStudent.Update(idStudentUpdate);
                        break;
                    case 5:
                        Console.WriteLine("Moi ban nhap ID sinh vien xoa:");
                        int idStudentDelete = int.Parse(Console.ReadLine());
                        listStudent.Update(idStudentDelete);
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Nhap sai!!! Moi ban nhap lai.");
                        break;

                }
            } while(chooseStudent != 6);
        }
        static void TeacherAction()
        {
            TeacherMenu listTeacher = new TeacherMenu();
            
            int chooseTeacher;
            do
            {
                listTeacher.ShowMenu();

                chooseTeacher = int.Parse(Console.ReadLine());

                switch (chooseTeacher)
                {
                    case 1:
                        listTeacher.ShowList();
                        break;
                    case 2:
                        Console.WriteLine("Moi ban nhap ID giao vien tim kiem:");
                        int idStudentFind = int.Parse(Console.ReadLine());
                        listTeacher.FindObject(idStudentFind, true);
                        break;
                    case 3:
                        listTeacher.AddNew();
                        break;
                    case 4:
                        Console.WriteLine("Moi ban nhap ID giao vien cap nhat:");
                        int idStudentUpdate = int.Parse(Console.ReadLine());
                        listTeacher.Update(idStudentUpdate);
                        break;
                    case 5:
                        Console.WriteLine("Moi ban nhap ID giao vien xoa:");
                        int idStudentDelete = int.Parse(Console.ReadLine());
                        listTeacher.Update(idStudentDelete);
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Nhap sai!!! Moi ban nhap lai.");
                        break;

                }
            } while (chooseTeacher != 6);
        }
        static void ClassAction()
        {
            ClassMenu listClass = new ClassMenu();
            int chooseClass;
            do
            {
                listClass.ShowMenu();

                chooseClass = int.Parse(Console.ReadLine());

                switch (chooseClass)
                {
                    case 1:
                        listClass.ShowList();
                        break;
                    case 2:
                        Console.WriteLine("Moi ban nhap ID lop hoc tim kiem:");
                        int idStudentFind = int.Parse(Console.ReadLine());
                        listClass.FindObject(idStudentFind, true);
                        break;
                    case 3:
                        listClass.AddNew();
                        break;
                    case 4:
                        Console.WriteLine("Moi ban nhap ID lop hoc cap nhat:");
                        int idStudentUpdate = int.Parse(Console.ReadLine());
                        listClass.Update(idStudentUpdate);
                        break;
                    case 5:
                        Console.WriteLine("Moi ban nhap ID lop hoc xoa:");
                        int idStudentDelete = int.Parse(Console.ReadLine());
                        listClass.Update(idStudentDelete);
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Nhap sai!!! Moi ban nhap lai.");
                        break;
                }
            } while (chooseClass != 6);
        }
    }
}
