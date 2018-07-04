using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Program
    {
        static void Main(string[] args)
        {
            PopulateDB pop = new PopulateDB();
            PointOfEntry.Run();
            
            Console.ReadLine();
        }
    }
}
