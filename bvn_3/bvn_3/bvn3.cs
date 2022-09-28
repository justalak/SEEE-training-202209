using bvn_3.School;
using System;

namespace bvn_3
{
    internal class bvn3
    {
        static void Main(string[] args)
        {
            try
            {
                MenuAction m = new MenuAction();
                m.Menu();
            }
            catch (Exception e)
            {
                Logger.WriteLog("\tError: " + e.Message + e.StackTrace);
                Console.WriteLine(e.Message);
            }
        }
    }
}