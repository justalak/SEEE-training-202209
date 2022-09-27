using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BT1
{
    
    internal class ClassMenu : BaseMenu
    {
        public static string datafile = "..//..//..//dataClass.json";
        public static List<Class> classs;
        public void loginfile(string Function,Class class1)
        {
            // Ghi thoi gian va thong tin doi tuong duoc them vao log
            DateTime datatime = DateTime.Now;
            FileStream file = new FileStream(EnhancedFeature.logfile, FileMode.Create);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine("**************************************************************************");
            writer.WriteLine("doi tuong Student duoc " + Function + " vao thoi diem: " + datatime);
            writer.WriteLine("Thong tin ve doi tuong nhu sau: ");
            writer.WriteLine("Id: " + class1.Id + " Name: " + class1.Name + " TeacherId: " + class1.TeacherId);
            writer.Close();
            file.Close();
        }
        public override void   ShowList()
        {
            var classjson = File.ReadAllText(ClassMenu.datafile);
            var classList = JsonConvert.DeserializeObject<List<Class>>(classjson);
            if (classList != null)
            {
                foreach (var class1 in classList)
                {
                    Console.WriteLine("Id: " + class1.Id + " Name: " + class1.Name + " TeacherId: " + class1.TeacherId);
                }
            } else
            {
                Console.WriteLine("*** Danh sach rong ***");
            }
        }
        public override void FindObject(int Id)
        {
            var classjson = File.ReadAllText(ClassMenu.datafile);
            var classList = JsonConvert.DeserializeObject<List<Class>>(classjson);
            foreach (var class1 in classList)
            {
                if (class1.Id == Id)
                {
                    Console.WriteLine("Id: " + class1.Id + " Name: " + class1.Name + " TeacherId: " + class1.TeacherId);
                }
            }
        }
        public  bool ktFind(int Id)
        {
            bool kt = false;
            var classjson = File.ReadAllText(ClassMenu.datafile);
            var classList = JsonConvert.DeserializeObject<List<Class>>(classjson);
            foreach (var class1 in classList)
            {
                if (class1.Id == Id)
                {
                    kt = true;
                }

            }
            return kt;
        }
        public override void AddNew()
        {
            int Id = InputHandling.getId();
            Console.WriteLine("**** Moi ban nhap Name Class *****");
            String Name = Console.ReadLine();
            int TeacherId = InputHandling.getTeacherId();
            new Class(Id, Name, TeacherId);
            Console.WriteLine("Ban da them thanh cong");
            Console.WriteLine("*** Danh sach sau khi them doi tuong ***");
            ShowList();
        }
        public  override void Update(int Id)
        {

            var classjson = File.ReadAllText(ClassMenu.datafile);
            List < Class> classList = JsonConvert.DeserializeObject<List < Class>>(classjson);
            foreach (var  class1 in classList)
            {
                if ( class1.Id == Id)
                {
                    int _Id = InputHandling.getId();
                    Console.WriteLine("**** Moi ban nhap Name  *****");
                    String Name = Console.ReadLine();
                    int TeacherId = InputHandling.getTeacherId();
                    class1.Id = _Id;
                    class1.Name = Name;
                    class1.TeacherId = TeacherId;
                    loginfile("chinh sua", class1);
                }

            }
            var classJson1 = JsonConvert.SerializeObject(classList, Formatting.Indented);
            File.WriteAllText(ClassMenu.datafile, classJson1);
            Console.WriteLine("Ban da nhap thanh cong");
            Console.WriteLine("*** Danh sach sau khi sua doi tuong ***");
            ShowList();
        }
        public override void Delete(int Id)
        {
            var classjson = File.ReadAllText(ClassMenu.datafile);
            List<Class> classList = JsonConvert.DeserializeObject<List<Class>>(classjson);
            foreach (var class1 in classList.ToList())
            {
                if (class1.Id == Id)
                {
                    loginfile("xoa",class1);
                    classList.Remove(class1);
                }
            }
            var classJson1 = JsonConvert.SerializeObject(classList, Formatting.Indented);
            File.WriteAllText(ClassMenu.datafile, classJson1);
            Console.WriteLine("Ban da xoa thanh cong");
            Console.WriteLine("*** Danh sach sau khi xoa doi tuong ***");
            ShowList();
        }
        public void ContinueClass()
        {
            Console.WriteLine("*** Ban co muon thuc hien tiep thao tac voi doi tuong Class khong ***\n");
            Console.WriteLine("*** Nhan 1 de tiep tuc or other de thoat ***\n");
            String choise = Console.ReadLine();
            if (choise == "1")
            {
                ClassMenu Classmenu = new ClassMenu();
                Classmenu.Option();
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
                    Console.WriteLine("*** Ban hay lua chon thao tac voi doi tuong Class ");
                    int choise = Convert.ToInt32(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            ShowList();
                            ContinueClass();
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
                                        ContinueClass();
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
                            ContinueClass();
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
                                        ContinueClass();
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
                                        ContinueClass();
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
                        default: kt = false; break;
                    }
                }
                catch
                {
                    kt = false ;
                }
            }
        }
    }
}
