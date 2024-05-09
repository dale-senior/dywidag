using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dywidag.Infastructure.Services
{
    public class CsvService : ICsvService
    {
        public bool OutputToCsvFile(Dictionary<int, bool> output, string[] headers)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("LeapYears.csv"))
                {
                    writer.WriteLine(string.Join(",", headers));
                    foreach (var keyValuePair in output)
                    {
                        writer.WriteLine($"{keyValuePair.Key},{keyValuePair.Value}");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}