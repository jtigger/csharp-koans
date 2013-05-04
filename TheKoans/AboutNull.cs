using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheKoans
{
    [TestClass]
    public class AboutNull
    {
        public const string ReplaceMeWithAString = "";

        [TestMethod]
        public void NullIsNotAnInstanceOfObjectAndInvokingAMethodThrowsNullReferenceException()
        {
            Object nullReference = null;

            try
            {
                nullReference.GetHashCode();
            }
            catch (Exception exception)
            {
                Assert.AreEqual(ReplaceMeWithAString, exception.Message);
            }
        }
    }
}
