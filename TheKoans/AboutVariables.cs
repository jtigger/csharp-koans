using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheKoans
{
    [TestClass]
    public class AboutVariables : KoanHelper
    {
        //Parallel Assignments are a feature in Ruby which allow one
        //to set multiple variables at once using an array syntax. e.g.
        //first_name, last_name = ["John", "Smith"]
        //which would set first_name == "John" and last_name == "Smith"
        //This isn't available in C#, but there are a few interesting assignment
        //tricks we can pick up.

        [TestMethod]
        public void ImplicitAssignment()
        {
            //Even though we don't specify types explicitly, the compiler
            //will pick one for us when we choose the var keyword
            var name = "John";
            Assert.AreEqual(typeof(FILL_ME_IN), name.GetType(), "Identify the data type of the value John to proceed on your Karma quest.");

            //but only if it can. So this doesn't work
            // (Try uncommenting the line below to see how the compiler reacts)
            //var array = null;

            //It also knows the type, so once the above is in place, this doesn't work:
            // (Again, uncomment the line below to view the compiler error message)
            //name = 42;
        }

        [TestMethod]
        public void ImplicitArrayAssignmentWithSameTypes()
        {
            //Even though we don't specify types explicitly, the compiler
            //will pick one for us
            var names = new[] { "John", "Smith" };
            Assert.AreEqual(typeof(FILL_ME_IN), names.GetType(), "Determine the type of the array elements to improve your Karma.");

            //but only if it can. So this doesn't work
            // (Try uncommenting the line below to see how the compiler reacts)
            //var array = new[] { "John", 1 };
        }

        [TestMethod]
        public void MultipleAssignmentsOnSingleLine()
        {
            //You can do multiple assignments on one line, but you 
            //still have to be explicit
            string firstName = "John", lastName = "Smith";
            //And by "explicit", we mean that you cannot use this
            // (Try uncommenting the line below to see how the compiler reacts)
            //var oneName = "John", anotherName = "Smith";
            Assert.AreEqual(FILL_ME_IN, firstName, "Explicit type assignment should not impact the value.");
            Assert.AreEqual(FILL_ME_IN, lastName, "Implicit type assignment should also not impact the value (although lastName was explicitly set).");
        }

        [TestMethod]
        public void ImplicitAssignmentBasedOnAnotherVariable()
        {
            long someNumber = 92286;
            var myNum = someNumber;
            Assert.AreEqual(typeof(FILL_ME_IN), myNum.GetType(), "The apple does not fall far from the tree.  Neither does the type of the long variable you pulled the value from.");

            // So this should fail, because types cannot implicitly convert to certain others
            // (Again, uncomment the line below to view the compiler error message)
            // myNum = myNum + 3.14159265;
            // For more information on implicit conversions, check out http://msdn.microsoft.com/en-us/library/y5b434w4.aspx
            // We'll cover how to handle this further down.
        }

        [TestMethod]
        public void ImplicitAssignmentBasedOnExpressionResults()
        {
            int anInteger = 333;
            long aLongNumber = 92286L;
            var myTotal = anInteger * aLongNumber;

            Assert.AreEqual(typeof(FILL_ME_IN), myTotal.GetType(), "An int and a long walk into a bar... And their baby is a...");
        }

        [TestMethod]
        public void ExplicitAssignmentByCasting()
        {
            // So smaller "buckets" types of similar design (like the numerical types) can put 
            // their values into larger "buckets" (short --> int --> long --> float --> double)

            // But it doesn't go the other way (larger into smaller) - not implicitly anyway.
            long aLongNumber = 92286L;
            // (Try uncommenting the line below to see how the compiler would react)
            //int cannotDoThis = aLongNumber;

            // But you can "cast" to ensure that the conversion is done as you explicitly expect.
            var canDoThis = (short)aLongNumber;

            Assert.AreEqual(typeof(FILL_ME_IN), canDoThis.GetType(), "Do not be short on patience. Your path to enlightenment is a process, not a destination.");
            Assert.AreEqual(FILL_ME_IN, canDoThis, "Notice how the information is changed/lost in the conversion. This is why the compiler cannot implicitly do it.");
        }

        // You can also declare a user-defined type to enable implicit conversion
        // Don't worry if you don't understand the class definition (look for AboutClasses)
        class SpecialInt
        {
            private int val;
            public SpecialInt(int i) { val = i; }
            
            // This is a user-defined implicit conversion from SpecialInt to int
            public static implicit operator int(SpecialInt si) { return si.val; }

            // This is a user-defined implicit conversion from int to SpecialInt
            public static implicit operator SpecialInt(int i) { return new SpecialInt(i); }

            // Not to complicate the matter, but you may have to explicitly use implicit 
            // the user-defined type to enable implicit conversion...
        }

        [TestMethod]
        public void ImplicitConversionUsingImplicitKeyword()
        {
            var oneSpecialInt = new SpecialInt(123);
            
            // Implicit conversion to an integer
            int implicitInt = oneSpecialInt;
            // Implicit conversion to a SpecialInt
            SpecialInt anotherSpecialInt = implicitInt;

            var firstTest = implicitInt + oneSpecialInt;
            var secondTest = anotherSpecialInt + implicitInt;

            Assert.AreEqual(typeof(FILL_ME_IN), firstTest.GetType(), "An int and a user-defined type that can return an int walk into a bar... And their baby is a...");
            Assert.AreEqual(typeof(FILL_ME_IN), secondTest.GetType(), "This will show you the type is not based on the order of expression's operands, but their result.");
        }
    }
}
