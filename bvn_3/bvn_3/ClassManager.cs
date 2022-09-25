using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace bvn_3
{
    [Serializable]
    internal class ClassManager
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
                maxId = listClass.Count + 1;
            }
            return maxId;
        }

        // method for input ------------------------------------------------------------------------------
        public void Input()
        {
            Class cl = new Class();

            cl.Id = AutoId();

            Console.Write("Input name: "); string s = Console.ReadLine();
            NameInput(ref s, ref cl);

            Console.Write("Input teacherId: "); s = Console.ReadLine();
            TeacherIdInput(ref s, ref cl);

            listClass.Add(cl);
        }
        protected bool IsName(string name)
        {
            Regex regex = new Regex("\\w+");
            return regex.IsMatch(name);
        }
        private bool IsDigital(string number)
        {
            foreach (var c in number)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }
        private bool IsScore(string score)
        {
            if (score.Length <= 2 && IsDigital(score))
            {
                return true;
            }
            return false;
        }
        private void NameInput(ref string s, ref Class cl)
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
            cl.Name = s;
        }
        private void TeacherIdInput(ref string s, ref Class cl)
        {
            while (!IsScore(s))
            {
                Console.Write("Please input valid teacherId or type 'quit': ");
                s = Console.ReadLine();
            }
            cl.TeacherId = Convert.ToInt32(s);
        }
        // end method for input --------------------------------------------------------------------------


        // For Update Class ----------------------------------------------------------------------------
        public void Update(int id)
        {
            Class cl = FindById(id);
            if (cl != null)
            {
                Console.Write("Input name: "); string s = Console.ReadLine();
                NameInput(ref s, ref cl);

                Console.Write("Input teacherId: "); s = Console.ReadLine();
                TeacherIdInput(ref s, ref cl);
            }
            else
            {
                Console.WriteLine("There is not Class with id = " + id);
            }
        }
        public Class FindById(int id)
        {
            Class searchResult = null;
            if (listClass != null && listClass.Count > 0)
            {
                foreach (Class cl in listClass)
                {
                    if (cl.Id == id)
                    {
                        searchResult = cl;
                    }
                }
            }
            return searchResult;
        }
        public List<Class> FindByName(string name)
        {
            List<Class> searchResult = null;
            if (listClass != null && listClass.Count > 0)
            {
                foreach (Class cl in listClass)
                {
                    if (cl.Name == name)
                    {
                        searchResult.Add(cl);
                    }
                }
            }
            return searchResult;
        }
        public void DeleteById(int id)
        {
            if (listClass != null && listClass.Count > 0)
            {
                Class cl = FindById(id);
                if (cl != null)
                {
                    listClass.Remove(cl);
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
        // End for update Class ------------------------------------------------------------------------

        public void Show()
        {
            if (listClass != null && listClass.Count > 0)
            {
                Console.WriteLine("{0, -5} {1, -20} {6, -5}", "ID", "Name", "TeacherId");
                foreach (Class cl in listClass)
                {
                    Console.WriteLine("{0, -5} {1, -20} {6, -5}", cl.Id, cl.Name, cl.TeacherId);
                }
                Console.WriteLine();
            }
        }
        public void AddClass(Class cl)
        {
            listClass.Add(cl);
        }
    }
}
