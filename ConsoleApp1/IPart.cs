using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildHouse
{
    public interface IPart
    {
        TypeMaterial TypeMaterial { get; set; }
        int Count { get; set; }

        double TimeToCreate { get; set; }

        bool Status { get; set; }
        IWorker worker { get; set; }

        void PrintInfo();
    }
}
