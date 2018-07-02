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
            

            CSVImporter.ConvertCSVtoDataTable("..../animals.csv");

            // PointOfEntry.Run();
            Console.ReadLine();
        }
    }
}
