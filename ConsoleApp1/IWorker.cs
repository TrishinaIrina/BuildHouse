namespace BuildHouse
{
    public interface IWorker
    {
        string Name { get; set; }
        double Salary { get; set; }
        int Age { get; set; }
        double TimeWorked { get; set; }

        void ShowState();
    }
}