using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dywidag.Infastructure.Services
{
    public interface ICsvService
    {
        Task OutputToCsvFile(Dictionary<int, string> output, string[] headers, string filename);
    }
}