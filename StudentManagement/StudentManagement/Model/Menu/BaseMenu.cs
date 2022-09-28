using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model.Menu
{
    internal abstract class BaseMenu
    {
        public abstract void ShowList();

        public abstract void FindObject();

        public abstract void AddNew();

        public abstract void Update();

        public abstract void Delete();

        public void Back()
        {

        }
    }
}
