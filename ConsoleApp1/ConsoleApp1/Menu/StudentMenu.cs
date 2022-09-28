using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class StudentMenu : BaseMenu
    {
        public StudentMenu()
        {
            CreateStudentList();
        }
        public override void DisplayMenu()
        {
            Console.WriteLine("------------------------------------------\nSelect your option");
            Console.WriteLine("\n1. To show the list of Students");
            Console.WriteLine("2. To search for a Student info");
            Console.WriteLine("3. To add a Student info");
            Console.WriteLine("4. To edit info of a Student");
            Console.WriteLine("5. To delete info of a Student");
            Console.WriteLine("0. To go back to the last menu");
        }
        private List<Student> StudentList = new List<Student>();
        public void CreateStudentList()
        {
            StudentList = new List<Student>
            {
                new Student{Id="1",Name="Peter Griffin",Gender="Male",Email="ptgrif@gmail.com",PhoneNumber=0926539812, Score= 3.0, ClassId="123456"},
                new Student{Id="2",Name="Stewie Griffin",Gender="Male",Email="stgrif@gmail.com",PhoneNumber=0926539000, Score= 3.9, ClassId="123123"},
                new Student{Id="3",Name="Lois Griffin",Gender="Female",Email="lsgrif@gmail.com",PhoneNumber=0926539001, Score= 3.5, ClassId="123111"}
            };
        }
        public override void AddNew()
        {
            Student Student_add = new Student();
            Console.WriteLine("Enter Student Id:");
            Student_add.Id = Console.ReadLine();
            Console.WriteLine("Enter Student Name:");
            Student_add.Name = Console.ReadLine();
            Console.WriteLine("Enter Student Gender:");
            Student_add.Gender = Console.ReadLine();
            Console.WriteLine("Enter Student Email:");
            Student_add.Email = Console.ReadLine();
            Console.WriteLine("Enter Student PhoneNumber:");
            Student_add.PhoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Student Score:");
            Student_add.Score = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Student ClassId:");
            Student_add.ClassId = Console.ReadLine();
            StudentList.Add(Student_add);
            Console.WriteLine("Successfully added a Student info");

        }

        public override void Delete()
        {
            bool found = false;
            Student Student_delete = new Student();
            Console.WriteLine("Enter Student Id to delete:");
            Student_delete.Id = Console.ReadLine();
            int i = 0;
            int updateIndex = -1;
            foreach (Student aStudent in StudentList)
            {
                if (string.Compare(Student_delete.Id, aStudent.Id) == 0)
                {
                    
                    updateIndex = i;
                    break;
                }
                else
                {
                    Console.WriteLine("No students were found");
                }
                i++;
            }
            if (updateIndex == -1)
            {
                return;
            }
            StudentList.RemoveAt(updateIndex);
            Console.WriteLine("Successfully deleted a Student info");
        }

        public override void Find()
        {
            bool found = false;
            Student Student_find = new Student();
            Console.WriteLine("Enter student Id to find:");
            Student_find.Id = Console.ReadLine();
            foreach (Student aStudent in StudentList)
            {
                if (string.Compare(Student_find.Id, aStudent.Id) == 0)
                {
                    Console.WriteLine($"Student ID: {aStudent.Id}      Student Name: {aStudent.Name}          Student gender: {aStudent.Gender}          Student Email: {aStudent.Email}         Student PhoneNumber: {aStudent.PhoneNumber}          Student Score: {aStudent.Score}           Student ClassId: {aStudent.ClassId}");
                    found = true;
                }
                else
                {
                    Console.WriteLine("No students were found");
                }
            }
        }

        public override void ShowList()
        {
            foreach (Student aStudent in StudentList)
            {
                Console.WriteLine($"Student ID: {aStudent.Id}      Student Name: {aStudent.Name}          Student gender: {aStudent.Gender}          Student Email: {aStudent.Email}         Student PhoneNumber: {aStudent.PhoneNumber}          Student Score: {aStudent.Score}           Student ClassId: {aStudent.ClassId}");
            }
        }

        public override void Update()
        {
            bool found = false;
            Student Student_find = new Student();
            Console.WriteLine("Enter student Id to edit:");
            Student_find.Id = Console.ReadLine();
            int i = 0;
            int updateIndex = -1;
            foreach (Student aStudent in StudentList)
            {
                if (string.Compare(Student_find.Id, aStudent.Id) == 0)
                {
                    
                    updateIndex = i;
                    break;
                }
                else
                {
                    Console.WriteLine("No students were found");
                }
                i++;
            }
            if (updateIndex == -1)
            {

                return;
            }
            //Found
            Console.WriteLine($"Found the student with id {Student_find.Id}");
            Console.WriteLine($"Enter Student Name:");
            var StudentName = Console.ReadLine();
            Console.WriteLine($"Enter Student Gender:");
            var StudentGender = Console.ReadLine();
            Console.WriteLine($"Enter Student Email:");
            var StudentEmail = Console.ReadLine();
            Console.WriteLine("Enter Student PhoneNumber:");
            var StudentPNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Student Score:");
            var StudentScore = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Student ClassId:");
            var StudentClassId = Console.ReadLine();
            this.StudentList[updateIndex].Name = StudentName;
            this.StudentList[updateIndex].Gender = StudentGender;
            this.StudentList[updateIndex].Email = StudentEmail;
            this.StudentList[updateIndex].PhoneNumber = StudentPNumber;
            this.StudentList[updateIndex].Score = StudentScore;
            this.StudentList[updateIndex].ClassId = StudentClassId;
            Console.WriteLine("Successfully edited a Student info");

        }
    }
}
