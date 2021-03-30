using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static BuildHouse.MyRandom;

namespace BuildHouse
{
    public class Team
    {
        public IWorker teamLeader = new TeamLeader();
        public List<IWorker> workers = new List<IWorker>();
        Random rnd = new Random();
        public Team(int count)
        {
            teamLeader.Name = NextName();
            teamLeader.Age = rnd.Next(18, 60);
            teamLeader.Salary = 50;
            

            for (int i = 0; i < count; i++)
            {
                IWorker worker = new Worker();
                worker.Name = NextName();
                worker.Age = rnd.Next(18,60);
                worker.Salary = rnd.Next(5, 40);
                workers.Add(worker);
            }
        }

        public IWorker GetWorker()
        {
            Random rnd = new Random();
            int r = rnd.Next(workers.Count);
            return workers[r];
        }
    }
}
