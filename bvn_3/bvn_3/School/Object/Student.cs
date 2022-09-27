using System;

namespace bvn_3.School
{
    [Serializable]
    public class Student : SchoolObj
    {
        public string Gender { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public int Score { set; get; }
        public int ClassId { set; get; }
        public override void Show()
        {
            Console.WriteLine("{0, -5} {1, -20} {2, -8} {3, -25} {4, -12} {5, -5} {6, -5}",
                            "ID", "Name", "Gender", "Email", "PhoneNumber", "Score", "ClassId");
            Console.WriteLine("{0, -5} {1, -20} {2, -8} {3, -25} {4, -12} {5, -5} {6, -5}",
                              Id, Name, Gender, Email, PhoneNumber, Score, ClassId);
        }
    }
}
