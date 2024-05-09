using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;

namespace dywidag.Infastructure.Services
{
    public class JsonService : IJsonService
    {
        private readonly IMapper _mapper;

        public JsonService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public bool OutputToJsonFile<T>(Dictionary<int, string> input, string filename)
        {
            using (StreamWriter writer = new StreamWriter($"{filename}.json"))
            {
                try
                {
                    List<T> jsonList = _mapper.Map<List<T>>(input);
                    var json = JsonSerializer.Serialize(jsonList);
                    writer.Write(json);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}