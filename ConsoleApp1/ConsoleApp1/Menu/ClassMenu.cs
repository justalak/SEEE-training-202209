using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class ClassMenu : BaseMenu
    {
        public ClassMenu()
        {
            CreateClassList();
        }
        public override void DisplayMenu()
        {
            Console.WriteLine("------------------------------------------\nSelect your option");
            Console.WriteLine("\n1. To show the list of Classes");
            Console.WriteLine("2. To search for a Class");
            Console.WriteLine("3. To add a Class");
            Console.WriteLine("4. To edit info of a Class");
            Console.WriteLine("5. To delete a Class");
            Console.WriteLine("0. To go back to the last menu");
        }
        private List<Class> ClassList = new List<Class>();
        public void CreateClassList()
        {
            ClassList = new List<Class>
            {
                new Class {Id="1", Name= "Biology", TeacherId="123123"},
                new Class {Id="2", Name= "Science", TeacherId="123000"},
                new Class {Id="3", Name= "Math", TeacherId="123001"}
            };
        }

        public override void AddNew()
        {
            Class Class_add = new Class();
            Console.WriteLine("Enter class Id:");
            Class_add.Id = Console.ReadLine();
            Console.WriteLine("Enter class Name:");
            Class_add.Name = Console.ReadLine();
            Console.WriteLine("Enter TeacherId:");
            Class_add.TeacherId = Console.ReadLine();
            ClassList.Add(Class_add);
            Console.WriteLine("Sucessfully added a Class");

        }

        public override void Delete()
        {
            bool found = false;
            Class Class_delete = new Class();
            Console.WriteLine("Enter class Id to delete:");
            Class_delete.Id = Console.ReadLine();
            int i = 0;
            int updateIndex = -1;
            foreach (Class aClass in ClassList)
            {
                if (string.Compare(Class_delete.Id, aClass.Id) == 0)
                {
                    Console.WriteLine(aClass);
                    updateIndex = i;
                    break;
                }
                else
                {
                    Console.WriteLine("No classes were found");
                }
                i++;
            }
            if (updateIndex == -1)
            {
                return;
            }
            ClassList.RemoveAt(updateIndex);
            Console.WriteLine("Successfully deleted a Class");
        }

        public override void Find()
        {
            bool found = false;
            Class Class_find = new Class();
            Console.WriteLine("Enter class Id to find:");
            Class_find.Id = Console.ReadLine();
            foreach(Class aClass in ClassList)
            {
                if(string.Compare(Class_find.Id,aClass.Id)==0)
                {
                    Console.WriteLine(aClass);
                    found = true;
                }
                else
                {
                    Console.WriteLine("No classes were found");
                }
            }
        }

        public override void ShowList()
        {
            foreach (Class aClass in ClassList)
            {
                Console.WriteLine($"Class ID: {aClass.Id}      Class Name: {aClass.Name}          Class TeacherId: {aClass.TeacherId}");
            }
            
        }

        public override void Update()
        {

            bool found = false;
            Class Class_find = new Class();
            Console.WriteLine("Enter class Id to edit:");
            Class_find.Id = Console.ReadLine();
            int i = 0;
            int updateIndex = -1;
            foreach (Class aClass in ClassList)
            {
                if (string.Compare(Class_find.Id, aClass.Id) == 0)
                {
                    Console.WriteLine(aClass);
                    updateIndex = i;
                    break;
                }
                else
                {
                    Console.WriteLine("No classes were found");
                }
                i++;
            }
            if (updateIndex == -1)
            {

                return;
            }
            //Found
            Console.WriteLine($"Found the class with id {Class_find.Id}");
            Console.WriteLine($"Enter Class Name:");
            var className = Console.ReadLine();
            Console.WriteLine($"Enter Class TeacherId:");
            var classTeacher = Console.ReadLine();
            this.ClassList[updateIndex].Name = className;
            this.ClassList[updateIndex].TeacherId = classTeacher;
            Console.WriteLine("Successfully edited a Class");
        }
    }
}
