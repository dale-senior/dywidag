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

        public void Run()
        {
            try
            {
                var yearDictionary = _leapYearService.GetAllYears();

                if(_csvService.OutputToCsvFile(yearDictionary, ["Year", "LeapYear"], "LeapYears")) {
                    Console.WriteLine("CSV Success");
                }

                if(_jsonService.OutputToJsonFile<LeapYearDto>(yearDictionary, "LeapYears")) {
                    Console.WriteLine("json Success");
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}