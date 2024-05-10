using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace dywidag.Infastructure.Services
{
    public class CsvService : ICsvService
    {
        private readonly IFileSystem _fileSystem;

        public CsvService(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public bool OutputToCsvFile(Dictionary<int, string> output, string[] headers, string filename)
        {
            try
            {
                using (var writer = _fileSystem.File.CreateText($"output/{filename}.csv"))
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