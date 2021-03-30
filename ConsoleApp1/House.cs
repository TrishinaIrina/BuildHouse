using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuildHouse
{
    public class House
    {
        public List<IPart> Basement { get; set; }
        public List<IPart> Walls { get; set; }
        public List<IPart> Door { get; set; }
        public List<IPart> Window { get; set; }
        public List<IPart> Roof { get; set; }

        public void PrintReport(Team team)
        {
            Console.WriteLine();
            Console.WriteLine("рабочие принимавшие участие: ");
            Console.WriteLine("----------------------------------");
            
            foreach (IWorker worker in team.workers)
            {
                Console.WriteLine("{0}  time worked - {1}  payment - {2}$", worker.Name, worker.TimeWorked, worker.TimeWorked * worker.Salary); 
            }

            double maxTimeWoked = 0;
            foreach (IWorker worker in team.workers)
            {
                if (worker.TimeWorked > maxTimeWoked)
                {
                    maxTimeWoked = worker.TimeWorked;
                }
            }

            team.teamLeader.TimeWorked = maxTimeWoked;
            Console.WriteLine("Team leader: {0}  time worked - {1}  payment - {2}$",
                team.teamLeader.Name, team.teamLeader.TimeWorked, team.teamLeader.TimeWorked * team.teamLeader.Salary);

            double sum = team.teamLeader.TimeWorked * team.teamLeader.Salary;
            foreach (IWorker worker in team.workers)
            {
                sum += worker.TimeWorked * worker.Salary;
            }
            Console.WriteLine("Total amount of work on the project: " + sum);
        }
    }

    public enum TypeMaterial { None = 0, Cement = 1, Metal = 2, Brick = 3 }


    public class ServiceHouse
    {
        private Random rnd = new Random();

        public House CreateHouseProject_1()
        {
            House house = new House();
            house.Basement = Init_Basement(1);
            house.Walls = Init_Walls(4);
            house.Roof = Init_Roof(1);

            return house;
        }

        public House CreateHouseProject_2()
        {
            House house = new House();
            house.Basement = Init_Basement(2);
            house.Walls = Init_Walls(7);
            house.Roof = Init_Roof(1);
            house.Window = Init_Window(10);

            return house;
        }

        public List<IPart> GetAllPart_1(House house)
        {
            List<IPart> partsHouse = new List<IPart>();

            partsHouse.AddRange(house.Basement);

            //foreach (var item in house.Basement)
            //{
            //    partsHouse.Add(item);
            //}
           
            partsHouse.AddRange(house.Walls);
            partsHouse.AddRange(house.Roof);

            return partsHouse;
        }

        public List<IPart> GetAllPart_2(House house)
        {
            List<IPart> partsHouse = new List<IPart>();

            partsHouse.AddRange(house.Basement);

            //foreach (var item in house.Basement)
            //{
            //    partsHouse.Add(item);
            //}
            partsHouse.AddRange(house.Window); // возм ошибка
            partsHouse.AddRange(house.Walls);
            partsHouse.AddRange(house.Roof);

            return partsHouse;
        }

        public List<IPart> Init_Basement(int count)
        {
            List<IPart> basements = new List<IPart>();
            for (int i = 0; i < count; i++)
            {
                Basement basement = new Basement();
                basement.Count = i;
                basement.TypeMaterial = TypeMaterial.Cement;
                basement.TimeToCreate = rnd.Next(1, 30);

                basements.Add(basement);
            }

            return basements;
        }

        public List<IPart> Init_Walls(int count)
        {
            List<IPart> walls = new List<IPart>();
            for (int i = 0; i < count; i++)
            {
                Walls wall = new Walls();
                wall.Count = i;
                wall.TypeMaterial = TypeMaterial.Brick;
                wall.TimeToCreate = rnd.Next(1, 30);

                walls.Add(wall);
            }

            return walls;
        }

        public List<IPart> Init_Roof(int count)
        {
            List<IPart> roofs = new List<IPart>();
            for (int i = 0; i < count; i++)
            {
                Roof roof = new Roof();
                roof.Count = i;
                roof.TypeMaterial = TypeMaterial.Metal;
                roof.TimeToCreate = rnd.Next(1, 30);

                roofs.Add(roof);
            }

            return roofs;
        }

        public List<IPart> Init_Window(int count)
        {
            List<IPart> windows = new List<IPart>();
            for (int i = 0; i < count; i++)
            {
                Window window = new Window();
                window.Count = i;
                window.TypeMaterial = TypeMaterial.Metal;
                window.TimeToCreate = rnd.Next(1, 30);

                windows.Add(window);
            }

            return windows;
        }

        public void StartBuild_1()
        {
            //Заказать проект дома
            House house = CreateHouseProject_1();

            //Создать команду
            Team team = new Team(5);
            team.teamLeader.ShowState();

            foreach (IPart part in GetAllPart_1(house))
            {
                var worker = team.GetWorker();
                part.worker = worker;
                part.Status = true;
                worker.TimeWorked += part.TimeToCreate;

                worker.ShowState();
                for (int i = 0; i < part.TimeToCreate; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(100);
                }

                Console.WriteLine("");
            }
            house.PrintReport(team);       
        }

        public void StartBuild_2()
        {
            //Заказать проект дома
            House house = CreateHouseProject_2();

            //Создать команду
            Team team = new Team(8);
            team.teamLeader.ShowState();

            foreach (IPart part in GetAllPart_2(house))
            {
                var worker = team.GetWorker();
                part.worker = worker;
                part.Status = true;
                worker.TimeWorked += part.TimeToCreate;

                worker.ShowState();
                for (int i = 0; i < part.TimeToCreate; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(100);
                }

                Console.WriteLine("");
            }
            house.PrintReport(team);
        }
    }
}



