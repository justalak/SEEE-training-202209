using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("\n------Welcome to School Managemnet System!------\n");
            while (true)
            {
                Console.WriteLine("\n\nPress Enter to continue\n\n--------------------------------------------");
                Console.ReadLine();
                Console.WriteLine("Select your option");
                Console.WriteLine("\n1. To select Student");
                Console.WriteLine("2. To select Teacher");
                Console.WriteLine("3. To select Class");

                int menuType = 0;
                menuType = Convert.ToInt32(Console.ReadLine());
                BaseMenu menu;
            
                switch (menuType)
                {
                    case 1:
                        menu = new StudentMenu();
                        //menu.DisplayMenu();
                        break;
                    case 2:
                        menu = new TeacherMenu();
                        //menu.DisplayMenu();
                        break;
                    case 3:
                        menu = new ClassMenu();
                        //menu.DisplayMenu();
                        break;
                    default:
                        throw new Exception("Invalid");
                }

                while (true)
                {
                    menu.DisplayMenu();
                    int action = 6;
                    action = Convert.ToInt32(Console.ReadLine());
                    switch (action)
                    {
                        case 1:
                            menu.ShowList();
                            break;
                        case 2:
                            menu.Find();
                            break;
                        case 3:
                            menu.AddNew();
                            break;
                        case 4:
                            menu.Update();
                            break;
                        case 5:
                            menu.Delete();
                            break;
                        case 0:
                            menu.Back();
                            break;
                        default:
                            throw new Exception("Invalid");
                    }
                    if (action == 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
