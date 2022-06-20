using BusinessLogicLayer.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class CotisationEndDateTest
    {
        // Teste si la méthode GetCotisationEndDate renvoie la bonne date de fin de cotisation
        [TestMethod]
        public void CalculateCotisationEndDate_Valid()
        {
            DateTime date = new(2021, 12, 25);

            DateTime expectedDailyEndDate = new(2021, 12, 26);
            DateTime expectedTrimesterEndDate = new(2022, 03, 25);
            DateTime expectedSeasonEndDate = new(2022, 12, 25);

            var dailyEndDate = date.GetCotisationEndDate("cours");
            var trimesterEndDate = date.GetCotisationEndDate("trimestre");
            var seasonEndDate = date.GetCotisationEndDate("année");

            Assert.AreEqual(dailyEndDate, expectedDailyEndDate);
            Assert.AreEqual(trimesterEndDate, expectedTrimesterEndDate);
            Assert.AreEqual(seasonEndDate, expectedSeasonEndDate);
        }

        // Teste si la méthode GetCotisationEndDate renvoie la bonne date en cas de dernier jour du mois
        [TestMethod]
        public void CalculateCotisationEndDate_EndOfMonth()
        {
            DateTime date = new(2021, 03, 31);

            DateTime expectedDailyEndDate = new(2021, 04, 1);
            DateTime expectedTrimesterEndDate = new(2021, 06, 30);
            DateTime expectedSeasonEndDate = new(2022, 03, 31);

            var dailyEndDate = date.GetCotisationEndDate("cours");
            var trimesterEndDate = date.GetCotisationEndDate("trimestre");
            var seasonEndDate = date.GetCotisationEndDate("année");

            Assert.AreEqual(dailyEndDate, expectedDailyEndDate);
            Assert.AreEqual(trimesterEndDate, expectedTrimesterEndDate);
            Assert.AreEqual(seasonEndDate, expectedSeasonEndDate);
        }

        // Teste si la méthode GetCotisationEndDate renvoie la bonne date sila date de fin est fin février
        [TestMethod]
        public void CalculateCotisationEndDate_EndInFebruary()
        {
            DateTime date = new(2021, 11, 30);
            DateTime expectedTrimesterEndDate = new(2022, 02, 28);

            var trimesterEndDate = date.GetCotisationEndDate("trimestre");

            Assert.AreEqual(trimesterEndDate, expectedTrimesterEndDate);
        }

        // Teste si la méthode GetCotisationEndDate renvoie la bonne date sila date en cas d'année bissextile
        [TestMethod]
        public void CalculateCotisationEndDate_LeapYear()
        {
            DateTime date = new(2024, 02, 29);
            DateTime expectedYearEndDate = new(2025, 02, 28);

            var yearEndDate = date.GetCotisationEndDate("année");

            Assert.AreEqual(yearEndDate, expectedYearEndDate);
        }
    }
}