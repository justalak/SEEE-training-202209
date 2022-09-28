using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    internal abstract class BaseMenuTeacher
    {
        public abstract void ShowList(ref List<Teacher> list);

        public abstract void Search(ref List<Teacher> list);

        public abstract void AddNew(ref List<Teacher> list);

        public abstract void Update(ref List<Teacher> list);

        public abstract void Delete(ref List<Teacher> list);

        public void Back()
        {

        }
    }
}
