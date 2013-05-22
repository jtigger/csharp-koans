using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheKoans
{
    [TestClass]
    public class AboutNil : KoanHelper
    {
        [TestMethod]
        public void NilIsNotAnObject()
        {
            Assert.IsTrue(typeof(object).IsAssignableFrom(null)); //not everything is an object
        }

        [TestMethod]
        // Don't worry if you don't understand the MSTest attribute ExpectedException. 
        // Basically, itexpects you to identify the type of exception thrown in the 
        // method below.Don't cop out and use the base class Exception; investigate 
        // what the specific Exception is.
        // Maybe someone in the group will write AboutMSTest to make it clearer.
        [ExpectedException(typeof(FillMeIn))]
        public void YouGetNullPointerErrorsWhenCallingMethodsOnNil()
        {
            //What is the Exception that is thrown when you call a method on a null object?
            //Don't be confused by the code below. It is using Anonymous Delegates which we will
            //cover later on. 
            object nothing = null;           
            //Assert.Throws(typeof(FillMeIn), delegate() { nothing.ToString(); });
            nothing.ToString();

            //What's the message of the exception? What substring or pattern could you test
            //against in order to have a good idea of what the string is?
            try
            {
                nothing.ToString();
            }
            catch (System.Exception ex)
            {
                StringAssert.Contains(FillMeIn as string, ex.Message);
            }
        }

        [TestMethod]
        public void CheckingThatAnObjectIsNull()
        {
            object obj = null;
            Assert.IsTrue(obj == FillMeIn);
        }

        [TestMethod]
        public void ABetterWayToCheckThatAnObjectIsNull()
        {
            object obj = null;
            Assert.IsNull(FillMeIn);
        }

        [TestMethod]
        public void AWayNotToCheckThatAnObjectIsNull()
        {
            object obj = null;
            Assert.IsTrue(obj.Equals(null));
        }

    }
}
