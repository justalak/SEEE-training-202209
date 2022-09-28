using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    internal abstract class BaseMenuClass
    {
        public abstract void ShowList(ref List<Class> list);

        public abstract void Search(ref List<Class> list);

        public abstract void AddNew(ref List<Class> list);

        public abstract void Update(ref List<Class> list);

        public abstract void Delete(ref List<Class> list);

        public void Back()
        {

        }
    }
}
