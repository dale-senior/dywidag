using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dywidag.Infastructure.Services
{
    public interface ILeapYearService
    {
        Dictionary<int, bool> GetAllYears();
        List<int> GetLeapYears();
        List<int> GetAllNonLeapYears();
        bool IsLeapYear(int year);
    }
}