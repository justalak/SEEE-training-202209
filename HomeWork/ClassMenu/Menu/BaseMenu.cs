using HomeWork.ManageSchool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public abstract class BaseMenu
{
    public abstract void ShowMenu();
    public abstract void ShowList();

    public abstract int FindObject(int id, bool showObject);

    public abstract void AddNew();

    public abstract void Update(int id);

    public abstract void Delete(int id);

    public abstract void Back();
}