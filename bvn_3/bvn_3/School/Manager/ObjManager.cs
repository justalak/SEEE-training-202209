using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace bvn_3.School.Manager
{
    [Serializable]
    public abstract class ObjManager
    {
        public abstract void MenuChoose();
        public abstract void DeleteData();
        public abstract void ShowData();
        public abstract void AddData();
        public abstract int FindById(int id, bool show);
        public abstract List<int> FindByName(string name, bool show);
        public abstract void UpdateData();
        public abstract void CloseFile();

        //check
        protected bool IsName(string name)
        {
            Regex regex = new Regex("\\w+");
            return regex.IsMatch(name);
        }
        protected void NameInput(ref string s)
        {
            while (string.IsNullOrEmpty(s) || !IsName(s))
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

        }
        protected bool IsLimitNumber(string score, int limit)
        {
            if (score.Length <= 2 && IsDigital(score))
            {
                int checkScore = Convert.ToInt32(score);
                if (checkScore < limit)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        protected bool IsDigital(string number)
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
        protected string SearchByNameOrId(ref string search)
        {
            bool check = true;
            do
            {
                search = Console.ReadLine().ToLower();
                if (string.IsNullOrEmpty(search))
                {
                    Console.Write("Wrong, please input again: ");
                }
                else if (IsDigital(search))
                {
                    check = false;
                    return "id";
                }
                else if (IsName(search))
                {
                    check = false;
                    return "name";
                }
                else
                {
                    Console.Write("Wrong, please input again: ");
                }
            } while (check);
            return "wrong";
        }
        protected List<int> GetTeacherId()
        {
            List<Teacher> listTeacher = JsonConvert.DeserializeObject<List<Teacher>>(File.ReadAllText("../../School/Data/dataTeacher.json"));
            List<int> result = new List<int>();
            result.Add(0);
            foreach (Teacher tc in listTeacher)
            {
                result.Add(tc.Id);
            }
            return result;
        }
        protected List<int> GetClassId()
        {
            List<Class> listClass = JsonConvert.DeserializeObject<List<Class>>(File.ReadAllText("../../School/Data/dataClass.json"));
            List<int> result = new List<int>();
            result.Add(0);
            foreach (Class cl in listClass)
            {
                result.Add(cl.Id);
            }
            return result;
        }
    }
}
