using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheKoans
{

    [TestClass]
    public class AboutAsserts
    {
        public const int ReplaceMeWithAnInteger = 0;

        [TestMethod]
        public void AssertTruth()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void AssertWithMessage()
        {
            Assert.IsTrue(false, "This condition should be true, please make it so.");
        }

        [TestMethod]
        public void AssertEquality()
        {
            var expectedValue = ReplaceMeWithAnInteger;
            var actualValue = 1 + 1;

            Assert.AreEqual(expectedValue, actualValue, "A lack of understanding about equality has broken your karma.");
        }


    }
}
