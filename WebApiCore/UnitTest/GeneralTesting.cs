using DataEntities.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ServiceRate.Implementations;
using ServiceRate.Interfaces;
using System.Collections.Generic;
using Moq;
using Data_EF.UnitOfWork;

namespace GeneralTesting
{
    [TestClass]
    public class GeneralTesting
    {
        public const string _rateString = @"[
                {""From"":""EUR"",""To"":""CAD"",""Ratio"":1.17},
                {""From"":""CAD"",""To"":""EUR"",""Ratio"":0.85},
                {""From"":""EUR"",""To"":""AUD"",""Ratio"":1.13},
                {""From"":""AUD"",""To"":""EUR"",""Ratio"":0.88},
                {""From"":""CAD"",""To"":""USD"",""Ratio"":0.62},
                {""From"":""USD"",""To"":""CAD"",""Ratio"":1.61}
                ]";

        [TestMethod]
        public void CheckConvertUSDtoEUR()
        {
            var mockLogger = new Mock<ILogger<RateService>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            IRateService serviceRate = new RateService(mockLogger.Object, mockUnitOfWork.Object);
    
            List<Rate> rates = JsonConvert.DeserializeObject<List<Rate>>(_rateString);

            decimal amount = 10.5m;
            decimal result = 14.37m;

            Assert.AreEqual(serviceRate.Convert(rates, "USD", "EUR", amount), result);
        }

        [TestMethod]
        public void CheckConvertEURtoUSD()
        {
            var mockLogger = new Mock<ILogger<RateService>>();
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            IRateService serviceRate = new RateService(mockLogger.Object, mockUnitOfWork.Object);

            List<Rate> rates = JsonConvert.DeserializeObject<List<Rate>>(_rateString);

            decimal amount = 10.5m;
            decimal result = 7.62m;

            Assert.AreEqual(serviceRate.Convert(rates, "EUR", "USD", amount), result);
        }
    }
}