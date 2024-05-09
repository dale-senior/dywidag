using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dywidag.Infastructure.Services
{
    public interface IJsonService
    {
        bool OutputToJsonFile(Dictionary<int, bool> output);
    }
}