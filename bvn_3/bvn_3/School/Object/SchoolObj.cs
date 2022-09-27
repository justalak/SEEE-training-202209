using System;

namespace bvn_3.School
{
    [Serializable]
    public abstract class SchoolObj
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public abstract void Show();
    }
}
