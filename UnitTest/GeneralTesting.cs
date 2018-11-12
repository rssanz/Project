using Data.DataAccess;
using Data.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ServiceRate.Implementations;
using ServiceRate.Interfaces;
using ServiceUtils.Interfaces;
using System.Collections.Generic;
using Moq;

namespace GeneralTesting
{
    [TestClass]
    public class GeneralTesting
    {
        public const string _rateString = @"[
                {""From"":""EUR"",""To"":""CAD"",""Rate"":1.17},
                {""From"":""CAD"",""To"":""EUR"",""Rate"":0.85},
                {""From"":""EUR"",""To"":""AUD"",""Rate"":1.13},
                {""From"":""AUD"",""To"":""EUR"",""Rate"":0.88},
                {""From"":""CAD"",""To"":""USD"",""Rate"":0.62},
                {""From"":""USD"",""To"":""CAD"",""Rate"":1.61}
                ]";

        [TestMethod]
        public void CheckConvertUSDtoEUR()
        {
            var mockServiceRequest = new Mock<IRequestService>();
            var mockLogger = new Mock<ILogger<RateService>>();
            var mockDao = new Mock<IRateItemDao>();

            IRateService serviceRate = new RateService(mockLogger.Object, mockDao.Object);

            
            List<RateItem> rates = JsonConvert.DeserializeObject<List<RateItem>>(_rateString);

            decimal amount = 10.5m;
            decimal result = 14.37m;

            Assert.AreEqual(serviceRate.Convert(rates, "USD", "EUR", amount), result);
        }

        [TestMethod]
        public void CheckConvertEURtoUSD()
        {
            var mockServiceRequest = new Mock<IRequestService>();
            var mockLogger = new Mock<ILogger<RateService>>();
            var mockDao = new Mock<IRateItemDao>();

            IRateService serviceRate = new RateService(mockLogger.Object, mockDao.Object);

            List<RateItem> rates = JsonConvert.DeserializeObject<List<RateItem>>(_rateString);

            decimal amount = 10.5m;
            decimal result = 7.62m;

            Assert.AreEqual(serviceRate.Convert(rates, "EUR", "USD", amount), result);
        }
    }
}