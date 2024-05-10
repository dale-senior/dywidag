using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dywidag.Infastructure.Services
{
    public class LeapYearService : ILeapYearService
    {
        public List<int> GetAllNonLeapYears()
        {
            return this.FilterLeapYears("No");
        }

        /*Returns key value pair where the key is the year and value is bool represening is a leap year or not*/
        public Dictionary<int, string> GetAllYears()
        {
            Dictionary<int, string> allYears = new Dictionary<int, string>();
            var currentYear = DateTime.UtcNow.Year;
            for (int i = 1; i < currentYear + 1; i++)
            {
                allYears.Add(i, IsLeapYear(i) ? "Yes" : "No"); 
            }
            return allYears;
        }

        private List<int> FilterLeapYears(string filter) {
            var allyears = this.GetAllYears();
            var leapYears = allyears.Where(kvp => kvp.Value.Contains(filter))
                                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                                    .Keys
                                    .ToList();

            return leapYears;
        }

        public List<int> GetLeapYears()
        {
            return this.FilterLeapYears("Yes");
        }

        public bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
        }
    }
}