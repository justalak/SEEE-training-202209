using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace bvn_3.School.Manager
{
    [Serializable]
    public class ClassManager : ObjManager
    {
        public List<Class> listClass = null;
        public ClassManager()
        {
            listClass = JsonConvert.DeserializeObject<List<Class>>(File.ReadAllText("../../School/Data/dataClass.json"));
            if (listClass == null || listClass.Count == 0)
            {
                Logger.WriteLog("\tFalsed to load class data");
            }
        }
        public int AutoId()
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
                Console.WriteLine(); Logger.WriteLog("\tShown list of classes");
            }
            else
            {
                Logger.WriteLog("\tCan not show list of classes");
            }
        }
        public override void DeleteData()
        {
            Console.Write("Delete at id: ");
            string s = Console.ReadLine();
            while (string.IsNullOrEmpty(s) || !IsDigital(s))
            {
                Console.Write("Wrong input, please input again: ");
                s = Console.ReadLine();
            }
            int id = Convert.ToInt32(s);
            if (listClass != null && listClass.Count > 0)
            {
                int delete = FindById(id, false);
                if (delete != -1)
                {
                    listClass.RemoveAt(delete);
                    Console.WriteLine("Deleted Class with id = " + id + "\n");
                    Logger.WriteLog("\tDeleted at id = " + s);
                }
                else
                {
                    Console.WriteLine("There is not Class with id = " + id + "\n");
                    Logger.WriteLog("\tCan not delete at id = " + s);
                }
            }
            else
            {
                Console.WriteLine("There is no Class to delete\n");
                Logger.WriteLog("\tCan not delete at id = " + s);
            }
        }
        public override void AddData()
        {
            Console.WriteLine("Add:");
            Class cl = new Class();
            cl.Id = AutoId();
            Console.Write("Input name: "); string s = Console.ReadLine();
            do
            {
                NameInput(ref s);
            } while (!BeUnique(s));
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
                            Logger.WriteLog("\tSearched");
                        }
                    }
                }
            }
            if (show && position == -1)
            {
                Logger.WriteLog("\tCan not search");
            }
            return position;
        }
        public override List<int> FindByName(string name, bool show)
        {
            List<int> position = new List<int>();
            if (listClass != null && listClass.Count > 0)
            {
                for (int i = 0; i < listClass.Count; i++)
                {
                    if (String.Compare(listClass[i].Name, name, true) == 0)
                    {
                        position.Add(i);
                        if (show)
                        {
                            Console.WriteLine("{0, -5} {1, -10} {2, -8}", "ID", "Name", "TeacherId");
                            Console.WriteLine("{0, -5} {1, -10} {2, -8}", listClass[i].Id, listClass[i].Name, listClass[i].TeacherId);
                        }
                    }
                }
            }
            if (show && position.Count > 0)
            {
                Logger.WriteLog("\tSearched");
            }
            else if (show && position.Count == 0)
            {
                Logger.WriteLog("\tCan not search");
            }
            return position;
        }
        public override void UpdateData()
        {
            Console.Write("Update at id: ");
            string s = Console.ReadLine();
            while (string.IsNullOrEmpty(s) || !IsDigital(s))
            {
                Console.Write("Wrong input, please input again: ");
                s = Console.ReadLine();
            }
            int id = Convert.ToInt32(s);
            int update = FindById(id, false);
            if (update != -1)
            {
                Console.Write("Input name: "); s = Console.ReadLine();
                NameInput(ref s);
                listClass[update].Name = s;
                Console.Write("Input teacherId: "); s = Console.ReadLine();
                TeacherIdInput(ref s);
                listClass[update].TeacherId = Convert.ToInt32(s);
                Logger.WriteLog("\tUpdated at id = " + s);
            }
            else
            {
                Console.WriteLine("There is not Class with id = " + id);
                Logger.WriteLog("\tCan not update at id = " + s);
            }
        }
        public override void CloseFile()
        {
            if (listClass != null && listClass.Count > 0)
            {
                string data = JsonConvert.SerializeObject(listClass);
                System.IO.File.WriteAllText("../../School/Data/dataClass.json", data);
            }
        }
        private void TeacherIdInput(ref string s)
        {
            while (string.IsNullOrEmpty(s) || !IsLimitNumber(s, 50) || !GetTeacherId().Contains(Convert.ToInt32(s)))
            {
                if (!GetClassId().Contains(Convert.ToInt32(s)))
                    Console.WriteLine("No have teacher id = " + s);
                Console.Write("Please input valid teacherId or type 'quit': ");
                s = Console.ReadLine();
            }
        }
        private bool BeUnique(string name)
        {
            foreach (Class cl in listClass)
            {
                if (String.Compare(cl.Name, name, true) == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public List<int> FindClassSameTeacher(int id)
        {
            List<int> idCL = new List<int>();
            if (listClass != null && listClass.Count > 0)
            {
                foreach (Class cl in listClass)
                {
                    if (cl.TeacherId == id)
                    {
                        idCL.Add(cl.Id);
                    }
                }
            }
            else
            {
                Console.WriteLine("No data!");
            }
            return idCL;
        }
    }
}
