using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheKoans
{
    [TestClass]
    public class AboutHashes : KoanHelper
    {
        [TestMethod]
        public void CreatingHashes()
        {
            var hash = new Hashtable();
            Assert.AreEqual(typeof(System.Collections.Hashtable), hash.GetType());
            Assert.AreEqual(FILL_ME_IN, hash.Count);
        }

        [TestMethod]
        public void HashLiterals()
        {
            //There are several ways to get similar styles in C# to Ruby
            //See Haacked's blog here: http://haacked.com/archive/2008/01/06/collection-initializers.aspx
            //This is one way:
            var hash = new Hashtable() { { "one", "uno" }, { "two", "dos" } };
            Assert.AreEqual(FILL_ME_IN, hash.Count);
        }

        [TestMethod]
        public void AccessingHashes()
        {
            var hash = new Hashtable() { { "one", "uno" }, { "two", "dos" } };
            Assert.AreEqual(FILL_ME_IN, hash["one"]);
            Assert.AreEqual(FILL_ME_IN, hash["two"]);
            Assert.AreEqual(FILL_ME_IN, hash["doesntExist"]);
        }

        [TestMethod]
        public void ChangingHashes()
        {
            var hash = new Hashtable() { { "one", "uno" }, { "two", "dos" } };
            hash["one"] = "eins";

            var expected = new Hashtable() { { "one", FILL_ME_IN }, { "two", "dos" } };
            CollectionAssert.AreEqual(expected, hash);
        }

        [TestMethod]
        public void HashIsUnordered()
        {
            var hash1 = new Hashtable() { { "one", "uno" }, { "two", "dos" } };
            var hash2 = new Hashtable() { { "two", "dos" }, { "one", "uno" } };
            CollectionAssert.AreEqual(hash1, hash2);
        }

        [TestMethod]
        public void HashKeysAndValues()
        {
            var hash = new Hashtable() { { "one", "uno" }, { "two", "dos" } };

            //Warning: Unfamiliar syntax ahead. Because the hashtable keys
            //only return an ICollection, there isn't a good way to ask it
            //if it matches, or contains values. So we are using a trick
            //from LINQ to cast it over. Note that the casting is not important
            //for this Koan - it's the value of the keys that is interesting

            var expectedKeys = new List<string>() { "one", "two" };
            expectedKeys.Sort();
            var actualKeys = hash.Keys.Cast<string>().ToList();
            actualKeys.Sort();

            CollectionAssert.AreEqual(expectedKeys, actualKeys);

            var expectedValues = new List<string>() { FILL_ME_IN.ToString(), FILL_ME_IN.ToString() };
            expectedValues.Sort();
            var actualValues = hash.Values.Cast<string>().ToList();
            actualValues.Sort();

            CollectionAssert.AreEqual(expectedValues, actualValues);
        }

        //Begin RJG Took the original code out of CombiningHashes() method below
        //We can't add the same key:
        //Assert.Throws(typeof(FILL_ME_IN), delegate() { hash.Add("jim", 54); });
        //...to a separate method so that student can understand the exception thrown
        //End RJG
        [TestMethod]
        // Don't worry if you don't understand this MSTest attribute. Basically, it
        // expects you to identify the type of exception thrown in the method below.
        // Don't cop out and use the base class Exception; investigate what the
        // specific Exception is.
        // Maybe someone in the group will write AboutMSTest to make it clearer.
        [ExpectedException(typeof(FILL_ME_IN))]
        public void CannotAddSameKeyInHashtable()
        {
            var hash = new Hashtable() { { "jim", 53 }, { "amy", 20 }, { "dan", 23 } };

            //We can't add the same key:
            hash.Add("jim", 54);
        }


        [TestMethod]
        public void CombiningHashes()
        {
            var hash = new Hashtable() { { "jim", 53 }, { "amy", 20 }, { "dan", 23 } };

            //We can't add the same key:
            //Begin RJG Converted the original code of 
            //Assert.Throws(typeof(FILL_ME_IN), delegate() { hash.Add("jim", 54); });
            //...to the CannotAddSameKeyInHashtable() method above.
            //End RJG

            //But let's say we wanted to merge two Hashtables? 
            //We have the following:
            var newHash = new Hashtable() { { "jim", 54 }, { "jenny", 26 } };

            //and we want to 'merge' this into our first hashtable. This will do
            //the trick
            foreach (DictionaryEntry item in newHash)
            {
                hash[item.Key] = item.Value;
            }

            Assert.AreEqual(FILL_ME_IN, hash["jim"]);
            Assert.AreEqual(FILL_ME_IN, hash["jenny"]);
            Assert.AreEqual(FILL_ME_IN, hash["amy"]);

        }

    }
}
