using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace bvn_3.School.Manager
{
    [Serializable]
    public abstract class ObjManager
    {
        public abstract void MenuChoose();
        public abstract void ShowData();
        public abstract void DeleteData(int id);
        public abstract void AddData();
        public abstract int FindById(int id, bool show);
        public abstract List<int> FindByName(string name, bool show);
        public abstract void UpdateData(int id);
        public abstract void GoBack();

        //check
        protected bool IsName(string name)
        {
            Regex regex = new Regex("\\w+");
            return regex.IsMatch(name);
        }
        protected void NameInput(ref string s)
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
    }
}
