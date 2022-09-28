using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HW3
{
    internal class ClassMenu : BaseMenuClass
    {
        public Class FindClassName(ref List<Class> list)
        {
            Console.Write("Input Class Name:   ");
            string SearchClassName = Console.ReadLine();
            foreach (Class item in list)
            {
                if (item.ClassName == SearchClassName)
                {
                    return item;
                }
            }
            Class var = new Class();
            return var;
        }
        public override void AddNew(ref List<Class> list)
        {
            Console.WriteLine();
            Console.WriteLine("Fill in this form : ");

        l: Console.Write("Class Id :  ");
            int id;
            try
            {
                id = Convert.ToInt32(Console.ReadLine());
                foreach (Class item in list)
                {
                    if (id == item.Id)
                    {
                        Console.WriteLine("Existed Id try another:");
                        goto l;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Id must be number try another");
                goto l;
            }

            Console.Write("Class Name:  ");
            string classname = Console.ReadLine();

            Console.Write("Teacher Name:  ");
            string teachername = Console.ReadLine();

            Class newclass = new Class(id, classname, teachername);
            list.Add(newclass);

        }

        public override void Delete(ref List<Class> list)
        {
            string comment = "";
            Console.Write("Input Name:   ");
            string name = Console.ReadLine().ToLower();

            foreach (Class item in list)
            {
                if (item.ClassName == name)
                {
                    list.Remove(item);
                    comment = "Class has been removed !";
                    break;
                }
                else
                {
                    comment = "Invalid Class Name try another one ";
                }
            }
            Console.WriteLine(comment);

        }

        public override void Search(ref List<Class> list)
        {
            Class foundClass = FindClassName(ref list);
            if (foundClass.ClassName == null)
            {
                Console.WriteLine("Class not found");
            }
            else
            {
                Console.Write(foundClass.Id + "      ");
                Console.Write(foundClass.ClassName + "      ");
                Console.Write(foundClass.Teacher_Name + "      ");
                Console.WriteLine();
            }
        }

        public override void ShowList(ref List<Class> list)
        {
            Console.WriteLine("Viewing Class List");
            Console.WriteLine();
            
                CreateTable(list);
        }

        public override void Update(ref List<Class> list)
        {
            Class UpdateClass = FindClassName(ref list);
            if (UpdateClass.ClassName == null)
            {
                Console.WriteLine("Class not found !");
            }
            else
            {
                Console.Write(UpdateClass.Id + "      ");
                Console.Write(UpdateClass.ClassName + "      ");
                Console.Write(UpdateClass.Teacher_Name + "      ");
                Console.WriteLine();
            p: Console.Write("Change Id:   ");
                try
                {
                    UpdateClass.Id = Convert.ToInt32(Console.ReadLine());
                    foreach (Class item in list)
                    {
                        if (UpdateClass.Id == item.Id)
                        {
                            Console.WriteLine("Existed Id try another:");
                            goto p;
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Id must be number try another");
                    goto p;
                }

                Console.Write("Change Class Name:   ");
                UpdateClass.ClassName = Console.ReadLine();

                Console.Write("Change Class Teacher :   ");
                UpdateClass.Teacher_Name = Console.ReadLine();


            }
        }
        public static DataTable ClassTable(ref List<Class> list)
        {
            var table = new DataTable();
            table.Columns.Add("ClassId", typeof(int));
            table.Columns.Add("ClassName", typeof(string));
            table.Columns.Add("TeacherName", typeof(string));

            foreach (Class item in list)
            {
                table.Rows.Add(item.Id, item.ClassName, item.Teacher_Name);
            }
            return table;
        }
        public void CreateTable(List<Class> list)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var data = ClassTable(ref list);
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
            //table.Write(Format.Alternative);
            table.Write(Format.Minimal);
            //table.Write(Format.Default);

        }
    }
}
