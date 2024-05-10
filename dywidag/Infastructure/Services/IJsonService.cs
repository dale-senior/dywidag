using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dywidag.Infastructure.Services
{
    public interface IJsonService
    {
        Task OutputToJsonFile<T>(Dictionary<int, string> input, string filename);
    }
}