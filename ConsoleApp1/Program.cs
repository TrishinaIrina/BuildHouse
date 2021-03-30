using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildHouse
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceHouse BI = new ServiceHouse();
            Console.WriteLine("************************************************************");
            Console.WriteLine("The first version of the house");
            Console.WriteLine("************************************************************");
            Console.WriteLine();
            BI.StartBuild_1();
            Console.WriteLine();
            Console.WriteLine("************************************************************");
            Console.WriteLine("The second version of the house");
            Console.WriteLine("************************************************************");
            Console.WriteLine();
            BI.StartBuild_2();


        }       
    }
}
