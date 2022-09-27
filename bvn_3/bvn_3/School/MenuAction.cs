using bvn_3.School.Manager;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace bvn_3.School
{
    public class MenuAction
    {
        ClassManager listCL;
        TeacherManager listTC;
        StudentManager listSt;
        public MenuAction()
        {
            listCL = JsonConvert.DeserializeObject<ClassManager>(File.ReadAllText("../../School/Data/dataClass.json"));
            listTC = JsonConvert.DeserializeObject<TeacherManager>(File.ReadAllText("../../School/Data/dataTeacher.json"));
            listSt = JsonConvert.DeserializeObject<StudentManager>(File.ReadAllText("../../School/Data/dataStudent.json"));
        }
        public void Menu()
        {
            string menuChoose = "";
            string[] menuList = { "1", "2", "3", "exit", "e" };
            string mainMenuChoose = "";
            do
            {
                MainMenu();
                InputChoose(ref menuChoose, menuList);
                switch (menuChoose)
                {
                    case "1":
                        mainMenuChoose = StudentAction();
                        break;
                    case "2":
                        mainMenuChoose = TeacherAction();
                        break;
                    case "3":
                        mainMenuChoose = ClassAction();
                        break;
                    case "exit":
                        return;
                    case "e":
                        return;
                }
            } while (mainMenuChoose == "0");
        }
        public void MainMenu()
        {
            Console.WriteLine("\n--------------------------------------------");
            Console.WriteLine("School Managerment System");
            Console.WriteLine("Choose an option below:");
            Console.WriteLine("     1. Student Managerment");
            Console.WriteLine("     2. Teacher Managerment");
            Console.WriteLine("     3. Class Managrment");
            Console.WriteLine("Type 'exit/e' to close the app.");
            Console.WriteLine("--------------------------------------------");
        }
        public string StudentAction()
        {
            string yourChoose = "";
            string[] optionList = { "1", "2", "3", "4", "5", "0" };
            do
            {
                Console.WriteLine("Choose an option below:");
                Console.WriteLine("     1. View student list");
                Console.WriteLine("     2. Search student");
                Console.WriteLine("     3. Add a student");
                Console.WriteLine("     4. Update a student");
                Console.WriteLine("     5. Delete a student");
                Console.WriteLine("     0. Go back to the previous menu");

                InputChoose(ref yourChoose, optionList);
                string s = "";
                switch (yourChoose)
                {
                    case "1":
                        listSt.ShowData();
                        break;
                    case "2":
                        Console.Write("Info search (name/Id): ");
                        string searchBy = SearchByNameOrId(ref s);
                        if (searchBy == "name")
                        {
                            listSt.FindByName(s, true);
                        }
                        else if (searchBy == "id")
                        {
                            listSt.FindById(Convert.ToInt32(s), true);
                        }
                        else if (searchBy == "wrong")
                        {
                            Console.WriteLine("Can not find!");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Add a student:");
                        listSt.AddData();
                        break;
                    case "4":
                        Console.Write("Update a student with id: ");
                        s = Console.ReadLine();
                        while (!IsDigital(s))
                        {
                            Console.Write("Wrong input, please input again: ");
                            s = Console.ReadLine();
                        }
                        listSt.UpdateData(Convert.ToInt32(s));
                        break;
                    case "5":
                        Console.Write("Delete a student with id: ");
                        s = Console.ReadLine();
                        while (!IsDigital(s))
                        {
                            Console.Write("Wrong input, please input again: ");
                            s = Console.ReadLine();
                        }
                        listSt.DeleteData(Convert.ToInt32(s));
                        break;
                }
            } while (yourChoose != "0");

            return yourChoose;
        }
        public string TeacherAction()
        {
            string yourChoose = "";
            string[] optionList = { "1", "2", "3", "4", "5", "0" };
            do
            {
                Console.WriteLine("Choose an option below:");
                Console.WriteLine("     1. View teacher list");
                Console.WriteLine("     2. Search teacher");
                Console.WriteLine("     3. Add a teacher");
                Console.WriteLine("     4. Update a teacher");
                Console.WriteLine("     5. Delete a teacher");
                Console.WriteLine("     0. Go back to the previous menu");

                InputChoose(ref yourChoose, optionList);
                string s = "";
                switch (yourChoose)
                {
                    case "1":
                        listTC.ShowData();
                        break;
                    case "2":
                        Console.Write("Info search (name/Id): ");
                        string searchBy = SearchByNameOrId(ref s);
                        if (searchBy == "name")
                        {
                            listTC.FindByName(s, true);
                        }
                        else if (searchBy == "id")
                        {
                            listTC.FindById(Convert.ToInt32(s), true);
                        }
                        else if (searchBy == "wrong")
                        {
                            Console.WriteLine("Can not find!");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Add a teacher:");
                        listTC.AddData();
                        break;
                    case "4":
                        Console.Write("Update a teacher with id: ");
                        s = Console.ReadLine();
                        while (!IsDigital(s))
                        {
                            Console.Write("Wrong input, please input again: ");
                            s = Console.ReadLine();
                        }
                        listTC.UpdateData(Convert.ToInt32(s));
                        break;
                    case "5":
                        Console.Write("Delete a teacher with id: ");
                        s = Console.ReadLine();
                        while (!IsDigital(s))
                        {
                            Console.Write("Wrong input, please input again: ");
                            s = Console.ReadLine();
                        }
                        listTC.DeleteData(Convert.ToInt32(s));
                        break;
                }
            } while (yourChoose != "0");

            return yourChoose;
        }
        public string ClassAction()
        {
            string yourChoose = "";
            string[] optionList = { "1", "2", "3", "4", "5", "0" };
            do
            {
                Console.WriteLine("Choose an option below:");
                Console.WriteLine("     1. View class list");
                Console.WriteLine("     2. Search class");
                Console.WriteLine("     3. Add a class");
                Console.WriteLine("     4. Update a class");
                Console.WriteLine("     5. Delete a class");
                Console.WriteLine("     0. Go back to the previous menu");

                InputChoose(ref yourChoose, optionList);
                string s = "";
                switch (yourChoose)
                {
                    case "1":
                        listCL.ShowData();
                        break;
                    case "2":
                        Console.Write("Info search (name/Id): ");
                        string searchBy = SearchByNameOrId(ref s);
                        if (searchBy == "name")
                        {
                            listCL.FindByName(s, true);
                        }
                        else if (searchBy == "id")
                        {
                            listCL.FindById(Convert.ToInt32(s), true);
                        }
                        else if (searchBy == "wrong")
                        {
                            Console.WriteLine("Can not find!");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Add a teacher:");
                        listCL.AddData();
                        break;
                    case "4":
                        Console.Write("Update a teacher with id: ");
                        s = Console.ReadLine();
                        while (!IsDigital(s))
                        {
                            Console.Write("Wrong input, please input again: ");
                            s = Console.ReadLine();
                        }
                        listCL.UpdateData(Convert.ToInt32(s));
                        break;
                    case "5":
                        Console.Write("Delete a teacher with id: ");
                        s = Console.ReadLine();
                        while (!IsDigital(s))
                        {
                            Console.Write("Wrong input, please input again: ");
                            s = Console.ReadLine();
                        }
                        listCL.DeleteData(Convert.ToInt32(s));
                        break;
                }
            } while (yourChoose != "0");

            return yourChoose;
        }
        public void InputChoose(ref string menuChoose, string[] menus)
        {
            Console.Write("Your choose: ");
            menuChoose = Console.ReadLine().ToLower();
            while (!menus.Contains(menuChoose))
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
                if (IsDigital(search))
                {
                    check = false;
                    return "id";
                }
                else if (IsText(search))
                {
                    check = false;
                    return "name";
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
