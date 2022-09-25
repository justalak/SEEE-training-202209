using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace bvn_3
{
    [Serializable]
    internal class StudentManager
    {
        public List<Student> listStudent = null;
        public StudentManager()
        {
            listStudent = new List<Student>();
        }
        private int AutoId()
        {
            int maxId = 1;
            if (listStudent.Count > 0 && listStudent != null)
            {
                maxId = listStudent.Count + 1;
            }
            return maxId;
        }

        // method for input ------------------------------------------------------------------------------
        public void Input()
        {
            Student st = new Student();

            st.Id = AutoId();

            Console.Write("Input name: "); string s = Console.ReadLine();
            NameInput(ref s, ref st);

            Console.Write("Input gender (male/female/other): "); s = Console.ReadLine();
            GenderInput(ref s, ref st);

            Console.Write("Input email: "); s = Console.ReadLine();
            EmailInput(ref s, ref st);

            Console.Write("Input phone: "); s = Console.ReadLine();
            PhoneInput(ref s, ref st);

            Console.Write("Input score: "); s = Console.ReadLine();
            ScoreInput(ref s, ref st);

            Console.Write("Input classId: "); s = Console.ReadLine();
            ClassIdInput(ref s, ref st);

            listStudent.Add(st);
        }
        protected bool IsName(string name)
        {
            Regex regex = new Regex("\\w+");
            return regex.IsMatch(name);
        }
        private bool IsEmail(string email)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
            return emailRegex.IsMatch(email);
        }
        private bool IsPhone(string phone)
        {
            if (phone[0] == '0' && phone.Length == 10 && IsDigital(phone))
            {
                return true;
            }
            return false;
        }
        private bool IsScore(string score)
        {
            if (score.Length <= 2 && IsDigital(score))
            {
                return true;
            }
            return false;
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
        private void NameInput(ref string s, ref Student st)
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
            st.Name = s;
        }
        private void GenderInput(ref string s, ref Student st)
        {
            s.ToLower();
            while (s != "male" && s != "female" && s != "other")
            {
                Console.Write("Please input valid gender or type 'quit': ");
                s = Console.ReadLine();
                s.ToLower();
            }
            st.Gender = s;
        }
        private void EmailInput(ref string s, ref Student st)
        {
            while (!IsEmail(s))
            {
                Console.Write("Please input valid email or type 'quit': ");
                s = Console.ReadLine();
            }
            st.Email = s;
        }
        private void PhoneInput(ref string s, ref Student st)
        {
            while (!IsPhone(s))
            {
                Console.Write("Please input valid phone or type 'quit': ");
                s = Console.ReadLine();
            }
            st.PhoneNumber = s;
        }
        private void ScoreInput(ref string s, ref Student st)
        {
            while (!IsScore(s))
            {
                Console.Write("Please input valid score or type 'quit': ");
                s = Console.ReadLine();
            }
            st.Score = Convert.ToInt32(s);
        }
        private void ClassIdInput(ref string s, ref Student st)
        {
            while (!IsScore(s))
            {
                Console.Write("Please input valid classId or type 'quit': ");
                s = Console.ReadLine();
            }
            st.ClassId = Convert.ToInt32(s);
        }
        // end method for input --------------------------------------------------------------------------


        // For Update student ----------------------------------------------------------------------------
        public void Update(int id)
        {
            Student st = FindById(id);
            if (st != null)
            {
                Console.Write("Input name: "); string s = Console.ReadLine();
                NameInput(ref s, ref st);

                Console.Write("Input gender (male/female/other): "); s = Console.ReadLine();
                GenderInput(ref s, ref st);

                Console.Write("Input email: "); s = Console.ReadLine();
                EmailInput(ref s, ref st);

                Console.Write("Input phone: "); s = Console.ReadLine();
                PhoneInput(ref s, ref st);

                Console.Write("Input score: "); s = Console.ReadLine();
                ScoreInput(ref s, ref st);

                Console.Write("Input classId: "); s = Console.ReadLine();
                ClassIdInput(ref s, ref st);
            }
            else
            {
                Console.WriteLine("There is not student with id = " + id);
            }
        }
        public Student FindById(int id)
        {
            Student searchResult = null;
            if (listStudent != null && listStudent.Count > 0)
            {
                foreach (Student st in listStudent)
                {
                    if (st.Id == id)
                    {
                        searchResult = st;
                    }
                }
            }
            return searchResult;
        }
        public List<Student> FindByName(string name)
        {
            List<Student> searchResult = null;
            if (listStudent != null && listStudent.Count > 0)
            {
                foreach (Student st in listStudent)
                {
                    if (st.Name == name)
                    {
                        searchResult.Add(st);
                    }
                }
            }
            return searchResult;
        }
        public void DeleteById(int id)
        {
            if (listStudent != null && listStudent.Count > 0)
            {
                Student st = FindById(id);
                if (st != null)
                {
                    listStudent.Remove(st);
                    Console.WriteLine("Deleted student with id = " + id + "\n");
                }
                else
                {
                    Console.WriteLine("There is not student with id = " + id + "\n");
                }
            }
            else
            {
                Console.WriteLine("There is no student to delete\n");
            }
        }
        // End for update student ------------------------------------------------------------------------

        public void Show()
        {
            if (listStudent != null && listStudent.Count > 0)
            {
                Console.WriteLine("{0, -5} {1, -20} {2, -8} {3, -25} {4, -12} {5, -5} {6, -5}",
                                "ID", "Name", "Gender", "Email", "PhoneNumber", "Score", "ClassId");
                foreach (Student st in listStudent)
                {
                    Console.WriteLine("{0, -5} {1, -20} {2, -8} {3, -25} {4, -12} {5, -5} {6, -5}",
                                      st.Id, st.Name, st.Gender, st.Email, st.PhoneNumber, st.Score, st.ClassId);
                }
                Console.WriteLine();
            }
        }
        public void AddStudent(Student st)
        {
            listStudent.Add(st);
        }
    }
}
