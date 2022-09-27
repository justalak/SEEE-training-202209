using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;
using System.Reflection;

namespace BT1
{
    internal class StudentMenu : BaseMenu
    {
        public static List<Student> students;
       public  static string datafile = "..//..//..//dataStudent.json";
        public void loginfile(String Function,Student student)
        {
            DateTime datatime = DateTime.Now;
            FileStream file = new FileStream(EnhancedFeature.logfile, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine("**************************************************************************");
            writer.WriteLine("doi tuong Student duoc "+ Function+" vao thoi diem: " + datatime);
            writer.WriteLine("Thong tin ve doi tuong nhu sau: ");
            writer.WriteLine("Id: " + student.Id + " Name: " + student.Name + " Gender: " + student.Gender + " Email: "
                + student.Email + " Phone Number: " + student.PhoneNumber + " Score: " + student.Score + " ClassId: "
                + student.ClassId);
            writer.Close();
            file.Close();
        }
        public override void ShowList()
        {
            var studenjson = File.ReadAllText(StudentMenu.datafile);
            var studenList = JsonConvert.DeserializeObject<List<Student>>(studenjson);
            if (studenList != null)
            {
                foreach (var student in studenList)
                {
                    Console.WriteLine("Id: " + student.Id + " Name: " + student.Name + " Gender: " + student.Gender + " Email: "
                     + student.Email + " Phone Number: " + student.PhoneNumber + " Score: " + student.Score + " ClassId: "
                     + student.ClassId);
                }
            } else
            {
                Console.WriteLine("*** Danh sach rong ***");
            }
        }
        public override void FindObject(int Id)
        {
            var studenjson = File.ReadAllText(StudentMenu.datafile);
            var studenList = JsonConvert.DeserializeObject<List<Student>>(studenjson);
            foreach (var student in studenList)
            {
                if (student.Id == Id)
                {
                    Console.WriteLine("Id: " + student.Id + " Name: " + student.Name + " Gender: " + student.Gender + " Email: "
                    + student.Email + " Phone Number: " + student.PhoneNumber + " Score: " + student.Score + " ClassId: "
                    + student.ClassId);
                }
            }
        }
        public bool ktFind(int Id)
        {
            bool kt = false;
            var studenjson = File.ReadAllText(StudentMenu.datafile);
            var studenList = JsonConvert.DeserializeObject<List<Student>>(studenjson);
            foreach (var student in studenList)
            {
                if (student.Id == Id)
                {
                    kt = true;
                }
                
            }
            return kt;
        }
        public override void AddNew()
        { 
            int Id = InputHandling.getId();
            Console.WriteLine("**** Moi ban nhap Name Student *****");
            String Name = Console.ReadLine();
            Console.WriteLine("**** Moi ban nhap Gender Student *****");
            String Gender = Console.ReadLine();
            Console.WriteLine("**** Moi ban nhap Email Student *****");
            String Email = Console.ReadLine();
            Console.WriteLine("**** Moi ban nhap Phone Number Student *****");
            String PhoneNumber = Console.ReadLine();
            int Score = InputHandling.getScore();
            int ClassId = InputHandling.getClassId();
            new Student(Id, Name, Gender, Email, PhoneNumber, Score, ClassId);
            Console.WriteLine("Ban da them thanh cong");
            Console.WriteLine("*** Danh sach sau khi them doi tuong ***");
            ShowList();
        } 
        public override  void Update(int Id)
        {

            var studenjson = File.ReadAllText(StudentMenu.datafile);
            List<Student> studenList = JsonConvert.DeserializeObject<List<Student>>(studenjson);
            foreach (var student in studenList)
            {
                if (student.Id == Id)
                {
                    int _Id = InputHandling.getId();
                    Console.WriteLine("**** Moi ban nhap Name Student *****");
                    String Name = Console.ReadLine();
                    Console.WriteLine("**** Moi ban nhap Gender Student *****");
                    String Gender = Console.ReadLine();
                    Console.WriteLine("**** Moi ban nhap Email Student *****");
                    String Email = Console.ReadLine();
                    Console.WriteLine("**** Moi ban nhap Phone Number Student *****");
                    String PhoneNumber = Console.ReadLine();
                    int Score= InputHandling.getScore();
                   int ClassId = InputHandling.getClassId();
                    student.Id = _Id;
                    student.Name = Name;
                    student.Gender = Gender;
                    student.Email = Email;
                    student.PhoneNumber = PhoneNumber;
                    student.Score = Score;
                    student.ClassId = ClassId;
                    loginfile("chinh sua",student);

                }

            }
            var studentJson1 = JsonConvert.SerializeObject(studenList, Formatting.Indented);
            File.WriteAllText(StudentMenu.datafile, studentJson1);
            Console.WriteLine("Ban da nhap thanh cong");
            Console.WriteLine("*** Danh sach sau khi sua doi tuong ***");
            ShowList();
        }
        public override void Delete(int Id)
        {
            var studenjson = File.ReadAllText(StudentMenu.datafile);
            List<Student> studenList = JsonConvert.DeserializeObject<List<Student>>(studenjson);
            foreach (var student in studenList.ToList())
            {
                if (student.Id == Id)
                {
                    loginfile("xoa", student);
                    studenList.Remove(student);
                }
            }
            var studentJson1 = JsonConvert.SerializeObject(studenList, Formatting.Indented);
            File.WriteAllText(StudentMenu.datafile, studentJson1);
            Console.WriteLine("Ban da xoa thanh cong");
            Console.WriteLine("*** Danh sach sau khi xoa doi tuong ***");
            ShowList();
        }

        public void ContinueStudent()
        {
            Console.WriteLine("*** Ban co muon thuc hien tiep thao tac voi doi tuong Student khong ***\n");
            Console.WriteLine("*** Nhan 1 de tiep tuc or other de thoat ***\n");
            String choise = Console.ReadLine();
            if (choise == "1")
            {
                StudentMenu studentmenu = new StudentMenu();
                studentmenu.Option();
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
                while (kt == false) {
                try
                {
                    Console.WriteLine("*** Ban hay lua chon thao tac voi doi tuong Student ");
                    int choise = Convert.ToInt32(Console.ReadLine()); 
                    switch (choise)
                    {
                        case 1: ShowList();
                            ContinueStudent();
                            kt = true;
                            break;
                        case 2:
                            bool kt2 = false;
                            while (kt2 == false)
                            { try { 
                                Console.WriteLine("*** Moi ban nhap Id doi tuong can tim ***\n");
                                int _Id = Convert.ToInt32(Console.ReadLine());
                                    kt2=true;
                                if (ktFind(_Id))
                                    {
                                        FindObject(_Id);
                                        ContinueStudent();
                                        kt = true;
                                    } else
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
                        case 3: AddNew();
                            ContinueStudent();
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
                                        ContinueStudent();
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
                                        ContinueStudent();
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
                        case 0: Back();
                            kt = true;
                            break;
                        default: kt= false;break;
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
