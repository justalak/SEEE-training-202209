using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace bvn_3.School.Manager
{
    [Serializable]
    public class TeacherManager : ObjManager
    {
        public List<Teacher> listTeacher = null;
        public TeacherManager()
        {
            listTeacher = JsonConvert.DeserializeObject<List<Teacher>>(File.ReadAllText("../../School/Data/dataTeacher.json"));
            if (listTeacher == null || listTeacher.Count == 0)
            {
                Logger.WriteLog("\tFalsed to load teacher data");
            }
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
        public override void MenuChoose()
        {
            Console.WriteLine("Choose an option below:");
            Console.WriteLine("     1. View teacher list");
            Console.WriteLine("     2. Search teacher");
            Console.WriteLine("     3. Add a teacher");
            Console.WriteLine("     4. Update a teacher");
            Console.WriteLine("     5. Delete a teacher");
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
                Console.WriteLine(); Logger.WriteLog("\tShown list of teachers");
            }
            else
            {
                Logger.WriteLog("\tCan not show list of teachers");
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
            if (listTeacher != null && listTeacher.Count > 0)
            {
                int delete = FindById(id, false);
                if (delete != -1)
                {
                    listTeacher.Remove(listTeacher[delete]);
                    Console.WriteLine("Deleted Teacher with id = " + id + "\n");
                    Logger.WriteLog("\tDeleted at id = " + s);
                }
                else
                {
                    Console.WriteLine("There is not Teacher with id = " + id + "\n");
                    Logger.WriteLog("\tCan not delete at id = " + s);
                }
            }
            else
            {
                Console.WriteLine("There is no Teacher to delete\n");
                Logger.WriteLog("\tCan not delete at id = " + s);
            }
        }
        public override void AddData()
        {
            Console.WriteLine("Add:");
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
                listTeacher[update].Name = s;
                Logger.WriteLog("\tUpdated at id = " + s);
            }
            else
            {
                Console.WriteLine("There is not Teacher with id = " + id);
                Logger.WriteLog("\tCan not update at id = " + s);
            }
        }
        public override void CloseFile()
        {
            if (listTeacher != null && listTeacher.Count > 0)
            {
                string data = JsonConvert.SerializeObject(listTeacher);
                System.IO.File.WriteAllText("../../School/Data/dataTeacher.json", data);
            }
        }

    }
}