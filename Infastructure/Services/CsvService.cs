using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dywidag.Infastructure.Services
{
    public class CsvService : ICsvService
    {
        public CsvService()
        {

        }

        public bool OutputToCsvFile(Dictionary<int, bool> output, string[] headers)
        {
            using (StreamWriter writer = new StreamWriter("LeapYears.csv"))
            {
                
            }

            return true;
        }
    }
}