using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheKoans
{
    [TestClass]
    public class AboutControlStatements : KoanHelper
    {
        [TestMethod]
        public void IfThenElseStatementsWithBrackets()
        {
            bool b;
            if (true)
            {
                b = true;
            }
            else
            {
                b = false;
            }

            Assert.Equals(FILL_ME_IN, b);
        }

        [TestMethod]
        public void IfThenElseStatementsWithoutBrackets()
        {
            bool b;
            if (true)
                b = true;
            else
                b = false;

            Assert.Equals(FILL_ME_IN, b);

        }

        [TestMethod]
        public void IfThenStatementsWithBrackets()
        {
            bool b = false;
            if (true)
            {
                b = true;
            }

            Assert.Equals(FILL_ME_IN, b);
        }

        [TestMethod]
        public void IfThenStatementsWithoutBrackets()
        {
            bool b = false;
            if (true)
                b = true;

            Assert.Equals(FILL_ME_IN, b);
        }

        [TestMethod]
        public void WhyItsWiseToAlwaysUseBrackets()
        {
            bool b1 = false;
            bool b2 = false;

            int counter = 1;

            if (counter == 0)
                b1 = true;
            b2 = true;

            Assert.Equals(false, b1);
            Assert.Equals(true, b2);
        }

        [TestMethod]
        public void TernaryOperators()
        {
            Assert.Equals(FILL_ME_IN, (true ? 1 : 0));
            Assert.Equals(FILL_ME_IN, (false ? 1 : 0));
        }

        //This is out of place for control statements, but necessary for Koan 8
        [TestMethod]
        public void NullableTypes()
        {
            int i = 0;
            //i = null; //You can't do this

            int? nullableInt = null; //but you can do this
            Assert.IsNotNull(i);
            Assert.IsNull(nullableInt);
        }

        [TestMethod]
        public void AssignIfNullOperator()
        {
            int? nullableInt = null;

            int x = nullableInt ?? 42;

            Assert.Equals(FILL_ME_IN, x);
        }

        [TestMethod]
        public void IsOperators()
        {
            bool isKoan = false;
            bool isAboutControlStatements = false;
            bool isAboutMethods = false;

            var myType = this;

            if (myType is KoanHelper)
                isKoan = true;

            if (myType is AboutControlStatements)
                isAboutControlStatements = true;

            if (myType is AboutNull)
                isAboutMethods = true;

            Assert.Equals(FILL_ME_IN, isKoan);
            Assert.Equals(FILL_ME_IN, isAboutControlStatements);
            Assert.Equals(FILL_ME_IN, isAboutMethods);

        }

        [TestMethod]
        public void WhileStatement()
        {
            int i = 1;
            int result = 1;
            while (i <= 10)
            {
                result = result * i;
                i += 1;
            }
            Assert.Equals(FILL_ME_IN, result);
        }

        [TestMethod]
        public void BreakStatement()
        {
            int i = 1;
            int result = 1;
            while (true)
            {
                if (i > 10) { break; }
                result = result * i;
                i += 1;
            }
            Assert.Equals(FILL_ME_IN, result);
        }

        [TestMethod]
        public void ContinueStatement()
        {
            int i = 0;
            var result = new List<int>();
            while (i < 10)
            {
                i += 1;
                if ((i % 2) == 0) { continue; }
                result.Add(i);
            }
            Assert.Equals(FILL_ME_IN, result);
        }

        [TestMethod]
        public void ForStatement()
        {
            var list = new List<string> { "fish", "and", "chips" };
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = (list[i].ToUpper());
            }
            Assert.Equals(FILL_ME_IN, list);
        }

        [TestMethod]
        public void ForEachStatement()
        {
            var list = new List<string> { "fish", "and", "chips" };
            var finalList = new List<string>();
            foreach (string item in list)
            {
                finalList.Add(item.ToUpper());
            }
            Assert.Equals(FILL_ME_IN, list);
            Assert.Equals(FILL_ME_IN, finalList);
        }

        [TestMethod]
        public void ModifyingACollectionDuringForEach()
        {
            var list = new List<string> { "fish", "and", "chips" };
            try
            {
                foreach (string item in list)
                {
                    list.Add(item.ToUpper());
                }
            }
            catch (Exception ex)
            {
                Assert.Equals(typeof(FILL_ME_IN), ex.GetType());
            }
        }

        [TestMethod]
        public void CatchingModificationExceptions()
        {
            string whoCaughtTheException = "No one";

            var list = new List<string> { "fish", "and", "chips" };
            try
            {
                foreach (string item in list)
                {
                    try
                    {
                        list.Add(item.ToUpper());
                    }
                    catch
                    {
                        whoCaughtTheException = "When we tried to Add it";
                    }
                }
            }
            catch
            {
                whoCaughtTheException = "When we tried to move to the next item in the list";
            }

            Assert.Equals(FILL_ME_IN, whoCaughtTheException);
        }

    }
}
