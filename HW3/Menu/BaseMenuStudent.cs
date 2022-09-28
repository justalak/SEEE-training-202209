using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    internal abstract class BaseMenuStudent
    {
        public abstract void ShowList(List<Student> list);

        public abstract void Search(ref List<Student> list);

        public abstract void AddNew(ref List<Student> list);

        public abstract void Update(ref List<Student> list);

        public abstract void Delete(ref List<Student> list);

        public abstract void StudentSameClass(List<Student> list);

        public void Back()
        {

        }
    }
}
