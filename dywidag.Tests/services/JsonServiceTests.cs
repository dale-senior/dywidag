using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using dywidag.Infastructure.Models;
using dywidag.Infastructure.Services;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace dywidag.Tests.services
{
    public class JsonServiceTests
    {

        private IFileSystem fileSystem;
        private IMapper mapper;
        private JsonService service;
        private List<LeapYearDto> jsonList;

        [SetUp]
        public void Setup()
        {
            fileSystem = Substitute.For<IFileSystem>();
            mapper = Substitute.For<IMapper>();
            jsonList = [new LeapYearDto() {LeapYear = "Value1", Year = 1},
                        new LeapYearDto() {LeapYear = "Value2", Year = 2}]; // Assuming SomeClass is the type mapped from input

            mapper.Map<List<LeapYearDto>>(Arg.Any<Dictionary<int, string>>()).Returns(jsonList);
            service = new JsonService(mapper, fileSystem);
        }

        [Test]
        public void OutputToJsonFile_Writes_CorrectDataToFile()
        {
            var input = new Dictionary<int, string>
            {
                { 1, "Value1" },
                { 2, "Value2" }
            };
            var result = service.OutputToJsonFile<LeapYearDto>(input, "filename");
            var expectedJson = JsonSerializer.Serialize(jsonList);

            fileSystem.File.Received(1).WriteAllText($"output/filename.json", expectedJson);
        }

        [Test]
        public void OutputToJsonFile_Mapper_Calls_Map()
        {
            var input = new Dictionary<int, string>
            {
                { 1, "Value1" },
                { 2, "Value2" }
            };
            var result = service.OutputToJsonFile<LeapYearDto>(input, "filename");
            mapper.Received().Map<List<LeapYearDto>>(input);
        }

        [Test]
        public void OutputToJsonFile_Returns_True_With_No_Error()
        {
            var input = new Dictionary<int, string>
            {
                { 1, "Value1" },
                { 2, "Value2" }
            };
            var result = service.OutputToJsonFile<LeapYearDto>(input, "filename");
            Assert.That(result, Is.True);
        }


        [Test]
        public void OutputToJsonFile_ReturnsFalse_WhenExceptionOccurs()
        {
            var input = new Dictionary<int, string>
            {
                { 1, "Value1" },
                { 2, "Value2" }
            };

            mapper.Map<List<LeapYearDto>>(Arg.Any<Dictionary<int, string>>()).Throws(new Exception());

            var result = service.OutputToJsonFile<LeapYearDto>(input, "filename");
            Assert.That(result, Is.False);
        }
    }
}