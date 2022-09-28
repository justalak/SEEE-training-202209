using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace bvn_3.School.Manager
{
    [Serializable]
    public class StudentManager : ObjManager
    {
        public List<Student> listStudent = null;

        public StudentManager()
        {
            listStudent = JsonConvert.DeserializeObject<List<Student>>(File.ReadAllText("../../School/Data/dataStudent.json"));
            if (listStudent == null || listStudent.Count == 0)
            {
                Logger.WriteLog("\tFalsed to load student data");
            }
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
                Console.WriteLine(); Logger.WriteLog("\tShown list of students");
            }
            else
            {
                Logger.WriteLog("\tCan not Show list of students");
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
            if (listStudent != null && listStudent.Count > 0)
            {
                int index = FindById(id, false);
                if (index != -1)
                {
                    listStudent.RemoveAt(index);
                    Console.WriteLine("Deleted student with id = " + id + "\n");
                    Logger.WriteLog("\tDeleted at id = " + s);
                }
                else
                {
                    Console.WriteLine("There is not student with id = " + id + "\n");
                    Logger.WriteLog("\tCan not delete at id = " + s);
                }
            }
            else
            {
                Console.WriteLine("There is no student data\n");
                Logger.WriteLog("\tCan not delete at id = " + s);
            }
        }
        public override void AddData()
        {
            Console.WriteLine("Add:");
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
                            Logger.WriteLog("\tSearched");
                        }
                    }
                }
            }
            if (show && position == -1)
            {
                Logger.WriteLog("\tCan not search------------");
            }
            return position;
        }
        public override List<int> FindByName(string name, bool show)
        {
            List<int> position = new List<int>();
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
            int index = FindById(id, false);
            if (index != -1)
            {
                Student st = listStudent[index];

                Console.Write("Input name: "); s = Console.ReadLine();
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

                Logger.WriteLog("\tUpdated at id = " + s);
            }
            else
            {
                Console.WriteLine("There is not student with id = " + id);
                Logger.WriteLog("\tCan not update at id = " + s);
            }
        }
        public void FindStudentSameClass(List<int> id)
        {
            if (listStudent != null && listStudent.Count > 0)
            {
                Console.WriteLine("{0, -5} {1, -20} {2, -8} {3, -25} {4, -12} {5, -5} {6, -5}",
                                "ID", "Name", "Gender", "Email", "PhoneNumber", "Score", "ClassId");
                foreach (int id2 in id)
                {
                    foreach (Student st in listStudent)
                    {
                        if (st.ClassId == id2)
                        {
                            Console.WriteLine("{0, -5} {1, -20} {2, -8} {3, -25} {4, -12} {5, -5} {6, -5}",
                                                st.Id, st.Name, st.Gender, st.Email, st.PhoneNumber, st.Score, st.ClassId);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No data!");
            }
        }
        public override void CloseFile()
        {
            if (listStudent != null && listStudent.Count > 0)
            {
                string data = JsonConvert.SerializeObject(listStudent);
                System.IO.File.WriteAllText("../../School/Data/dataStudent.json", data);
            }
        }

        // check
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
        private void GenderInput(ref string s)
        {
            s.ToLower();
            while (string.IsNullOrEmpty(s) || s != "male" && s != "female" && s != "other")
            {
                Console.Write("Please input valid gender or type 'quit': ");
                s = Console.ReadLine();
                s.ToLower();
            }
        }
        private void EmailInput(ref string s)
        {
            while (string.IsNullOrEmpty(s) || !IsEmail(s))
            {
                Console.Write("Please input valid email or type 'quit': ");
                s = Console.ReadLine();
            }
        }
        private void PhoneInput(ref string s)
        {
            while (string.IsNullOrEmpty(s) || !IsPhone(s))
            {
                Console.Write("Please input valid phone or type 'quit': ");
                s = Console.ReadLine();
            }
        }
        private void ScoreInput(ref string s)
        {
            while (string.IsNullOrEmpty(s) || !IsLimitNumber(s, 11))
            {
                Console.Write("Please input valid score (0-10) or type 'quit': ");
                s = Console.ReadLine();
            }
        }
        private void ClassIdInput(ref string s)
        {
            while (string.IsNullOrEmpty(s) || !IsLimitNumber(s, 30) || !GetClassId().Contains(Convert.ToInt32(s)))
            {
                if (!GetClassId().Contains(Convert.ToInt32(s)))
                    Console.WriteLine("No have class id = " + s);
                Console.Write("Please input valid classId or type 'quit': ");
                s = Console.ReadLine();
            }
        }
    }
}
