using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dywidag.Infastructure.Models;
using dywidag.Infastructure.Services;
using NSubstitute;
using NUnit.Framework;

namespace dywidag.Tests.services
{
    public class LeapYearApplicationTests
    {

        private ILeapYearService _leapyearSerive;
        private ICsvService _csvService;
        private IJsonService _jsonSerice;
        private LeapYearApplication _application;
        private Dictionary<int, string> _years;

        [SetUp]
        public void Setup()
        {
            _years = new Dictionary<int, string>
            {
                { 1, "No" },
                { 2, "No" },
                { 3, "No" },
                { 4, "Yes" }
            };

            _leapyearSerive = Substitute.For<ILeapYearService>();
            _csvService = Substitute.For<ICsvService>();
            _jsonSerice = Substitute.For<IJsonService>();

            _leapyearSerive.GetAllYears().Returns(x => _years);

            _application = new LeapYearApplication(_leapyearSerive, _csvService, _jsonSerice);
        }

        [Test]
        public async Task GetAllYears_Called_On_LeapYearService()
        {
            await _application.Run();
            _leapyearSerive.Received().GetAllYears();
        }

        [Test]
        public async Task OutputToCsvFile_Called_On_CsvService()
        {
            await _application.Run();
            await _csvService.Received().OutputToCsvFile(_years, Arg.Any<string[]>(), "LeapYears");
        }

        [Test]
        public async Task OutputToJsonFile_Called_On_JsonService()
        {
            await _application.Run();
            await _jsonSerice.Received().OutputToJsonFile<LeapYearDto>(_years, "LeapYears");
        }

        [Test]
        public async Task GetLeapYears_Called_On_LeapYearService()
        {
            await _application.Run();
            _leapyearSerive.Received().GetLeapYears();
        }
    }
}