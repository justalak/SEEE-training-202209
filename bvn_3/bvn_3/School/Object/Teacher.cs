using System;

namespace bvn_3.School
{
    [Serializable]
    public class Teacher : SchoolObj
    {
        public override void Show()
        {
            Console.WriteLine("{0, -5} {1, -20}", "ID", "Name");
            Console.WriteLine("{0, -5} {1, -20}", Id, Name);
        }
    }
}
