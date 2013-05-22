using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheKoans
{
    [TestClass]
    public class AboutArrays : KoanHelper
    {
        [TestMethod]
        public void CreatingArrays()
        {
            var empty_array = new object[] { };
            Assert.Equals(typeof(FillMeIn), empty_array.GetType());

            //Note that you have to explicitly check for subclasses
            Assert.IsTrue(typeof(Array).IsAssignableFrom(empty_array.GetType()));

            Assert.Equals(FillMeIn, empty_array.Length);
        }

        [TestMethod]
        public void ArrayLiterals()
        {
            //You don't have to specify a type if the arguments can be inferred
            var array = new[] { 42 };
            Assert.Equals(typeof(int[]), array.GetType());
            Assert.Equals(new int[] { 42 }, array);

            //Are arrays 0-based or 1-based?
            Assert.Equals(42, array[((int)FillMeIn)]);

            //This is important because...
            Assert.IsTrue(array.IsFixedSize);

            //Begin RJG
            // Moved this Throws() call to a separate FixedSizeArraysCannotGrow() method below
            //...it means we can't do this: array[1] = 13;
            //Assert.Throws(typeof(FillMeIn), delegate() { array[1] = 13; });
            //End RJG

            //This is because the array is fixed at length 1. You could write a function
            //which created a new array bigger than the last, copied the elements over, and
            //returned the new array. Or you could do this:
            var dynamicArray = new List<int>();
            dynamicArray.Add(42);
            Assert.Equals(array, dynamicArray.ToArray());

            dynamicArray.Add(13);
            Assert.Equals((new int[] { 42, (int)FillMeIn }), dynamicArray.ToArray());
        }

        //Begin RJG
        // Taken from the Assert.Throws() call in ArrayLiter() above
        [TestMethod]
        // Don't worry if you don't understand the MSTest attribute ExpectedException. 
        // Basically, itexpects you to identify the type of exception thrown in the 
        // method below.Don't cop out and use the base class Exception; investigate 
        // what the specific Exception is.
        // Maybe someone in the group will write AboutMSTest to make it clearer.
        [ExpectedException(typeof(FillMeIn))]
        public void FixedSizeArraysCannotGrow()
        {
            var array = new[] { 42 };
            array[1] = 13;
        }
        //End RJG

        [TestMethod]
        public void AccessingArrayElements()
        {
            var array = new[] { "peanut", "butter", "and", "jelly" };

            Assert.Equals(FillMeIn, array[0]);
            Assert.Equals(FillMeIn, array[3]);

            //This doesn't work: Assert.Equals(FillMeIn, array[-1]);
        }

        [TestMethod]
        public void SlicingArrays()
        {
            var array = new[] { "peanut", "butter", "and", "jelly" };

            Assert.Equals(new string[] { "peanut", "butter" }, array.Take(2).ToArray());
            Assert.Equals(new string[] { "butter", "and" }, array.Skip(1).Take(2).ToArray());
        }

        [TestMethod]
        public void PushingAndPopping()
        {
            var array = new[] { 1, 2 };
            var stack = new Stack(array);
            stack.Push("last");
            Assert.Equals(FillMeIn, stack.ToArray());
            var poppedValue = stack.Pop();
            Assert.Equals(FillMeIn, poppedValue);
            Assert.Equals(FillMeIn, stack.ToArray());
        }

        [TestMethod]
        public void Shifting()
        {
            //Shift == Remove First Element
            //Unshift == Insert Element at Beginning
            //C# doesn't provide this natively. You have a couple
            //of options, but we'll use the LinkedList<T> to implement
            var array = new[] { "Hello", "World" };
            var list = new LinkedList<string>(array);

            list.AddFirst("Say");
            Assert.Equals(FillMeIn, list.ToArray());

            list.RemoveLast();
            Assert.Equals(FillMeIn, list.ToArray());

            list.RemoveFirst();
            Assert.Equals(FillMeIn, list.ToArray());

            list.AddAfter(list.Find("Hello"), "World");
            Assert.Equals(FillMeIn, list.ToArray());
        }

    }
}
