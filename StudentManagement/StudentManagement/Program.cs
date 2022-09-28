// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using StudentManagement.Model;
using StudentManagement.Model.Menu;
using StudentManagement.Model.SwitchMenu;

namespace StudentManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuSwitch menuSwitch = new MenuSwitch();
            menuSwitch.SwitchCase();
            //Console.WriteLine(newStudent.Name);
        }
    }
}