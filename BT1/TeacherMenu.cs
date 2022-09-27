using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BT1
{
    internal class TeacherMenu : BaseMenu 
    {
        public static string datafile = "..//..//..//dataTeacher.json";
        public static List<Teacher> teachers;
        public void loginfile(string Function, Teacher teacher)
        {
            // Ghi thoi gian va thong tin doi tuong duoc them vao log
            DateTime datatime = DateTime.Now;
            FileStream file = new FileStream(EnhancedFeature.logfile, FileMode.Create);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine("**************************************************************************");
            writer.WriteLine("doi tuong Student duoc " + Function + " vao thoi diem: " + datatime);
            writer.WriteLine("Thong tin ve doi tuong nhu sau: ");
            writer.WriteLine("Id: " + teacher.Id + " Name: " + teacher.Name);
            writer.Close();
            file.Close();
        }
        public  override void ShowList()
        {
            var teacherjson = File.ReadAllText(TeacherMenu.datafile);
            var teacherList = JsonConvert.DeserializeObject<List<Teacher>>(teacherjson);
            if (teacherList != null) { 
            foreach (var teacher in teacherList)
            {
                Console.WriteLine("Id: " + teacher.Id + " Name: " + teacher.Name);
            }
            } else
            {
                Console.WriteLine("*** Danh sach rong ***");
            }
        }
        public override void FindObject(int Id)
        {
            var teacherjson = File.ReadAllText(TeacherMenu.datafile);
            var teacherList = JsonConvert.DeserializeObject<List<Teacher>>(teacherjson);
            foreach (var teacher in teacherList)
            {
                if (teacher.Id == Id)
                {
                    Console.WriteLine("Id: " + teacher.Id + " Name: " + teacher.Name);
                }
            }
        }
        public bool ktFind(int Id)
        {
            bool kt = false;
            var teacherjson = File.ReadAllText(TeacherMenu.datafile);
            var teacherList = JsonConvert.DeserializeObject<List<Teacher>>(teacherjson);
            foreach (var teacher in teacherList)
            {
                if (teacher.Id == Id)
                {
                    kt = true;
                }

            }
            return kt;
        }
        public override void AddNew()
        {
            int Id = InputHandling.getId();
            Console.WriteLine("**** Moi ban nhap Name Teacher *****");
            String Name = Console.ReadLine();
            new Teacher(Id, Name);
            Console.WriteLine("Ban da them thanh cong");
            Console.WriteLine("*** Danh sach sau khi them doi tuong ***");
            ShowList();
        }
        public override  void Update(int Id)
        {

            var teacherjson = File.ReadAllText(TeacherMenu.datafile);
            List<Teacher> teacherList = JsonConvert.DeserializeObject<List<Teacher>>(teacherjson);
            foreach (var teacher in teacherList)
            {
                if (teacher.Id == Id)
                {
                    int _Id = InputHandling.getId();
                    Console.WriteLine("**** Moi ban nhap Name Teacher *****");
                    String Name = Console.ReadLine();
                    teacher.Id = _Id;
                    teacher.Name = Name;
                   loginfile("chinh sua ",teacher);
                }

            }
            var teacherJson1 = JsonConvert.SerializeObject(teacherList, Formatting.Indented);
            File.WriteAllText(TeacherMenu.datafile, teacherJson1);
            Console.WriteLine("Ban da nhap thanh cong");
            Console.WriteLine("*** Danh sach sau khi sua doi tuong ***");
            ShowList();
        }
        public override void Delete(int Id)
        {
            var teacherjson = File.ReadAllText(TeacherMenu.datafile);
            List<Teacher> teacherList = JsonConvert.DeserializeObject<List<Teacher>>(teacherjson);
            foreach (var teacher in teacherList.ToList())
            {
                if (teacher.Id == Id)
                {
                    loginfile("xoa", teacher);
                    teacherList.Remove(teacher);
                }
            }
            var teacherJson1 = JsonConvert.SerializeObject(teacherList, Formatting.Indented);
            File.WriteAllText(TeacherMenu.datafile, teacherJson1);
            Console.WriteLine("Ban da xoa thanh cong");
            Console.WriteLine("*** Danh sach sau khi xoa doi tuong ***");
            ShowList();
        }
        public void ContinueTeacher()
        {
            Console.WriteLine("*** Ban co muon thuc hien tiep thao tac voi doi tuong Teacher khong ***\n");
            Console.WriteLine("*** Nhan 1 de tiep tuc or other de thoat ***\n");
            String choise = Console.ReadLine();
            if (choise == "1")
            {
                TeacherMenu teachermenu = new TeacherMenu();
                teachermenu.Option();
            }
            else
            {
                Back();
            }
        }
        public override void Option()
        {
            base.Option();

            bool kt = false;
            while (kt == false)
            {
                try
                {
                    Console.WriteLine("*** Ban hay lua chon thao tac voi doi tuong Teacher ");
                    int choise = Convert.ToInt32(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            ShowList();
                            ContinueTeacher();
                            kt = true;
                            break;
                        case 2:
                            bool kt2 = false;
                            while (kt2 == false)
                            {
                                try
                                {
                                    Console.WriteLine("*** Moi ban nhap Id doi tuong can tim ***\n");
                                    int _Id = Convert.ToInt32(Console.ReadLine());
                                    kt2 = true;
                                    if (ktFind(_Id))
                                    {
                                        FindObject(_Id);
                                        ContinueTeacher();
                                        kt = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("*** ID khong khop *** Xin moi nhap lai *** \n");
                                        kt2 = false;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("*** Ban da nhap Sai *** Xin moi nhap lai *** \n");
                                    kt2 = false;
                                }
                            }
                            break;
                        case 3:
                            AddNew();
                            ContinueTeacher();
                            kt = true;
                            break;
                        case 4:
                            bool kt4 = false;
                            while (kt4 == false)
                            {
                                try
                                {
                                    Console.WriteLine("*** Moi ban nhap Id doi tuong muon sua ***\n");
                                    int _Id = Convert.ToInt32(Console.ReadLine());
                                    kt4 = true;
                                    if (ktFind(_Id))
                                    {
                                        Update(_Id);
                                        ContinueTeacher();
                                        kt = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("*** ID khong khop *** Xin moi nhap lai *** \n");
                                        kt4 = false;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("*** Ban da nhap Sai *** Xin moi nhap lai *** \n");
                                    kt4 = false;
                                }
                            }
                            break;
                        case 5:
                            bool kt5 = false;
                            while (kt5 == false)
                            {
                                try
                                {
                                    Console.WriteLine("*** Moi ban nhap Id doi tuong muon xoa ***\n");
                                    int _Id = Convert.ToInt32(Console.ReadLine());
                                    kt5 = true;
                                    if (ktFind(_Id))
                                    {
                                        Delete(_Id);
                                        ContinueTeacher();
                                        kt = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("*** ID khong khop *** Xin moi nhap lai *** \n");
                                        kt5 = false;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("*** Ban da nhap Sai *** Xin moi nhap lai *** \n");
                                    kt5 = false;
                                }
                            }
                            break;
                        case 0:
                            Back();
                            kt = true;
                            break;
                        default: kt = false ; break;
                    }
                }
                catch
                {
                    kt = false;
                }
            }
        }
    }
}
