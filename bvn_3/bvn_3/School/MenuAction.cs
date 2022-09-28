using bvn_3.School;
using bvn_3.School.Manager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace bvn_3.School
{
    public class MenuAction
    {
        public void Menu()
        {
            string menuChoose = "";
            string[] menuList = { "1", "2", "3", "4", "e" };
            ObjManager menu = null;
            Logger.WriteLog("--- Started new session ---");
            do
            {
                Console.WriteLine("\n--------------------------------------------");
                Console.WriteLine("School Managerment System");
                Console.WriteLine("Choose an option below:");
                Console.WriteLine("     1. Student Managerment");
                Console.WriteLine("     2. Teacher Managerment");
                Console.WriteLine("     3. Class Managrment");
                Console.WriteLine("     4. Other");
                Console.WriteLine("Type 'e' to close the app.");
                Console.WriteLine("--------------------------------------------");
                InputChoose(ref menuChoose, menuList);
                switch (menuChoose)
                {
                    case "1":
                        menu = new StudentManager();
                        Logger.WriteLog("  Student Manager:");
                        break;
                    case "2":
                        menu = new TeacherManager();
                        Logger.WriteLog("  Teacher Manager:");
                        break;
                    case "3":
                        menu = new ClassManager();
                        Logger.WriteLog("  Class Manager:");
                        break;
                    case "4":
                        Other();
                        Logger.WriteLog("  Other");
                        break;
                    case "e":
                        Logger.WriteLog("-------    Ended    -------");
                        return;
                }
                if (menuChoose == "1" || menuChoose == "2" || menuChoose == "3")
                {
                    string yourChoose = "";
                    string[] optionList = { "1", "2", "3", "4", "5", "0" };
                    string s = "";
                    do
                    {
                        menu.MenuChoose();
                        InputChoose(ref yourChoose, optionList);
                        switch (yourChoose)
                        {
                            case "1":
                                menu.ShowData(); Console.WriteLine();
                                break;
                            case "2":
                                Console.Write("Info search (name/Id): ");
                                string searchBy = SearchByNameOrId(ref s);
                                if (searchBy == "name")
                                {
                                    menu.FindByName(s, true);
                                }
                                else if (searchBy == "id")
                                {
                                    menu.FindById(Convert.ToInt32(s), true);
                                }
                                Console.WriteLine();
                                break;
                            case "3":
                                menu.AddData(); Console.WriteLine();
                                break;
                            case "4":
                                menu.UpdateData(); Console.WriteLine();
                                break;
                            case "5":
                                menu.DeleteData(); Console.WriteLine();
                                break;
                        }
                    } while (yourChoose != "0");
                    menu.CloseFile();
                    Logger.WriteLog("  Closed");
                }
            } while (true);
        }
        public void Other()
        {
            string yourChoose = "";
            string[] optionList = { "1", "2", "0" };
            ClassManager listCL = new ClassManager();
            StudentManager listST = new StudentManager();
            TeacherManager listTC = new TeacherManager();
            do
            {
                Console.WriteLine("Choose an option below:");
                Console.WriteLine("     1. Student same class");
                Console.WriteLine("     2. Student same teacher");
                Console.WriteLine("     0. Go back to the previous menu");

                InputChoose(ref yourChoose, optionList);
                switch (yourChoose)
                {
                    case "1":
                        FindStudentSameClass(listCL, listST); Console.WriteLine();
                        break;
                    case "2":
                        FindStudentSameTeacher(listCL, listST, listTC); Console.WriteLine();
                        break;
                }
            } while (yourChoose != "0");
        }

        public void FindStudentSameClass(ClassManager listCL, StudentManager listST)
        {
            Console.Write("id class: "); string s = Console.ReadLine();
            while (string.IsNullOrEmpty(s) || !IsDigital(s))
            {
                Console.Write("Wrong input, please input again: ");
                s = Console.ReadLine();
            }
            int id = listCL.FindById(Convert.ToInt32(s), false);
            if (id == -1)
            {
                Console.WriteLine("No have class id = " + s);
            }
            else
            {
                List<int> idd = new List<int>(); idd.Add(Convert.ToInt32(s));
                listST.FindStudentSameClass(idd);
                Logger.WriteLog("\tFinded Students same class");
            }
        }
        public void FindStudentSameTeacher(ClassManager listCL, StudentManager listST, TeacherManager listTC)
        {
            Console.Write("id teacher: "); string s = Console.ReadLine();
            while (string.IsNullOrEmpty(s) || !IsDigital(s))
            {
                Console.Write("Wrong input, please input again: ");
                s = Console.ReadLine();
            }
            int id = listTC.FindById(Convert.ToInt32(s), false);
            if (id == -1)
            {
                Console.WriteLine("No have class id = " + s);
            }
            else
            {
                List<int> idd = listCL.FindClassSameTeacher(Convert.ToInt32(s));
                listST.FindStudentSameClass(idd);
                Logger.WriteLog("\tFinded Students same teacher");
            }
        }

        public void InputChoose(ref string menuChoose, string[] menus)
        {
            Console.Write("Your choose: ");
            menuChoose = Console.ReadLine().ToLower();
            while (!menus.Contains(menuChoose) || string.IsNullOrEmpty(menuChoose))
            {
                Console.Write("Wrong choose, please choose again: ");
                menuChoose = Console.ReadLine();
            }
        }
        public string SearchByNameOrId(ref string search)
        {
            bool check = true;
            do
            {
                search = Console.ReadLine().ToLower();
                if (string.IsNullOrEmpty(search))
                {
                    Console.Write("Wrong, please input again: ");
                }
                else if (IsDigital(search))
                {
                    check = false;
                    return "id";
                }
                else if (IsText(search))
                {
                    check = false;
                    return "name";
                }
                else
                {
                    Console.Write("Wrong, please input again: ");
                }
            } while (check);
            return "wrong";
        }
        protected bool IsDigital(string number)
        {
            foreach (var c in number)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }
        protected bool IsText(string text)
        {
            Regex regex = new Regex("\\w+");
            return regex.IsMatch(text);
        }
    }
}