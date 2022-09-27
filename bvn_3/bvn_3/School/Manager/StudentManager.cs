using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace bvn_3.School.Manager
{
    [Serializable]
    public class StudentManager : ObjManager
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
                foreach (Student st in listStudent)
                {
                    if (st.Id > maxId)
                    {
                        maxId = st.Id;
                    }
                }
                maxId += 1;
            }
            return maxId;
        }
        public override void MenuChoose()
        {
            Console.WriteLine("Choose an option below:");
            Console.WriteLine("     1. View student list");
            Console.WriteLine("     2. Search student");
            Console.WriteLine("     3. Add a student");
            Console.WriteLine("     4. Update a student");
            Console.WriteLine("     5. Delete a student");
            Console.WriteLine("     0. Go back to the previous menu");
        }
        public override void ShowData()
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
        public override void DeleteData(int id)
        {
            if (listStudent != null && listStudent.Count > 0)
            {
                int index = FindById(id, false);
                if (index != -1)
                {
                    listStudent.RemoveAt(index);
                    Console.WriteLine("Deleted student with id = " + id + "\n");
                }
                else
                {
                    Console.WriteLine("There is not student with id = " + id + "\n");
                }
            }
            else
            {
                Console.WriteLine("There is no student data\n");
            }
        }
        public override void AddData()
        {
            Student st = new Student();

            st.Id = AutoId();

            Console.Write("Input name: "); string s = Console.ReadLine();
            NameInput(ref s);
            st.Name = s;

            Console.Write("Input gender (male/female/other): "); s = Console.ReadLine();
            GenderInput(ref s);
            st.Gender = s;

            Console.Write("Input email: "); s = Console.ReadLine();
            EmailInput(ref s);
            st.Email = s;

            Console.Write("Input phone: "); s = Console.ReadLine();
            PhoneInput(ref s);
            st.PhoneNumber = s;

            Console.Write("Input score: "); s = Console.ReadLine();
            ScoreInput(ref s);
            st.Score = Convert.ToInt32(s);

            Console.Write("Input classId: "); s = Console.ReadLine();
            ClassIdInput(ref s);
            st.ClassId = Convert.ToInt32(s);

            listStudent.Add(st);
        }
        public override int FindById(int id, bool show)
        {
            int position = -1;
            if (listStudent != null && listStudent.Count > 0)
            {
                for (int i = 0; i < listStudent.Count; i++)
                {
                    if (listStudent[i].Id == id)
                    {
                        position = i;
                        if (show)
                        {
                            Console.WriteLine("{0, -5} {1, -20} {2, -8} {3, -25} {4, -12} {5, -5} {6, -5}",
                                            "ID", "Name", "Gender", "Email", "PhoneNumber", "Score", "ClassId");
                            Console.WriteLine("{0, -5} {1, -20} {2, -8} {3, -25} {4, -12} {5, -5} {6, -5}",
                                                  listStudent[i].Id, listStudent[i].Name, listStudent[i].Gender, listStudent[i].Email, listStudent[i].PhoneNumber, listStudent[i].Score, listStudent[i].ClassId);
                        }
                    }
                }
            }
            return position;
        }
        public override List<int> FindByName(string name, bool show)
        {
            List<int> position = new List<int>();
            position.Add(0);
            if (listStudent != null && listStudent.Count > 0)
            {
                if (show)
                {
                    Console.WriteLine("{0, -5} {1, -20} {2, -8} {3, -25} {4, -12} {5, -5} {6, -5}",
                                        "ID", "Name", "Gender", "Email", "PhoneNumber", "Score", "ClassId");
                }
                for (int i = 0; i < listStudent.Count; i++)
                {
                    if (String.Compare(listStudent[i].Name, name, true) == 0)
                    {
                        position.Add(i);
                        if (show)
                        {
                            Console.WriteLine("{0, -5} {1, -20} {2, -8} {3, -25} {4, -12} {5, -5} {6, -5}",
                                          listStudent[i].Id, listStudent[i].Name, listStudent[i].Gender, listStudent[i].Email, listStudent[i].PhoneNumber, listStudent[i].Score, listStudent[i].ClassId);
                        }
                    }
                }
            }
            return position;
        }
        public override void UpdateData(int id)
        {
            int index = FindById(id, false);
            if (index != -1)
            {
                Student st = listStudent[index];

                Console.Write("Input name: "); string s = Console.ReadLine();
                NameInput(ref s);
                st.Name = s;

                Console.Write("Input gender (male/female/other): "); s = Console.ReadLine();
                GenderInput(ref s);
                st.Gender = s;

                Console.Write("Input email: "); s = Console.ReadLine();
                EmailInput(ref s);
                st.Email = s;

                Console.Write("Input phone: "); s = Console.ReadLine();
                PhoneInput(ref s);
                st.PhoneNumber = s;

                Console.Write("Input score: "); s = Console.ReadLine();
                ScoreInput(ref s);
                st.Score = Convert.ToInt32(s);

                Console.Write("Input classId: "); s = Console.ReadLine();
                ClassIdInput(ref s);
                st.ClassId = Convert.ToInt32(s);
            }
            else
            {
                Console.WriteLine("There is not student with id = " + id);
            }
        }
        public override void GoBack()
        {
            throw new NotImplementedException();
        }
        public void Add(Student st)
        {
            listStudent.Add(st);
        }

        // check
        protected bool IsEmail(string email)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
            return emailRegex.IsMatch(email);
        }
        protected bool IsPhone(string phone)
        {
            if (phone[0] == '0' && phone.Length == 10 && IsDigital(phone))
            {
                return true;
            }
            return false;
        }
        protected void GenderInput(ref string s)
        {
            s.ToLower();
            while (s != "male" && s != "female" && s != "other")
            {
                Console.Write("Please input valid gender or type 'quit': ");
                s = Console.ReadLine();
                s.ToLower();
            }
        }
        protected void EmailInput(ref string s)
        {
            while (!IsEmail(s))
            {
                Console.Write("Please input valid email or type 'quit': ");
                s = Console.ReadLine();
            }
        }
        protected void PhoneInput(ref string s)
        {
            while (!IsPhone(s))
            {
                Console.Write("Please input valid phone or type 'quit': ");
                s = Console.ReadLine();
            }
        }
        protected void ScoreInput(ref string s)
        {
            while (!IsLimitNumber(s, 10))
            {
                Console.Write("Please input valid score (0-10) or type 'quit': ");
                s = Console.ReadLine();
            }
        }
        protected void ClassIdInput(ref string s)
        {
            while (!IsLimitNumber(s, 20))
            {
                Console.Write("Please input valid classId or type 'quit': ");
                s = Console.ReadLine();
            }
        }
    }
}
