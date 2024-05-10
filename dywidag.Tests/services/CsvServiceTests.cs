using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using dywidag.Infastructure.Services;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace dywidag.Tests.services
{
    public class CsvServiceTests
    {

        private IFileSystem fileSystem;
        private CsvService service;

        [SetUp]
        public void Setup()
        {
            fileSystem = Substitute.For<IFileSystem>();
            service = new CsvService(fileSystem);
        }

        [Test]
        public async Task OutputToCsvFile_Writer_Writes_correct_Lines()
        {
            var output = new Dictionary<int, string>
            {
                { 1, "Value1" },
                { 2, "Value2" }
            };
            var headers = new string[] { "Header1", "Header2" };
            var filename = "testfile";

            await service.OutputToCsvFile(output, headers, filename);

            await fileSystem.File.Received(1).WriteAllLinesAsync($"output/{filename}.csv", Arg.Any<string[]>());
        }
    }
}