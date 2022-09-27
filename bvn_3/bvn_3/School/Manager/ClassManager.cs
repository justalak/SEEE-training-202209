using System;
using System.Collections.Generic;

namespace bvn_3.School.Manager
{
    [Serializable]
    public class ClassManager : ObjManager
    {
        public List<Class> listClass = null;
        public ClassManager()
        {
            listClass = new List<Class>();
        }
        private int AutoId()
        {
            int maxId = 1;
            if (listClass.Count > 0 && listClass != null)
            {
                foreach (Class c in listClass)
                {
                    if (c.Id > maxId)
                    {
                        maxId = c.Id;
                    }
                }
                maxId += 1;
            }
            return maxId;
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
            Console.WriteLine(listClass.Count);
            if (listClass != null && listClass.Count > 0)
            {
                Console.WriteLine("{0, -5} {1, -10} {2, -8}", "ID", "Name", "TeacherId");
                foreach (Class cl in listClass)
                {
                    Console.WriteLine("{0, -5} {1, -10} {2, -8}", cl.Id, cl.Name, cl.TeacherId);
                }
                Console.WriteLine();
            }
        }
        public override void DeleteData(int id)
        {
            if (listClass != null && listClass.Count > 0)
            {
                int delete = FindById(id, false);
                if (delete != -1)
                {
                    listClass.RemoveAt(delete);
                    Console.WriteLine("Deleted Class with id = " + id + "\n");
                }
                else
                {
                    Console.WriteLine("There is not Class with id = " + id + "\n");
                }
            }
            else
            {
                Console.WriteLine("There is no Class to delete\n");
            }
        }
        public override void AddData()
        {
            Class cl = new Class();

            cl.Id = AutoId();

            Console.Write("Input name: "); string s = Console.ReadLine();
            NameInput(ref s);
            cl.Name = s;

            Console.Write("Input teacherId: "); s = Console.ReadLine();
            TeacherIdInput(ref s);
            cl.TeacherId = Convert.ToInt32(s);

            listClass.Add(cl);
        }
        public override int FindById(int id, bool show)
        {
            int position = -1;
            if (listClass != null && listClass.Count > 0)
            {
                for (int i = 0; i < listClass.Count; i++)
                {
                    if (listClass[i].Id == id)
                    {
                        position = i;
                        if (show)
                        {
                            Console.WriteLine("{0, -5} {1, -10} {2, -8}", "ID", "Name", "TeacherId");
                            Console.WriteLine("{0, -5} {1, -10} {2, -8}", listClass[i].Id, listClass[i].Name, listClass[i].TeacherId);
                        }
                    }
                }
            }
            return position;
        }
        public override List<int> FindByName(string name, bool show)
        {
            List<int> position = new List<int>();
            if (listClass != null && listClass.Count > 0)
            {
                if (show)
                {
                    Console.WriteLine("{0, -5} {1, -10} {2, -8}", "ID", "Name", "TeacherId");
                }
                for (int i = 0; i < listClass.Count; i++)
                {
                    if (String.Compare(listClass[i].Name, name, true) == 0)
                    {
                        position.Add(i);
                        if (show)
                        {
                            Console.WriteLine("{0, -5} {1, -10} {2, -8}", listClass[i].Id, listClass[i].Name, listClass[i].TeacherId);
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
                listClass[update].Name = s;

                Console.Write("Input teacherId: "); s = Console.ReadLine();
                TeacherIdInput(ref s);
                listClass[update].TeacherId = Convert.ToInt32(s);
            }
            else
            {
                Console.WriteLine("There is not Class with id = " + id);
            }
        }
        public override void GoBack()
        {
            //throw new NotImplementedException();
        }
        private void TeacherIdInput(ref string s)
        {
            while (!IsLimitNumber(s, 20))
            {
                Console.Write("Please input valid teacherId or type 'quit': ");
                s = Console.ReadLine();
            }
        }
        public void Add(Class cl)
        {
            listClass.Add(cl);
        }

    }
}
