using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildHouse
{
    public class Basement : IPart
    {
        public TypeMaterial TypeMaterial { get; set; }
        public int Count { get; set; }
        public double TimeToCreate { get; set; }
        public bool Status { get; set; } = false;
        public IWorker worker { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine("Количество фундаментов: {0}, материал фундаментов: {1}", Count, TypeMaterial);
        }
    }
}
