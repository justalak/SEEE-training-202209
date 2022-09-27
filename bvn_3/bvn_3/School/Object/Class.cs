using System;

namespace bvn_3.School
{
    [Serializable]
    public class Class : SchoolObj
    {
        public int TeacherId { get; set; }
        public override void Show()
        {
            Console.WriteLine("{0, -5} {1, -20}{6, -5}", "ID", "Name", "TeacherId");
            Console.WriteLine("{0, -5} {1, -20} {6, -5}", Id, Name, TeacherId);
        }
    }
}
