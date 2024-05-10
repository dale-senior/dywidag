using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using dywidag.Infastructure.Services;
using NSubstitute;
using NUnit.Framework;

namespace dywidag.Tests.services
{
    public class CsvServiceTests
    {

        private IFileSystem fileSystem;
        private StreamWriter writer;
        private CsvService service;
        [SetUp]
        public void Setup()
        {
            fileSystem = Substitute.For<IFileSystem>();
            writer = Substitute.For<StreamWriter>("testfile");
            fileSystem.File.CreateText(Arg.Any<string>()).Returns(writer);

            service = new CsvService(fileSystem);
        }

        [Test]
        public void OutputToCsvFile_Writer_Writes_correct_Lines()
        {
            var output = new Dictionary<int, string>
            {
                { 1, "Value1" },
                { 2, "Value2" }
            };
            var headers = new string[] { "Header1", "Header2" };
            var filename = "testfile";

            service.OutputToCsvFile(output, headers, filename);

            writer.Received().WriteLine(string.Join(",", headers));

            foreach (var kvp in output)
            {
                writer.Received().WriteLine($"{kvp.Key},{kvp.Value}");
            }
        }
    }
}