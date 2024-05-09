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
            var allyears = this.GetAllYears();
            var noneLeapYears = allyears.Where(kvp => kvp.Value == false)
                                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            return noneLeapYears.Keys.ToList();
        }

        /*Returns key value pair where the key is the year and value is bool represening is a leap year or not*/
        public Dictionary<int, bool> GetAllYears()
        {
            Dictionary<int, bool> allYears = new Dictionary<int, bool>();
            var currentYear = DateTime.UtcNow.Year;
            for (int i = 1; i < currentYear; i++)
            {
                allYears.Add(i, IsLeapYear(i)); 
            }
            return allYears;
        }

        public List<int> GetLeapYears()
        {
            var allyears = this.GetAllYears();
            var leapYears = allyears.Where(kvp => kvp.Value == true)
                                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            return leapYears.Keys.ToList();
        }

        public bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
        }
    }
}