using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class TeacherMenu : BaseMenu
    {
        public TeacherMenu()
        {
            CreateTeacherList();
        }
        public override void DisplayMenu()
        {
            Console.WriteLine("------------------------------------------\nSelect your option");
            Console.WriteLine("\n1. To show the list of Teachers");
            Console.WriteLine("2. To search for a Teacher");
            Console.WriteLine("3. To add a Teacher info");
            Console.WriteLine("4. To edit info of a Teacher");
            Console.WriteLine("5. To delete a Teacher info");
            Console.WriteLine("0. To go back to the last menu");
        }
        private List<Teacher> TeacherList = new List<Teacher>();
        public void CreateTeacherList()
        {
            TeacherList = new List<Teacher>
            {
                new Teacher {Id="1", Name= "Simpson"},
                new Teacher {Id="2", Name= "Margarret"},
                new Teacher {Id="3", Name= "Mathi"}
            };
        }

        public override void AddNew()
        {
            Teacher Teacher_add = new Teacher();
            Console.WriteLine("Enter class Id:");
            Teacher_add.Id = Console.ReadLine();
            Console.WriteLine("Enter class Name:");
            Teacher_add.Name = Console.ReadLine();
            TeacherList.Add(Teacher_add);
            Console.WriteLine("Sucessfully added a Teacher info");

        }

        public override void Delete()
        {
            bool found = false;
            Teacher Teacher_delete = new Teacher();
            Console.WriteLine("Enter Teacher Id to delete:");
            Teacher_delete.Id = Console.ReadLine();
            int i = 0;
            int updateIndex = -1;
            foreach (Teacher aTeacher in TeacherList)
            {
                if (string.Compare(Teacher_delete.Id, aTeacher.Id) == 0)
                {
                    
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
            TeacherList.RemoveAt(updateIndex);
            Console.WriteLine("Successfully deleted a Class");
        }

        public override void Find()
        {
            bool found = false;
            Teacher Teacher_find = new Teacher();
            Console.WriteLine("Enter Teacher Id to find:");
            Teacher_find.Id = Console.ReadLine();
            foreach (Class aTeacher in TeacherList)
            {
                if (string.Compare(Teacher_find.Id, aTeacher.Id) == 0)
                {
                    Console.WriteLine($"Teacher ID: {aTeacher.Id}      Teacher Name: {aTeacher.Name}");
                    found = true;
                }
                else
                {
                    Console.WriteLine("No teachers were found");
                }
            }
        }

        public override void ShowList()
        {
            foreach (Teacher aTeacher in TeacherList)
            {
                Console.WriteLine($"Teacher ID: {aTeacher.Id}      Teacher Name: {aTeacher.Name}");
            }

        }

        public override void Update()
        {

            bool found = false;
            Teacher Teacher_find = new Teacher();
            Console.WriteLine("Enter Teacher Id to edit:");
            Teacher_find.Id = Console.ReadLine();
            int i = 0;
            int updateIndex = -1;
            foreach (Teacher aTeacher in TeacherList)
            {
                if (string.Compare(Teacher_find.Id, aTeacher.Id) == 0)
                {
                    
                    updateIndex = i;
                    break;
                }
                else
                {
                    Console.WriteLine("No teachers were found");
                }
                i++;
            }
            if (updateIndex == -1)
            {

                return;
            }
            //Found
            Console.WriteLine($"Found the teacher with id {Teacher_find.Id}");
            Console.WriteLine($"Enter Teacher Name:");
            var teacherName = Console.ReadLine();
            this.TeacherList[updateIndex].Name = teacherName;
            Console.WriteLine("Successfully edited a Teacher info");
        }
    }
}
