using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dywidag.Infastructure.Services;
using Microsoft.VisualBasic;
using NSubstitute;
using NUnit.Framework;

namespace dywidag.Tests.services
{
    public class LeapYearServiceTests
    {

        private LeapYearService _service;

        [SetUp]
        public void Setup()
        {
            _service = new LeapYearService();
        }

        [Test]
        public void GetAllYears_Returns_Dictionary()
        {
            var result = _service.GetAllYears();
            Assert.That(result, Is.InstanceOf<Dictionary<int, string>>());
        }

        [TestCase(1, "No")]
        [TestCase(2, "No")]
        [TestCase(3, "No")]
        [TestCase(4, "Yes")]
        [TestCase(2000, "Yes")]
        [TestCase(1900, "No")]
        [TestCase(700, "No")]
        [TestCase(800, "Yes")]
        [TestCase(2024, "Yes")]
        public void GetAllYears_Values_For_Years_Expected(int year, string expected)
        {
            var years = _service.GetAllYears();
            string value = years[year];
            Assert.That(value, Is.EqualTo(expected));
        }

        [Test]
        public void GetAllYears_Returns_Correct_Number_Of_Items()
        {
            var result = _service.GetAllYears();
            Assert.That(result.Count, Is.EqualTo(DateTime.Now.Year));
        }

        [TestCase(1, false)]
        [TestCase(2, false)]
        [TestCase(3, false)]
        [TestCase(4, true)]
        [TestCase(1900, false)]
        [TestCase(700, false)]
        [TestCase(2000, true)]
        [TestCase(800, true)]
        [TestCase(2024, true)]
        public void IsLeapYear_Returns_Expected(int year, bool expected)
        {
            var result = _service.IsLeapYear(year);
            Assert.That(result, Is.EqualTo(expected));
        }

        //GetLeapYears

        [Test]
        public void GetLeapYears_Returns_list()
        {
            var result = _service.GetLeapYears();
            Assert.That(result, Is.InstanceOf<List<int>>());
        }

        [Test]
        public void GetLeapYears_Returns_Correct_Number_Of_Items()
        {
            var result = _service.GetLeapYears();
            var allyears = _service.GetAllYears().Where(w => w.Value == "Yes");
            Assert.That(result.Count, Is.EqualTo(allyears.Count()));
        }

        //GetNonLeapYears

        [Test]
        public void GetAllNonLeapYears_Returns_list()
        {
            var result = _service.GetAllNonLeapYears();
            Assert.That(result, Is.InstanceOf<List<int>>());
        }

        [Test]
        public void GetAllNonLeapYears_Returns_Correct_Number_Of_Items()
        {
            var result = _service.GetAllNonLeapYears();
            var allyears = _service.GetAllYears().Where(w => w.Value == "No");
            Assert.That(result.Count, Is.EqualTo(allyears.Count()));
        }

    }
}