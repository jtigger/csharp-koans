using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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
            Assert.AreEqual(typeof(FILL_ME_IN), empty_array.GetType());

            //Note that you have to explicitly check for subclasses
            Assert.IsTrue(typeof(Array).IsAssignableFrom(empty_array.GetType()));

            Assert.AreEqual(FILL_ME_IN, empty_array.Length);
        }

        [TestMethod]
        public void ArrayLiterals()
        {
            var array = new[] { 42 };
            Assert.AreEqual(typeof(int[]), array.GetType(), "You don't have to specify a type if the elements can be inferred");
            Assert.AreEqual(new int[] { 42 }, array, "These arrays are literally equal... But you won't see this string in the error message.");

            //Are arrays 0-based or 1-based?
            Assert.AreEqual(42, array[((int)FILL_ME_IN)], "Well, it's either 0 or 1.. you have a 110010-110010 chance of getting it right.");

            //This is important because...
            Assert.IsTrue(array.IsFixedSize, "...because Fixed Size arrays are not dynamic");

            //Begin RJG
            // Moved this Throws() call to a separate FixedSizeArraysCannotGrow() method below
            //...it means we can't do this: array[1] = 13;
            //Assert.Throws(typeof(FILL_ME_IN), delegate() { array[1] = 13; });
            //End RJG

            //This is because the array is fixed at length 1. You could write a function
            //which created a new array bigger than the last, copied the elements over, and
            //returned the new array. Or you could do this:
            var dynamicArray = new List<int>();
            dynamicArray.Add(42);
            CollectionAssert.AreEqual(array, dynamicArray.ToArray(), "Dynamic arrays can grow");

            dynamicArray.Add(13);
            CollectionAssert.AreEqual((new int[] { 42, (int)FILL_ME_IN }), dynamicArray.ToArray(), "Identify all of the elements in the array");
        }

        [TestMethod]
        public void TestMe()
        {
            var array = new[] { 42 };
            var dynamicArray = new List<int>();
            dynamicArray.Add(42);
            CollectionAssert.AreEqual(array, dynamicArray.ToArray(), "The answer to the Ultimate Question of Life is 42.  It's just not the answer to this Assert.");
            dynamicArray.Add(13);
            CollectionAssert.AreEqual((new int[] { 42, (int)FILL_ME_IN }), dynamicArray.ToArray(), "So Long, and Thanks for All the Array Elements..");
        }

        //Begin RJG
        // Taken from the Assert.Throws() call in ArrayLiter() above
        [TestMethod]
        public void FixedSizeArraysCannotGrow()
        {
            try
            {
                var array = new[] { 42 };
                array[1] = 13;
            }
            catch (Exception exception)
            {
                Assert.AreEqual(FILL_ME_IN, exception.Message, "Fixed Size arrays -- compared to Dynamic arrays -- by their very definition, cannot grow. They're fixed. So.. Yeah.");
            }

        }
        //End RJG

        [TestMethod]
        public void AccessingArrayElements()
        {
            var array = new[] { "peanut", "butter", "and", "jelly" };

            Assert.AreEqual(FILL_ME_IN, array[0], "My daughter loves PB&J sandwiches, but not just-peanut-butter and not just-jelly sandwiches.  Go figure.");
            Assert.AreEqual(FILL_ME_IN, array[3], "'This game is in the refrigerator... the butter's getting hard, and the Jell-O is jiggling' - Chick Hearn");

            try
            {
                var cannotDoThis = array[-1];
            }
            catch (Exception exception)
            {

                Assert.AreEqual(FILL_ME_IN, exception.Message,
                                "Getting this one correct will help you better understand where to look for Exceptions when they occur.");
            }
            
        }

        [TestMethod]
        public void SlicingArrays()
        {
            var array = new[] { "peanut", "butter", "and", "jelly" };

            // Calling an array's Take(x) method will return the specified x number of elements from the start of the array.
            Assert.AreEqual(new string[] { "peanut", "butter" }, array.Take((int) FILL_ME_IN).ToArray(), "George Washington Carver would be proud you've found another use of peanut butter.");
            // Calling an array's Skip(y) method will bypass the specified y number of elements from the start of the array and return the remaining elements.
            CollectionAssert.AreEqual(new string[] { "and" }, array.Skip((int)FILL_ME_IN).Take(1).ToArray(), "Your array slicing skills need more practice to hone your C# Karma.");
        }

        [TestMethod]
        public void PushingAndPopping()
        {
            var array = new[] { 1, 2 };
            // Notice how an array is put onto the stack.  It may not be what you expect.
            var stack = new Stack(array);
            stack.Push("last");
            CollectionAssert.AreEqual((ICollection) FILL_ME_IN, stack.ToArray(), "Converting this stack back into an Array may surprise you.");
            var poppedValue = stack.Pop();
            Assert.AreEqual(FILL_ME_IN, poppedValue, "Popped values come from the top.  I suppose if they came from the bottom it would be called... Plop?");
            CollectionAssert.AreEqual((ICollection) FILL_ME_IN, stack.ToArray(), "I'm not sure why this one is here.. I guess there wasn't enough material to create an AboutStacks...");
        }

        [TestMethod]
        public void ManagingElementsAtBothEnds()
        {
            //In Ruby, "shifting" is defined as follows:
            //Shift == Remove First Element
            //Unshift == Insert Element at Beginning

            //C# doesn't provide this natively. You have a couple of options, but we'll use the LinkedList<T> to implement
            //In C#, the function names are relatively intuitive, but Shift = RemoveFirst and Unshift = AddFirst.
            var array = new[] { "Hello", "World" };
            var list = new LinkedList<string>(array);

            list.AddFirst("Say");
            CollectionAssert.AreEqual((ICollection) FILL_ME_IN, list.ToArray(), "There should be enough for AboutLists.. Why is this here?");

            list.RemoveLast();
            CollectionAssert.AreEqual((ICollection)FILL_ME_IN, list.ToArray(), "You don't usually see Hello Kitty with a mouth... so would Hello Kitty ever really say 'Hello'?");

            list.RemoveFirst();
            CollectionAssert.AreEqual((ICollection)FILL_ME_IN, list.ToArray(), "Is it me you're looking for?");

            list.AddAfter(list.Find("Hello"), "World");
            CollectionAssert.AreEqual((ICollection)FILL_ME_IN, list.ToArray(), "Now this is definitely a list test.. we're just calling ToArray multiple times here. But still good practice.");
        }

    }
}
