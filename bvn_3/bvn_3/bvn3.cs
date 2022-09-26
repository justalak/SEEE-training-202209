using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace bvn_3
{
    internal class bvn3
    {
        static void Main(string[] args)
        {
            StudentManager listSt = new StudentManager();
            string text = File.ReadAllText("../../dataStudent.json");
            listSt = JsonConvert.DeserializeObject<StudentManager>(text);

            Menu(listSt);
        }

        static void Menu(StudentManager listSt)
        {
            string menuChoose = "";
            string[] menuList = { "1", "2", "3", "exit", "e" };
            string optionChoose = "";
            string[] optionList = { "1", "2", "3", "4", "5", "0" };
            do
            {
                MenuObj();
                inputChoose(ref menuChoose, menuList);
                switch (menuChoose)
                {
                    case "1":
                        optionChoose = StudentAction(optionList, listSt);
                        break;
                    case "2":
                        TeacherManager();
                        inputChoose(ref optionChoose, optionList);
                        break;
                    case "3":
                        ClassManager();
                        inputChoose(ref optionChoose, optionList);
                        break;
                    case "exit":
                        return;
                    case "e":
                        return;
                }
            } while (optionChoose == "0");
        }
        static void inputChoose(ref string menuChoose, string[] menus)
        {
            Console.Write("Your choose: ");
            menuChoose = Console.ReadLine().ToLower();
            while (!menus.Contains(menuChoose))
            {
                Console.Write("Wrong choose: ");
                menuChoose = Console.ReadLine();
            }
        }
        static void MenuObj()
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
        static void TeacherManager()
        {
            Console.WriteLine("Choose an option below:");
            Console.WriteLine(" 1. View teacher list");
            Console.WriteLine(" 2. Search teacher");
            Console.WriteLine(" 3. Add a teacher");
            Console.WriteLine(" 4. Update a teacher");
            Console.WriteLine(" 5. Delete a teacher");
            Console.WriteLine(" 0. Go back to the previous menu");
        }
        static void ClassManager()
        {
            Console.WriteLine("Choose an option below:");
            Console.WriteLine(" 1. View class list");
            Console.WriteLine(" 2. Search class");
            Console.WriteLine(" 3. Add a class");
            Console.WriteLine(" 4. Update a class");
            Console.WriteLine(" 5. Delete a class");
            Console.WriteLine(" 0. Go back to the previous menu");
        }
        static string StudentAction(string[] optionList, StudentManager listSt)
        {
            string yourChoose = "";
            do
            {
                Console.WriteLine("Choose an option below:");
                Console.WriteLine("     1. View student list");
                Console.WriteLine("     2. Search student");
                Console.WriteLine("     3. Add a student");
                Console.WriteLine("     4. Update a student");
                Console.WriteLine("     5. Delete a student");
                Console.WriteLine("     0. Go back to the previous menu");

                inputChoose(ref yourChoose, optionList);
                switch (yourChoose)
                {
                    case "1":
                        listSt.Show();
                        break;
                    case "2":
                        listSt.FindById(20).Show();
                        Console.WriteLine();
                        break;
                    case "3":
                        listSt.AddStudent(new Student() { Id = 21, Name = "vd", Gender = "male", Email = "vd@att.net", PhoneNumber = "0988877296", Score = 10, ClassId = 10 });
                        listSt.Show();
                        break;
                    case "4":
                        listSt.AddStudent(new Student() { Id = 21, Name = "vd", Gender = "male", Email = "vd@att.net", PhoneNumber = "0988877296", Score = 10, ClassId = 10 });
                        listSt.Update(21);
                        listSt.Show();
                        break;
                    case "5":
                        listSt.AddStudent(new Student() { Id = 21, Name = "vd", Gender = "male", Email = "vd@att.net", PhoneNumber = "0988877296", Score = 10, ClassId = 10 });
                        listSt.DeleteById(21);
                        break;
                }
            } while (yourChoose != "0");

            return yourChoose;
        }
    }
}





//listSt.AddStudent(new Student() { Id = 1, Name = "Averie Rocha", Gender = "female", Email = "clkao@att.net", PhoneNumber = "0111111111", Score = 10, ClassId = 1 });
//listSt.AddStudent(new Student() { Id = 2, Name = "Sasha Gould", Gender = "female", Email = "kannan@icloud.com", PhoneNumber = "0222222222", Score = 20, ClassId = 2 });
//listSt.AddStudent(new Student() { Id = 3, Name = "Azul Kelley", Gender = "male", Email = "jbarta@mac.com", PhoneNumber = "0333333333", Score = 30, ClassId = 3 });
//listSt.AddStudent(new Student() { Id = 4, Name = "Yasmine Page", Gender = "male", Email = "willg@live.com", PhoneNumber = "0444444444", Score = 40, ClassId = 2 });
//listSt.AddStudent(new Student() { Id = 5, Name = "Kellen Peterson", Gender = "female", Email = "lamprecht@gmail.com", PhoneNumber = "0555555555", Score = 50, ClassId = 3 });
//listSt.AddStudent(new Student() { Id = 6, Name = "Gisselle Mejia", Gender = "female", Email = "miyop@comcast.net", PhoneNumber = "0666666666", Score = 60, ClassId = 3 });
//listSt.AddStudent(new Student() { Id = 7, Name = "Darius Wells", Gender = "male", Email = "earmstro@att.net", PhoneNumber = "0777777777", Score = 70, ClassId = 2 });
//listSt.AddStudent(new Student() { Id = 8, Name = "Lucy Underwood", Gender = "female", Email = "presoff@yahoo.com", PhoneNumber = "0888888888", Score = 80, ClassId = 1 });
//listSt.AddStudent(new Student() { Id = 9, Name = "Wade Santos", Gender = "male", Email = "skythe@aol.com", PhoneNumber = "0999999999", Score = 90, ClassId = 1 });
//listSt.AddStudent(new Student() { Id = 10, Name = "Deanna Cummings", Gender = "female", Email = "pierce@msn.com", PhoneNumber = "0122222222", Score = 5, ClassId = 2 });
//listSt.AddStudent(new Student() { Id = 11, Name = "Carsen Lin", Gender = "female", Email = "hllam@live.com", PhoneNumber = "0322222222", Score = 15, ClassId = 1 });
//listSt.AddStudent(new Student() { Id = 12, Name = "Davin Atkinson", Gender = "male", Email = "mastinfo@hotmail.com", PhoneNumber = "0433333333", Score = 25, ClassId = 1 });
//listSt.AddStudent(new Student() { Id = 13, Name = "Evie Fisher", Gender = "female", Email = "nichoj@sbcglobal.net", PhoneNumber = "0544444444", Score = 35, ClassId = 3 });
//listSt.AddStudent(new Student() { Id = 14, Name = "Ishaan Steele", Gender = "male", Email = "thurston@live.com", PhoneNumber = "0655555555", Score = 45, ClassId = 2 });
//listSt.AddStudent(new Student() { Id = 15, Name = "Iliana Archer", Gender = "female", Email = "akoblin@optonline.net", PhoneNumber = "0766666666", Score = 55, ClassId = 1 });
//listSt.AddStudent(new Student() { Id = 16, Name = "Kaliyah Logan", Gender = "male", Email = "raines@verizon.net", PhoneNumber = "0877777777", Score = 65, ClassId = 3 });
//listSt.AddStudent(new Student() { Id = 17, Name = "Mylie Barr", Gender = "female", Email = "oracle@mac.com", PhoneNumber = "0877777777", Score = 75, ClassId = 2 });
//listSt.AddStudent(new Student() { Id = 18, Name = "Pranav Spence", Gender = "female", Email = "miyop@comcast.net", PhoneNumber = "0988888888", Score = 85, ClassId = 1 });
//listSt.AddStudent(new Student() { Id = 19, Name = "Lucy Underwood", Gender = "male", Email = "duncand@icloud.com", PhoneNumber = "0099999999", Score = 95, ClassId = 3 });
//listSt.AddStudent(new Student() { Id = 20, Name = "Devan Gilbert", Gender = "male", Email = "parsimony@outlook.com", PhoneNumber = "0112222222", Score = 25, ClassId = 1 });


//var ss = JsonConvert.SerializeObject(listSt);
//var jF = JsonConvert.DeserializeObject<StudentManager>(ss);
//File.WriteAllText(@"datast.json", ss);

//string text = File.ReadAllText("datast.json");
//StudentManager cjf = JsonConvert.DeserializeObject<StudentManager>(text);

//cjf.Show();
