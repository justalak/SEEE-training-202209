using StudentManagement.Model.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model.SwitchMenu
{
    internal class MenuSwitch
    {
        public void SwitchCase()
        {
            TeacherSwitch teacherSwitch = new TeacherSwitch();
            StudentSwitch studentSwitch = new StudentSwitch();
            CLassSwitch cLassSwitch = new CLassSwitch();
            Console.WriteLine("Chon 1 de thao tac doi tuong Student ");
            Console.WriteLine("Chon 2 de thao tac doi tuong Teacher ");
            Console.WriteLine("Chon 3 de thao tac doi tuong Class ");
            string luachon = Console.ReadLine();
            int luachonInt;
            int.TryParse(luachon, out luachonInt);
            if (luachonInt == 1)
            {
                studentSwitch.SwitchCase();
            }
            if (luachonInt == 2)
            {
                teacherSwitch.SwitchCase();
            }
            if (luachonInt == 3)
            {
                cLassSwitch.SwitchCase();
            }
        }
    }
}
