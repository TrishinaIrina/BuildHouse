using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuildHouse
{
    public class MyRandom
    {
        private static int _seed = Environment.TickCount;

        private static ThreadLocal<Random> _random = new ThreadLocal<Random>(() =>
            new Random(Interlocked.Increment(ref _seed))
        );


       
        public static string NextName()
        {
            string[] Names = new string[]
            {
                "Igor", "Ivan", "Petr", "Serik",
                "Berik", "Aidyn", "Nilolay",
                "Aleksey", "Kairat", "Musa",
                "Bolat", "Anatoliy", "Zhomart",
                "Ramir", "Tor", "Adlet", "Albert",
                "Ashat", "Arman", "Ruslan", "Talgat",
                "Eldos", "Yuriy", "Danil", "Daryn"

            };
            int index = _random.Value.Next(0, Names.Length);
            return Names[index];
        }

        public static T NextGenericEnum<T>()
            where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumarated type");
            }
                T[] values = (T[])(Enum.GetValues(typeof(T)));
                T randomEnum = values[_random.Value.Next(0, values.Length)];
                return randomEnum;
        }
    }
}
