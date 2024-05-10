using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dywidag.Infastructure.Models;

namespace dywidag.Infastructure.Services
{
    public class LeapYearApplication : ILeapYearApplication
    {
        private readonly ILeapYearService _leapYearService;
        private readonly ICsvService _csvService;
        private readonly IJsonService _jsonService;

        public LeapYearApplication(ILeapYearService leapYearService,
                                   ICsvService csvService,
                                   IJsonService jsonService)
        {
            _leapYearService = leapYearService;
            _csvService = csvService;
            _jsonService = jsonService;
        }

        public async Task Run()
        {
            try
            {
                //get key value pair of years and isleapyear
                var yearDictionary = _leapYearService.GetAllYears();

                //write dictionary results to csv file
                await _csvService.OutputToCsvFile(yearDictionary, ["Year", "LeapYear"], "LeapYears");

                //write dictionary results to json file (pass correct mapped type as generic)
                await _jsonService.OutputToJsonFile<LeapYearDto>(yearDictionary, "LeapYears");

                //log to console total leap years
                Console.WriteLine($"Total Leap Years: {_leapYearService.GetLeapYears().Count}");
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}