using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1
{
    internal class InputHandling
    {
        public static int getId()
        {
            bool ktId = false;
            int Id = 0;
            while (ktId == false)
            {
                try
                {
                    Console.WriteLine("**** Moi ban nhap Id  *****");
                    Id = Convert.ToInt32(Console.ReadLine());
                    ktId = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("*** Ban da nhap sai Id *** Xin moi nhap lai ***");
                    ktId = false;
                }
            }
            return Id;
        }
        public static int getchoise()
        {
            bool ktchoise = false;
            int choise = 0;
            while (ktchoise == false)
            {
                try
                {
                    Console.WriteLine("**** Moi ban nhap lua chon  *****");
                    choise = Convert.ToInt32(Console.ReadLine());
                    ktchoise = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("*** Ban da nhap sai lua chon *** Xin moi nhap lai ***");
                    ktchoise = false;
                }
            }
            return choise;
        }
        public static int getScore()
        {
            int Score = 0;
            bool ktScore = false;
            while (ktScore == false)
            {
                try
                {
                    Console.WriteLine("**** Moi ban nhap Score *****");
                    Score = Convert.ToInt32(Console.ReadLine());
                    ktScore = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("*** Ban da nhap sai Score *** Xin moi nhap lai ***");
                    ktScore = false;
                }
            }
            return Score;
        }
        public static int getClassId()
        {
            bool ktClassId = false;
            int ClassId = 0;
            while (ktClassId == false)
            {
                try
                {
                    Console.WriteLine("**** Moi ban nhap ClassId  *****");
                    ClassId = Convert.ToInt32(Console.ReadLine());
                    ktClassId = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("*** Ban da nhap sai ClassId *** Xin moi nhap lai ***");
                    ktClassId = false;
                }
            }
            return ClassId;
        }
        public static int getTeacherId()
        {
            bool ktTeacherId = false;
            int TeacherId = 0;
            while (ktTeacherId == false)
            {
                try
                {
                    Console.WriteLine("**** Moi ban nhap TeacherId  *****");
                    TeacherId = Convert.ToInt32(Console.ReadLine());
                    ktTeacherId = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("*** Ban da nhap sai TeacherId *** Xin moi nhap lai ***");
                    ktTeacherId = false;
                }
            }
            return TeacherId;
        }
        static  public void  Initialization_Student()
        {
            var studenjson = File.ReadAllText(StudentMenu.datafile);
            if (studenjson != "")
            {
                StudentMenu.students = JsonConvert.DeserializeObject<List<Student>>(studenjson);
            }
            else
            {
                StudentMenu.students = new List<Student>();
            }
        }
        static public  void Initialization_Teacher()
        {
            var teacherjson = File.ReadAllText(TeacherMenu.datafile);
            if (teacherjson != "")
            {
                TeacherMenu.teachers = JsonConvert.DeserializeObject<List<Teacher>>(teacherjson);
            }
            else
            {
                TeacherMenu.teachers = new List<Teacher>();
            }
        }
        static public void Initialization_Class()
        {
            var classjson = File.ReadAllText(ClassMenu.datafile);
            if (classjson != "")
            {
                ClassMenu.classs = JsonConvert.DeserializeObject<List<Class>>(classjson);
            }
            else
            {
                ClassMenu.classs = new List<Class>();
            }
        }
        public static void  readlogfile()
        {
            FileStream file = new FileStream(EnhancedFeature.logfile,FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(file);
            string line = "";
            while (line != null) { 
             line = sr.ReadLine();
            Console.WriteLine(line);
            }
            sr.Close();
            file.Close();
        }
    }
}

