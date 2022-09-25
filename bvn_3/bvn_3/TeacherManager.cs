using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace bvn_3
{
    [Serializable]
    internal class TeacherManager
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
                maxId = listTeacher.Count + 1;
            }
            return maxId;
        }

        // method for input ------------------------------------------------------------------------------
        public void Input()
        {
            Teacher tc = new Teacher();

            tc.Id = AutoId();

            Console.Write("Input name: "); string s = Console.ReadLine();
            NameInput(ref s, ref tc);

            listTeacher.Add(tc);
        }
        protected bool IsName(string name)
        {
            Regex regex = new Regex("\\w+");
            return regex.IsMatch(name);
        }
        private void NameInput(ref string s, ref Teacher tc)
        {
            while (!IsName(s))
            {
                Console.Write("Please input valid name or type 'quit': ");
                s = Console.ReadLine();
            }
            char[] charArray = s.ToLower().ToCharArray(); bool foundSpace = true;
            for (int i = 0; i < charArray.Length; i++)
            {
                if (Char.IsLetter(charArray[i]))
                {
                    if (foundSpace)
                    {
                        charArray[i] = Char.ToUpper(charArray[i]);
                        foundSpace = false;
                    }
                }
                else
                {
                    foundSpace = true;
                }
            }
            s = new string(charArray);
            tc.Name = s;
        }
        // end method for input --------------------------------------------------------------------------


        // For Update Teacher ----------------------------------------------------------------------------
        public void Update(int id)
        {
            Teacher tc = FindById(id);
            if (tc != null)
            {
                Console.Write("Input name: "); string s = Console.ReadLine();
                NameInput(ref s, ref tc);
            }
            else
            {
                Console.WriteLine("There is not Teacher with id = " + id);
            }
        }
        public Teacher FindById(int id)
        {
            Teacher searchResult = null;
            if (listTeacher != null && listTeacher.Count > 0)
            {
                foreach (Teacher tc in listTeacher)
                {
                    if (tc.Id == id)
                    {
                        searchResult = tc;
                    }
                }
            }
            return searchResult;
        }
        public List<Teacher> FindByName(string name)
        {
            List<Teacher> searchResult = null;
            if (listTeacher != null && listTeacher.Count > 0)
            {
                foreach (Teacher tc in listTeacher)
                {
                    if (tc.Name == name)
                    {
                        searchResult.Add(tc);
                    }
                }
            }
            return searchResult;
        }
        public void DeleteById(int id)
        {
            if (listTeacher != null && listTeacher.Count > 0)
            {
                Teacher tc = FindById(id);
                if (tc != null)
                {
                    listTeacher.Remove(tc);
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
        // End for update Teacher ------------------------------------------------------------------------

        public void Show()
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
        public void AddTeacher(Teacher tc)
        {
            listTeacher.Add(tc);
        }
    }
}
