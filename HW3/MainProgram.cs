using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using System.Data;

namespace HW3
{
    internal class MainProgram
    {

        public static void Main()
        {
        t: Console.WriteLine("School Management System");
            Console.WriteLine("------------------------");
            Console.WriteLine("Choose an option below:");
            Console.WriteLine("  1. Student Management");
            Console.WriteLine("  2. Teacher Management");
            Console.WriteLine("  3. Class Management");
            Console.WriteLine("Type 'Exit' to close the app");
            Console.WriteLine("Your choice:");
        l: string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BaseMenuStudent menustd;
                    List<Student> students = new List<Student>();
                    Student std1 = new Student(1, "Nguyen Danh Khue", "male", "khuend@gmail.com", "0123456789", 8.5, "ETE4");
                    Student std2 = new Student(2, "Nguyen Viet Anh", "male", "vietanh@gmail.com", "0123456789", 9.0, "ETE4");
                    Student std3 = new Student(3, "Pham Duc Hung", "male", "hungpd@gmail.com", "0123456789", 8.0, "ETE5");
                    students.Add(std1); students.Add(std2); students.Add(std3);
                    menustd = new StudentMenu();
                    BaseMenu("Student");
                l1: string action = Console.ReadLine();
                    switch (action)
                    {
                        case "0":
                            goto t;
                        case "1":
                            menustd.ShowList(students);
                            Console.WriteLine("Choose another option :");
                            goto l1;
                        case "2":
                            menustd.Search(ref students);
                            Console.WriteLine("Choose another option :");
                            goto l1;
                        case "3":
                            menustd.AddNew(ref students);
                            Console.WriteLine("Choose another option :");
                            goto l1;
                        case "4":
                            menustd.Update(ref students);
                            Console.WriteLine("Choose another option :");
                            goto l1;
                        case "5":
                            menustd.Delete(ref students);
                            Console.WriteLine("Choose another option :");
                            goto l1;
                        case "6":
                            menustd.StudentSameClass(students);
                            Console.WriteLine("Choose another option :");
                            goto l1;
                        default:
                            Console.WriteLine("Choose another option :");
                            goto l1;
                    }
                case "2":
                    BaseMenuTeacher menutc;
                    List<Teacher> teachers = new List<Teacher>();
                    Teacher tc1 = new Teacher(1, "Nguyen Van A");
                    Teacher tc2 = new Teacher(2, "Tran Thi B");
                    teachers.Add(tc1); teachers.Add(tc2);
                    BaseMenu("Teacher");
                    menutc = new TeacherMenu();
                l2: string action1 = Console.ReadLine();
                    switch (action1)
                    {
                        case "0":
                            goto t;
                        case "1":
                            menutc.ShowList(ref teachers);
                            Console.WriteLine("Choose another option :");
                            goto l2;
                        case "2":
                            menutc.Search(ref teachers);
                            Console.WriteLine("Choose another option :");
                            goto l2;
                        case "3":
                            menutc.AddNew(ref teachers);
                            Console.WriteLine("Choose another option :");
                            goto l2;
                        case "4":
                            menutc.Update(ref teachers);
                            Console.WriteLine("Choose another option :");
                            goto l2;
                        case "5":
                            menutc.Delete(ref teachers);
                            Console.WriteLine("Choose another option :");
                            goto l2;
                        default:
                            Console.WriteLine("Choose another option");
                            goto l2;
                    }
                case "3":
                    BaseMenuClass menucl;
                    List<Class> classes = new List<Class>();
                    Class cl1 = new Class(1, "ETE4", "Nguyen Van A");
                    Class cl2 = new Class(2, "ETE5", "Tran Thi B");
                    classes.Add(cl1); classes.Add(cl2);
                    BaseMenu("Class");
                    menucl = new ClassMenu();
                l3: string action2 = Console.ReadLine();
                    switch (action2)
                    {
                        case "0":
                            goto t;
                        case "1":
                            menucl.ShowList(ref classes);
                            Console.WriteLine("Choose another option :");
                            goto l3;
                        case "2":
                            menucl.Search(ref classes);
                            Console.WriteLine("Choose another option :");
                            goto l3;
                        case "3":
                            menucl.AddNew(ref classes);
                            Console.WriteLine("Choose another option :");
                            goto l3;
                        case "4":
                            menucl.Update(ref classes);
                            Console.WriteLine("Choose another option :");
                            goto l3;
                        case "5":
                            menucl.Delete(ref classes);
                            Console.WriteLine("Choose another option :");
                            goto l3;
                        default:
                            Console.WriteLine("Choose another option");
                            goto l3;
                    }
                case "exit":
                    return;
                default:
                    Console.WriteLine("Choose another option");
                    goto l;
            }


        }
        public static void BaseMenu(string obj)
        {
            Console.WriteLine("________________");
            Console.WriteLine($"{obj} Management");
            Console.WriteLine();
            Console.WriteLine("Choose an operation below :");
            Console.WriteLine($"  1. View {obj} list");
            Console.WriteLine($"  2. Search {obj}");
            Console.WriteLine($"  3. Add a {obj}");
            Console.WriteLine($"  4. Update a {obj}");
            Console.WriteLine($"  5. Delete a {obj}");
            if (obj == "Student")
            {
                Console.WriteLine("  6. Find Student with same Class");
            }
            Console.WriteLine("  0. Get back to the previous menu");

        }
        
    }

}
