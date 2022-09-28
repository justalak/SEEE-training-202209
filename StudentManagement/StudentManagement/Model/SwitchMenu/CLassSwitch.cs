using StudentManagement.Model.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model.SwitchMenu
{
    internal class CLassSwitch
    {
        public void SwitchCase()
        {
            MenuSwitch menuSwitch = new MenuSwitch();
            ClassMenu classMenu = new ClassMenu();
            Console.WriteLine("Chon 1 de xem danh sach ");
            Console.WriteLine("Chon 2 de tim kiem doi tuong ");
            Console.WriteLine("Chon 3 de them doi tuong ");
            Console.WriteLine("Chon 4 de sua doi tuong ");
            Console.WriteLine("Chon 5 de xoa doi tuong");
            Console.WriteLine("Chon 0 de quay lai ");
            string luachon = Console.ReadLine();
            int luachonInt;
            int.TryParse(luachon, out luachonInt);
            if (luachonInt == 1)
            {
                classMenu.ShowList();
                menuSwitch.SwitchCase();
            }
            if (luachonInt == 2)
            {
                classMenu.FindObject();
                menuSwitch.SwitchCase();
            }
            if (luachonInt == 3)
            {
                classMenu.AddNew();
                menuSwitch.SwitchCase();
            }
            if (luachonInt == 4)
            {
                classMenu.Update();
                menuSwitch.SwitchCase();
            }
            if (luachonInt == 5)
            {
                classMenu.Delete();
                menuSwitch.SwitchCase();
            }
            if (luachonInt == 0)
            {
                menuSwitch.SwitchCase();
            }
        }
    }
}
