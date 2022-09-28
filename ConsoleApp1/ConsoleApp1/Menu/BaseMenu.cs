using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public abstract class BaseMenu
    {
        public abstract void DisplayMenu();
        public abstract void ShowList();

        public abstract void Find();

        public abstract void AddNew();

        public abstract void Update();

        public abstract void Delete();

        public void Back()
        {

        }
    }
}
