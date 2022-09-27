using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1
{
    internal class Program
    {
        public void run()
        {
            bool kt = false;
            while (kt == false)
            {
                Console.WriteLine("******** Wellcome to my system *********** \n");
                Console.WriteLine("Chon 1 de thao tac voi doi tuong Student \n");
                Console.WriteLine("Chon 2 de thao tac voi doi tuong Teacher \n");
                Console.WriteLine("Chon 3 de thao tac voi doi tuong Class \n ");
                Console.WriteLine("Chon 4 de loc tat ca cac sinh vien chung 1 lop \n");
                Console.WriteLine("Chon 5 de tim tat ca cac sinh vien cua 1 giao vien \n");
                Console.WriteLine("Chon 6 de xem log file \n");
                Console.WriteLine("Chon 7 de thoat khoi chuong trinh \n ");
                Console.WriteLine(" ****** Moi ban nhap lua chon: *******\n");
                try
                {
                    int choise = Convert.ToInt32(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            StudentMenu studentmenu = new StudentMenu();
                            studentmenu.Option();
                            kt = true;
                            break;
                        case 2:
                            TeacherMenu Teachermenu = new TeacherMenu();
                            Teachermenu.Option();
                            kt = true;
                            break;
                        case 3:
                            ClassMenu classmenu = new ClassMenu();
                            classmenu.Option();
                            kt = true;
                            break;
                        case 4:
                            Console.WriteLine("*** Ban dang loc tat ca cac sinh vien chung 1 lop *** \n");
                            EnhancedFeature enhancedFeature = new EnhancedFeature();
                            enhancedFeature.StudentSameClass();
                            Console.WriteLine("*** Ban co muon tiep tuc khong ***\n");
                            Console.WriteLine("*** An 1 de tiep tuc or thoat ***");
                            String tx4 = Console.ReadLine();
                            if (tx4 == "1")
                            {
                                run();
                            }
                            else
                            {
                                Environment.Exit(0);
                            }
                            kt = true;
                            break;
                        case 5:
                            Console.WriteLine("*** Ban dang tim tat ca cac hoc sinh cua 1 giao vien ***\n");
                            EnhancedFeature enhanced = new EnhancedFeature();
                            enhanced.AllStudentOfTeacher();
                            Console.WriteLine("*** Ban co muon tiep tuc khong ***\n");
                            Console.WriteLine("*** An 1 de tiep tuc or thoat ***");
                            String tx5 = Console.ReadLine();
                            if (tx5 == "1")
                            {
                                run();
                            }
                            else
                            {
                                Environment.Exit(0);
                            }
                            kt = true;
                            break;
                        case 6: 
                            Console.WriteLine("*** Ban dang xem logfile ***");
                            InputHandling.readlogfile();
                            Console.WriteLine("*** Ban co muon tiep tuc khong ***\n");
                            Console.WriteLine("*** An 1 de tiep tuc or thoat ***");
                            String tx6 = Console.ReadLine();
                            if (tx6 =="1") { 
                            run();
                            } else
                            {
                                Environment.Exit(0);
                            }
                            kt = true;
                            break;
                        case 7:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("***  Ban da nhap Sai *** Xin moi nhap lai *** \n");
                            kt = false;
                            break;

                    }
                } 
                catch(Exception ex)
                {
                    Console.WriteLine("*** Ban da nhap Sai *** Xin moi nhap lai ***\n");
                    kt = false;
                } 
            }
        }
        static void Main(string[] args)
        {
            InputHandling.Initialization_Student();
            InputHandling.Initialization_Teacher();
            InputHandling.Initialization_Class();
            Program program = new Program();
            program.run();
        }
    }
}
