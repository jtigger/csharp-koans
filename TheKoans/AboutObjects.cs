using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheKoans
{
    [TestClass]
    public class AboutObjects
    {
        private object FILL_ME_IN = new Object();

        [TestMethod]
        public void EverythingIsAnObject()
        {
            Assert.AreEqual(FILL_ME_IN, 1 is Object);
            Assert.AreEqual(FILL_ME_IN, 1.5 is Object);
            Assert.AreEqual(FILL_ME_IN, "string" is Object);
            Assert.AreEqual(FILL_ME_IN, true is Object);
        }

        [TestMethod]
        public void ExceptNullIsNotAnObject()
        {
            Assert.AreEqual(FILL_ME_IN, null is Object);
        }

        [TestMethod]
        public void ObjectLiteralIsAnObject()
        {
            Assert.AreEqual(FILL_ME_IN, new { } is Object);
        }

        //TODO - finish remaining object tests from the RubyKoans AboutObjects
    }
}
