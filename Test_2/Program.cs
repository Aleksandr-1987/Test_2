using System;
using System.Collections.Generic;

namespace Test_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Result> res = Funktions.CreateList();

                Funktions.FillList(ref res);

                Funktions.WriteList(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
