using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dywidag.Infastructure.Services
{
    public interface ICsvService
    {
        bool OutputToCsvFile(Dictionary<int, bool> output, string[] headers);
    }
}