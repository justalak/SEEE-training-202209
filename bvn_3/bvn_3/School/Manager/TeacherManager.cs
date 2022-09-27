using System;
using System.Collections.Generic;

namespace bvn_3.School.Manager
{
    [Serializable]
    public class TeacherManager : ObjManager
    {
        public List<Teacher> listTeacher = null;
        public TeacherManager()
        {
            listTeacher = new List<Teacher>();
        }
        private int AutoId()
        {
            int maxId = 1;
            if (listTeacher.Count > 0 && listTeacher != null)
            {
                foreach (Teacher tc in listTeacher)
                {
                    if (tc.Id > maxId)
                    {
                        maxId = tc.Id;
                    }
                }
                maxId += 1;
            }
            return maxId;
        }
        public void AddTeacher(Teacher tc)
        {
            listTeacher.Add(tc);
        }
        public override void MenuChoose()
        {
            Console.WriteLine("Choose an option below:");
            Console.WriteLine("     1. View class list");
            Console.WriteLine("     2. Search class");
            Console.WriteLine("     3. Add a class");
            Console.WriteLine("     4. Update a class");
            Console.WriteLine("     5. Delete a class");
            Console.WriteLine("     0. Go back to the previous menu");
        }
        public override void ShowData()
        {
            if (listTeacher != null && listTeacher.Count > 0)
            {
                Console.WriteLine("{0, -5} {1, -20}", "ID", "Name");
                foreach (Teacher tc in listTeacher)
                {
                    Console.WriteLine("{0, -5} {1, -20}", tc.Id, tc.Name);
                }
                Console.WriteLine();
            }
        }
        public override void DeleteData(int id)
        {
            if (listTeacher != null && listTeacher.Count > 0)
            {
                int delete = FindById(id, false);
                if (delete != -1)
                {
                    listTeacher.Remove(listTeacher[delete]);
                    Console.WriteLine("Deleted Teacher with id = " + id + "\n");
                }
                else
                {
                    Console.WriteLine("There is not Teacher with id = " + id + "\n");
                }
            }
            else
            {
                Console.WriteLine("There is no Teacher to delete\n");
            }
        }
        public override void AddData()
        {
            Teacher tc = new Teacher();

            tc.Id = AutoId();

            Console.Write("Input name: "); string s = Console.ReadLine();
            NameInput(ref s);
            tc.Name = s;

            listTeacher.Add(tc);
        }
        public override int FindById(int id, bool show)
        {
            int position = -1;
            if (listTeacher != null && listTeacher.Count > 0)
            {
                for (int i = 0; i < listTeacher.Count; i++)
                {
                    if (listTeacher[i].Id == id)
                    {
                        position = i;
                        if (show)
                        {
                            Console.WriteLine("{0, -5} {1, -20}", "ID", "Name");
                            Console.WriteLine("{0, -5} {1, -20}", listTeacher[i].Id, listTeacher[i].Name);
                        }
                    }
                }
            }
            return position;
        }
        public override List<int> FindByName(string name, bool show)
        {
            List<int> position = new List<int>();
            if (listTeacher != null && listTeacher.Count > 0)
            {
                if (show)
                {
                    Console.WriteLine("{0, -5} {1, -20}", "ID", "Name");
                }
                for (int i = 0; i < listTeacher.Count; i++)
                {
                    if (String.Compare(listTeacher[i].Name, name, true) == 0)
                    {
                        position.Add(i);
                        if (show)
                        {
                            Console.WriteLine("{0, -5} {1, -20}", listTeacher[i].Id, listTeacher[i].Name);
                        }
                    }
                }
            }
            return position;
        }
        public override void UpdateData(int id)
        {
            int update = FindById(id, false);
            if (update != -1)
            {
                Console.Write("Input name: "); string s = Console.ReadLine();
                NameInput(ref s);

                listTeacher[update].Name = s;
            }
            else
            {
                Console.WriteLine("There is not Teacher with id = " + id);
            }
        }
        public override void GoBack()
        {
            throw new NotImplementedException();
        }
    }
}