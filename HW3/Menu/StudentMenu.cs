using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    internal class StudentMenu : BaseMenuStudent
    {
        public Student FindStudentId(ref List<Student> list)
        {
            Console.Write("Input Id:   ");
            int SearchId = Convert.ToInt32(Console.ReadLine());
            foreach (Student student in list)
            {
                if (student.id == SearchId)
                {
                    return student;
                }
            }
            Student var = new Student();
            return var;
        }
        public Student FindStudentName(ref List<Student> list)
        {
            Console.Write("Input Name:   ");
            string SearchName = Console.ReadLine();
            foreach (Student student in list)
            {
                if (student.name == SearchName)
                {
                    return student;
                }
            }
            Student var = new Student();
            return var;
        }

        public override void AddNew(ref List<Student> list)
        {
            Console.WriteLine();
            Console.WriteLine("Fill in this form : ");

        b: Console.Write("Student Id:  ");
            int id;
            try
            {
                id = Convert.ToInt32(Console.ReadLine());
                foreach (Student student in list)
                {
                    if (id == student.id)
                    {
                        Console.WriteLine("Existed Id try another:");
                        goto b;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Id must be number try another");
                goto b;
            }

            Console.Write("Student Name:  ");
            string name = Console.ReadLine();

            Console.Write("Gender:  ");
            string gender = Console.ReadLine();

            Console.Write("Email:  ");
            string email = Console.ReadLine();

            Console.Write("Phone Number:  ");
            string phoneNumber = Console.ReadLine();

        c: Console.Write("Score:  ");
            double score;
            try
            {

                score = Convert.ToDouble(Console.ReadLine());
                if (0 > score || score > 10)
                {
                    Console.WriteLine("Invalid Score");
                    goto c;
                }
            }
            catch
            {
                Console.WriteLine("Score must be digit try again");
                goto c;
            }

            Console.Write("Class Id:  ");
            string classId = Console.ReadLine();

            Student newstudent = new Student(id, name, gender, email, phoneNumber, score, classId);
            list.Add(newstudent);
            
        }

        public override void Delete(ref List<Student> list)
        {
            Console.Write("Delete by Id/Name:   ");
            string deleteOption = Console.ReadLine().ToLower();
            string comment = "";
            switch (deleteOption)
            {

                case "id":
                    Console.Write("Input Id:   ");
                    int Id = Convert.ToInt32(Console.ReadLine());
                    foreach (Student student in list)
                    {
                        if (student.id == Id)
                        {
                            list.Remove(student);
                            comment = "Student has been removed !";
                            break;
                        }
                        else
                        {
                            comment = "Invalid ID try another one ";
                        }
                    }
                    Console.WriteLine(comment);
                    break;
                case "name":
                    Console.Write("Input Name:   ");
                    string name = Console.ReadLine().ToLower();

                    foreach (Student student in list)
                    {
                        if (student.name == name)
                        {
                            list.Remove(student);
                            comment = "Student has been removed !";
                            break;
                        }
                        else
                        {
                            comment = "Invalid Name try another one ";
                        }
                    }
                    Console.WriteLine(comment);
                    break;
            }
        }

        public override void Search(ref List<Student> list)
        {
            Console.Write("Search by Id/Name:   ");
            string Findobject = Console.ReadLine().ToLower();
            switch (Findobject)
            {
                case "id":
                    Student foundId = FindStudentId(ref list);
                    if (foundId.name == null)
                    {
                        Console.WriteLine("Student not found");
                    }
                    else
                    {
                        Console.Write(foundId.id + "      ");
                        Console.Write(foundId.name + "      ");
                        Console.Write(foundId.gender + "      ");
                        Console.Write(foundId.email + "      ");
                        Console.Write(foundId.score + "      ");
                        Console.Write(foundId.classId + "      ");
                        Console.WriteLine();
                    }
                    break;
                case "name":
                    Student foundName = FindStudentName(ref list);
                    if (foundName.name == null)
                    {
                        Console.WriteLine("Student not found");
                    }
                    else
                    {
                        Console.Write(foundName.id + "      ");
                        Console.Write(foundName.name + "      ");
                        Console.Write(foundName.gender + "      ");
                        Console.Write(foundName.email + "      ");
                        Console.Write(foundName.score + "      ");
                        Console.Write(foundName.classId + "      ");
                        Console.WriteLine();
                    }
                    break;
            }


        }

        public override void ShowList(List<Student> list)
        {
            Console.WriteLine("Viewing Student List");
            Console.WriteLine();
            CreateTable(list);
        }

        public override void Update(ref List<Student> list)
        {
        a: Console.Write("Update by Id/Name:   ");
            string Updateobject = Console.ReadLine().ToLower();
            switch (Updateobject)
            {
                case "id":
                    Student UpdateStdId = FindStudentId(ref list);
                    if (UpdateStdId.name == null)
                    {
                        Console.WriteLine("Student not found !");
                    }
                    else
                    {
                        Console.Write(UpdateStdId.id + "      ");
                        Console.Write(UpdateStdId.name + "      ");
                        Console.Write(UpdateStdId.gender + "      ");
                        Console.Write(UpdateStdId.email + "      ");
                        Console.Write(UpdateStdId.phoneNumber + "      ");
                        Console.Write(UpdateStdId.score + "      ");
                        Console.Write(UpdateStdId.classId + "      ");
                        Console.WriteLine();
                    c: Console.Write("Change Id:   ");

                        try
                        {
                            UpdateStdId.id = Convert.ToInt32(Console.ReadLine());
                            foreach (Student student in list)
                            {
                                if (UpdateStdId.id == student.id)
                                {
                                    Console.WriteLine("Existed Id try another:");
                                    goto c;
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Id must be number try another");
                            goto c;
                        }

                        Console.Write("Change Name:   ");
                        UpdateStdId.name = Console.ReadLine();

                        Console.Write("Change Gender:   ");
                        UpdateStdId.gender = Console.ReadLine();

                        Console.Write("Change Email:   ");
                        UpdateStdId.email = Console.ReadLine();

                    d:  Console.Write("Change Score:   ");

                        try
                        {
                            UpdateStdId.score = Convert.ToDouble(Console.ReadLine());
                            if (0 > UpdateStdId.score || UpdateStdId.score > 10)
                            {
                                Console.WriteLine("Invalid Score");
                                goto d;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Score must be digit try again");
                            goto d;
                        }

                        Console.Write("Change ClassID:   ");
                        UpdateStdId.classId = Console.ReadLine();
                    }
                    break;
                case "name":
                    Student UpdateStdname = FindStudentName(ref list);
                    if (UpdateStdname.name == null)
                    {
                        Console.WriteLine("Student not found !");
                    }
                    else
                    {
                        Console.Write(UpdateStdname.id + "      ");
                        Console.Write(UpdateStdname.name + "      ");
                        Console.Write(UpdateStdname.gender + "      ");
                        Console.Write(UpdateStdname.email + "      ");
                        Console.Write(UpdateStdname.phoneNumber + "      ");
                        Console.Write(UpdateStdname.score + "      ");
                        Console.Write(UpdateStdname.classId + "      ");
                        Console.WriteLine();
                        e:  Console.Write("Change Id:   ");
                        try
                        {
                            UpdateStdname.id = Convert.ToInt32(Console.ReadLine());
                            foreach (Student student in list)
                            {
                                if (UpdateStdname.id == student.id)
                                {
                                    Console.WriteLine("Existed Id try another:");
                                    goto e;
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Id must be number try another");
                            goto e;
                        }

                        Console.Write("Change Name:   ");
                        UpdateStdname.name = Console.ReadLine();

                        Console.Write("Change Gender :   ");
                        UpdateStdname.gender = Console.ReadLine();

                        Console.Write("Change Email:   ");
                        UpdateStdname.email = Console.ReadLine();

                        f: Console.Write("Change Score:   ");
                        try
                        {
                            UpdateStdname.score = Convert.ToDouble(Console.ReadLine());
                            if (0 > UpdateStdname.score || UpdateStdname.score > 10)
                            {
                                Console.WriteLine("Invalid Score");
                                goto f;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Score must be digit try again");
                            goto f;
                        }

                        Console.Write("Change ClassID:   ");
                        UpdateStdname.classId = Console.ReadLine();
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    goto a;
            }
        }
        public static DataTable StudentTable(ref List<Student> list)
        {
            var table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Gender", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Phone Number", typeof(string));
            table.Columns.Add("Score", typeof(double));
            table.Columns.Add("ClassID", typeof(string));
            foreach(Student student in list)
            {
                table.Rows.Add(student.id, student.name, student.gender, student.email, student.phoneNumber, student.score, student.classId);
                
            }
            return table;
        }
        public void CreateTable(List<Student> list)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var data = StudentTable(ref list);
            string[] columnNames = data.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray();

            DataRow[] rows = data.Select();

            var table = new ConsoleTable(columnNames);
            foreach (DataRow row in rows)
            {
                table.AddRow(row.ItemArray);
            }
            table.Write(Format.MarkDown);
            //table.Write(Format.Alternative);
            //table.Write(Format.Minimal);
            //table.Write(Format.Default);
            
        }
        public override void StudentSameClass(List<Student> list)
        {            
            Console.WriteLine("Input Class Name:");
            string ClassName = Console.ReadLine().ToUpper();
            foreach (Student student in list.ToList())
            {
                if (student.classId != ClassName)
                {
                    list.Remove(student);
                }
            }
           CreateTable(list);
        }


    }
}
