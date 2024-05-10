using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;

namespace dywidag.Infastructure.Services
{
    public class JsonService : IJsonService
    {
        private readonly IMapper _mapper;
        private readonly IFileSystem _fileSystem;

        public JsonService(IMapper mapper, IFileSystem fileSystem)
        {
            _mapper = mapper;
            _fileSystem = fileSystem;
        }

        public bool OutputToJsonFile<T>(Dictionary<int, string> input, string filename)
        {

            try
            {
                List<T> jsonList = _mapper.Map<List<T>>(input);
                var json = JsonSerializer.Serialize(jsonList);
                _fileSystem.File.WriteAllText($"output/{filename}.json", json);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}