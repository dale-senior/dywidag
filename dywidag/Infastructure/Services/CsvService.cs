using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
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

                List<string> contents = [string.Join(",", headers)];
                foreach (var keyValuePair in output)
                {
                    contents.Add($"{keyValuePair.Key},{keyValuePair.Value}");
                }
                _fileSystem.File.WriteAllLines($"output/{filename}.csv", contents.ToArray());

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}