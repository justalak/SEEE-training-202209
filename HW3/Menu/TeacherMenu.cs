using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    internal class TeacherMenu : BaseMenuTeacher
    {
        public Teacher FindTeacherId(ref List<Teacher> list)
        {
            Console.Write("Input Id:   ");
            int SearchId = Convert.ToInt32(Console.ReadLine());
            foreach (Teacher teacher in list)
            {
                if (teacher.TeacherId == SearchId)
                {
                    return teacher;
                }
            }
            Teacher var = new Teacher();
            return var;
        }
        public Teacher FindTeacherName(ref List<Teacher> list)
        {
            Console.Write("Input Name:   ");
            string SearchName = Console.ReadLine();
            foreach (Teacher teacher in list)
            {
                if (teacher.name == SearchName)
                {
                    return teacher;
                }
            }
            Teacher var = new Teacher();
            return var;
        }
        public override void AddNew(ref List<Teacher> list)
        {
            Console.WriteLine();
            Console.WriteLine("Fill in this form : ");

        b: Console.Write("Teacher Id :  ");
            int id;
            try
            {
                id = Convert.ToInt32(Console.ReadLine());
                foreach (Teacher teacher in list)
                {
                    if (id == teacher.TeacherId)
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

            Console.Write("Teacher Name :  ");
            string name = Console.ReadLine();

            Teacher newteacher = new Teacher(id, name);
            list.Add(newteacher);

        }

        public override void Delete(ref List<Teacher> list)
        {

            Console.Write("Delete by Id/Name:   ");
            string deleteOption = Console.ReadLine().ToLower();
            string comment = "";
            switch (deleteOption)
            {
                case "id":
                    Console.Write("Input Id:   ");
                    int Id = Convert.ToInt32(Console.ReadLine());
                    foreach (Teacher teacher in list)
                    {
                        if (teacher.TeacherId == Id)
                        {
                            list.Remove(teacher);
                            comment = "Teacher has been removed !";
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

                    foreach (Teacher teacher in list)
                    {
                        if (teacher.name == name)
                        {
                            list.Remove(teacher);
                            comment = "Teacher has been removed !";
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

        public override void Search(ref List<Teacher> list)
        {
            Console.Write("Search by Id/Name:   ");
            string Findobject = Console.ReadLine().ToLower();
            switch (Findobject)
            {
                case "id":
                    Teacher foundId = FindTeacherId(ref list);
                    if (foundId.name == null)
                    {
                        Console.WriteLine("Teacher not found");
                    }
                    else
                    {
                        Console.Write(foundId.TeacherId + "      ");
                        Console.Write(foundId.name + "      ");
                        Console.WriteLine();
                    }
                    break;
                case "name":
                    Teacher foundName = FindTeacherName(ref list);
                    if (foundName.name == null)
                    {
                        Console.WriteLine("Teacher not found");
                    }
                    else
                    {
                        Console.Write(foundName.TeacherId + "      ");
                        Console.Write(foundName.name + "      ");
                        Console.WriteLine();
                    }
                    break;
            }

        }

        public override void ShowList(ref List<Teacher> list)
        {
            Console.WriteLine("Viewing Teacher List");
            Console.WriteLine();
            CreateTable(list);
        }

        public override void Update(ref List<Teacher> list)
        {
        a: Console.Write("Update by Id/Name:   ");
            string Updateobject = Console.ReadLine().ToLower();
            switch (Updateobject)
            {
                case "id":
                    Teacher UpdateTcId = FindTeacherId(ref list);
                    if (UpdateTcId.name == null)
                    {
                        Console.WriteLine("Teacher not found !");
                    }
                    else
                    {
                        Console.Write(UpdateTcId.TeacherId + "      ");
                        Console.Write(UpdateTcId.name + "      ");
                        Console.WriteLine();
                    k: Console.Write("Change Id:   ");
                        try
                        {
                            UpdateTcId.TeacherId = Convert.ToInt32(Console.ReadLine());
                            foreach (Teacher teacher in list)
                            {
                                if (UpdateTcId.TeacherId == teacher.TeacherId)
                                {
                                    Console.WriteLine("Existed Id try another:");
                                    goto k;
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Id must be number try another");
                            goto k;
                        }

                        Console.Write("Change Name:   ");
                        UpdateTcId.name = Console.ReadLine();

                    }
                    break;
                case "name":
                    Teacher UpdateTcname = FindTeacherName(ref list);
                    if (UpdateTcname.name == null)
                    {
                        Console.WriteLine("Teacher not found !");
                    }
                    else
                    {
                        Console.Write(UpdateTcname.TeacherId + "      ");
                        Console.Write(UpdateTcname.name + "      ");
                        Console.WriteLine();
                    h: Console.Write("Change Id:   ");
                        try
                        {
                            UpdateTcname.TeacherId = Convert.ToInt32(Console.ReadLine());
                            foreach (Teacher teacher in list)
                            {
                                if (UpdateTcname.TeacherId == teacher.TeacherId)
                                {
                                    Console.WriteLine("Existed Id try another:");
                                    goto h;
                                }
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Id must be number try another");
                            goto h;
                        }

                        Console.Write("Change Name:   ");
                        UpdateTcname.name = Console.ReadLine();
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    goto a;
            }
        }
        public static DataTable TeacherTable(ref List<Teacher> list)
        {
            var table = new DataTable();
            table.Columns.Add("TeacherId", typeof(int));
            table.Columns.Add("Name", typeof(string));

            foreach (Teacher teacher in list)
            {
                table.Rows.Add(teacher.TeacherId, teacher.name);
            }
            return table;
        }
        public void CreateTable(List<Teacher> list)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var data = TeacherTable(ref list);
            string[] columnNames = data.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray();

            DataRow[] rows = data.Select();

            var table = new ConsoleTable(columnNames);
            foreach (DataRow row in rows)
            {
                table.AddRow(row.ItemArray);
            }
            //table.Write(Format.MarkDown);
            table.Write(Format.Alternative);
            //table.Write(Format.Minimal);
            //table.Write(Format.Default);

        }
    }
}
