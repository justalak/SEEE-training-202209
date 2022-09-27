using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1
{
    internal abstract class BaseMenu
    {
        public abstract void ShowList();

        public abstract void FindObject(int Id);

        public abstract void AddNew();

        public abstract void Update(int Id);

        public abstract void Delete(int Id);
     /*   public abstract void loginfile(string Function, BaseMenu basemenu);*/

        public void Back()
        {
            Program program = new Program();
            program.run();
        }
        virtual public void Option()
        {
            Console.WriteLine("Chon 1 de xem danh sach \n");
            Console.WriteLine("Chon 2 de tim kiem doi tuong\n");
            Console.WriteLine("Chon 3 de them doi tuong\n");
            Console.WriteLine("Chon 4 de sua doi tuong\n");
            Console.WriteLine("Chon 5 de xoa doi tuong\n");
            Console.WriteLine("Chon 0 de quay lai\n");
        }
    }
}
