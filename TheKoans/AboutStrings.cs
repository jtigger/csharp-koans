using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheKoans
{
    [TestClass]
    public class AboutStrings : KoanHelper
    {

        //Note: This is one of the longest katas and, perhaps, one
        //of the most important. String behavior in .NET is not
        //always what you expect it to be, especially when it comes
        //to concatenation and newlines, and is one of the biggest
        //causes of memory leaks in .NET applications

        [TestMethod]
        public void DoubleQuotedStringsAreStrings()
        {
            var str = "Hello, World";
            Assert.Equals(typeof(FillMeIn), str.GetType());
        }

        [TestMethod]
        public void SingleQuotedStringsAreNotStrings()
        {
            var str = 'H';
            Assert.Equals(typeof(Char), str.GetType());
        }

        [TestMethod]
        public void CreateAStringWhichContainsDoubleQuotes()
        {
            var str = "Hello, \"World\"";
            Assert.Equals(FillMeIn, str.Length);
        }

        [TestMethod]
        public void AnotherWayToCreateAStringWhichContainsDoubleQuotes()
        {
            //The @ symbol creates a 'verbatim string literal'. 
            //Here's one thing you can do with it:
            var str = @"Hello, ""World""";
            Assert.Equals(FillMeIn, str.Length);
        }

        // Start RJG adding String Comparison

        [TestMethod]
        public void UnderstandingEmptyStrings()
        {
            var str = "";
            // Below are 6 checks for an empty string.
            Assert.IsTrue(str.Equals(""));                  // first
            Assert.IsTrue(string.Equals(str, ""));          // second
            Assert.IsTrue(str == "");                       // third
            Assert.IsTrue(string.IsNullOrWhiteSpace(str));  // fourth (introduced in .NET 4.0)
            Assert.IsTrue(string.IsNullOrEmpty(str));       // fifth
            Assert.IsTrue(str.Length == 0);                 // sixth
            // These are listed in order of performance from worst to best.
            // If you had FxCop installed, it would warn you of the performance
            // hit using the other implementations.
            // For more information on FxCop: https://www.microsoft.com/en-us/download/details.aspx?id=6544
            
            // Maybe there's a better way of sharing this information, but just add True
            // below after reading this.
            Assert.Equals(true, FillMeIn);
        }


        [TestMethod]
        public void CaseMattersWhenComparingStrings()
        {
            var strProper = "United States of America";
            var strUpper = "UNITED STATES OF AMERICA";
            Assert.Equals(FillMeIn, strProper.Equals(strUpper));
        }

        [TestMethod]
        public void ConvertTheCaseToMakeComparisonCaseInsensitive()
        {
            var strProper = "United States of America";
            var strUpper = "UNITED STATES OF AMERICA";

            // Strings have built-in methods to do the conversion
            Assert.Equals(strProper, strUpper);
        }

        [TestMethod]
        public void UseComparisonTypeToMakeComparisonCaseInsensitive()
        {
            var strProper = "United States of America";
            var strUpper = "UNITED STATES OF AMERICA";

            // Note: Explore the various values for the third parameter of String.Equals().
            Assert.IsTrue(String.Equals(strProper, strUpper, 0));
        }

        [TestMethod]
        public void StringComparisonUsingCurrentCulture()
        {
            var strA = "CAT";
            var strB = "bat";
            // Setting strC to the string with the lower value
            var strC = string.Compare(strA, strB, StringComparison.CurrentCulture) < 0 ? strA : strB;
            Assert.Equals(FillMeIn, strC);
        }

        [TestMethod]
        public void StringComparisonUsingInvariantCulture()
        {
            var strA = "CAT";
            var strB = "bat";
            // Setting strC to the string with the lower value
            var strC = string.Compare(strA, strB, StringComparison.InvariantCulture) < 0 ? strA : strB;
            Assert.Equals(FillMeIn, strC);
        }

        [TestMethod]
        public void StringComparisonUsingOrdinal()
        {
            var strA = "CAT";
            var strB = "bat";
            // Setting strC to the string with the lower value
            var strC = string.Compare(strA, strB, StringComparison.Ordinal) < 0 ? strA : strB;
            Assert.Equals(FillMeIn, strC);
        }

        [TestMethod]
        public void StringComparisonUsingReferenceEquals()
        {
            var str1 = "Inconceivable!";
            var sb1 = new StringBuilder("Inconceivable!");
            var str2 = "Inconceivable!";
            Assert.Equals(FillMeIn, ReferenceEquals(str1, sb1.ToString()));
            Assert.Equals(FillMeIn, ReferenceEquals(str1, str2));
        }

        // End RJG adding String Comparison

        [TestMethod]
        public void VerbatimStringsCanHandleFlexibleQuoting()
        {
            var strA = @"Verbatim Strings can handle both ' and "" characters (when escaped)";
            var strB = "Verbatim Strings can handle both ' and \" characters (when escaped)";
            Assert.Equals(FillMeIn, strA.Equals(strB));
        }
        
        [TestMethod]
        public void VerbatimStringsCanHandleMultipleLinesToo()
        {
            //A verbatim string literal is one in which no escape
            //sequences are processed.  It contains exactly the
            //characters entered, and can also span multiple lines.
            //Tip: What you create for the literal string will have to 
            //escape the newline characters. 
            var verbatimString = @"I
am a
broken line";
            Assert.Equals(20, verbatimString.Length);
            var literalString = FillMeIn;
            Assert.Equals(literalString, verbatimString);
        }

        [TestMethod]
        public void ACrossPlatformWayToHandleLineEndings()
        {
            //Since line endings are different on different platforms
            //(\r\n for Windows, \n for Linux) you shouldn't just type in
            //the hardcoded escape sequence. A much better way
            //(We'll handle concatenation and better ways of that in a bit)
            var literalString = "I" + Environment.NewLine + "am a" + Environment.NewLine + "broken line";
            var vebatimString = FillMeIn;
            Assert.Equals(literalString, vebatimString);
        }

        [TestMethod]
        public void PlusWillConcatenateTwoStrings()
        {
            var str = "Hello, " + "World";
            Assert.Equals(FillMeIn, str);
        }

        [TestMethod]
        public void PlusConcatenationWillNotModifyOriginalStrings()
        {
            var strA = "Hello, ";
            var strB = "World";
            var fullString = strA + strB;
            Assert.Equals(FillMeIn, strA);
            Assert.Equals(FillMeIn, strB);
            Assert.Equals(FillMeIn, fullString);
        }

        [TestMethod]
        public void PlusEqualsWillModifyTheTargetString()
        {
            var strA = "Hello, ";
            var strB = "World";
            strA += strB;
            Assert.Equals(FillMeIn, strA);
            Assert.Equals(FillMeIn, strB);
        }

        [TestMethod]
        public void StringsAreReallyImmutable()
        {
            // 'Immutable' means the value does not change. Strings, numbers
            // and the null value are all truly immutable.

            //So here's the thing. Concatenating strings is cool
            //and all. But if you think you are modifying the original
            //string, you'd be wrong. 

            var strA = "Hello, ";
            var originalString = strA;
            var strB = "World";
            strA += strB;
            Assert.Equals("Hello, ", originalString);

            //What just happened? Well, the string concatenation actually
            //takes strA and strB and creates a *new* string in memory
            //that has the new value. It does *not* modify the original
            //string. This is a very important point - if you do this kind
            //of string concatenation in a tight loop, you'll use a lot of memory
            //because the original string will hang around in memory until the
            //garbage collector picks it up. Let's look at a better way
            //when dealing with lots of concatenation
        }

        [TestMethod]
        public void ABetterWayToConcatenateLotsOfStrings()
        {
            //As shows in the above Koan, concatenating lots of strings
            //is a Bad Idea(tm). If you need to do that, then do this instead
            var strBuilder = new System.Text.StringBuilder();
            for (int i = 0; i < 100; i++) { strBuilder.Append("a"); }
            var str = strBuilder.ToString();
            Assert.Equals(FillMeIn, str.Length);

            //The tradeoff is that you have to create a StringBuilder object, 
            //which is a higher overhead than a string. So the rule of thumb
            //is that if you need to concatenate less than 5 strings, += is fine.
            //If you need more than that, use a StringBuilder. 
        }

        [TestMethod]
        public void LiteralStringsInterpretsEscapeCharacters()
        {
            var str = "\n";
            Assert.Equals(FillMeIn, str.Length);
        }

        [TestMethod]
        public void VerbatimStringsDoNotInterpretEscapeCharacters()
        {
            var str = @"\n";
            Assert.Equals(FillMeIn, str.Length);
        }

        [TestMethod]
        public void VerbatimStringsStillDoNotInterpretEscapeCharacters()
        {
            var str = @"\\\";
            Assert.Equals(FillMeIn, str.Length);
        }

        [TestMethod]
        public void YouDoNotNeedConcatenationToInsertVariablesInAString()
        {
            var world = "World";
            var str = String.Format("Hello, {0}", world);
            Assert.Equals(FillMeIn, str);
        }

        [TestMethod]
        public void AnyExpressionCanBeUsedInFormatString()
        {
            var str = String.Format("The square root of 9 is {0}", Math.Sqrt(9));
            Assert.Equals(FillMeIn, str);
        }

        [TestMethod]
        public void YouCanGetASubstringFromAString()
        {
            var str = "Bacon, lettuce and tomato";
            Assert.Equals(FillMeIn, str.Substring(19));
            Assert.Equals(FillMeIn, str.Substring(7, 3));
        }

        [TestMethod]
        public void YouCanGetASingleCharacterFromAString()
        {
            var str = "Bacon, lettuce and tomato";
            Assert.Equals(FillMeIn, str[0]);
        }

        [TestMethod]
        public void SingleCharactersAreRepresentedByIntegers()
        {
            Assert.Equals(97, 'a');
            Assert.Equals(98, 'b');
            Assert.Equals(FillMeIn, 'b' == ('a' + 1));
        }

        [TestMethod]
        public void StringsCanBeSplit()
        {
            var str = "Sausage Egg Cheese";
            string[] words = str.Split();
            Assert.Equals(new[] { FillMeIn }, words);
        }

        [TestMethod]
        public void StringsCanBeSplitUsingCharacters()
        {
            var str = "the:rain:in:spain";
            string[] words = str.Split(':');
            Assert.Equals(new[] { FillMeIn }, words);
        }

        [TestMethod]
        public void StringsCanBeSplitUsingRegularExpressions()
        {
            var str = "the:rain:in:spain";
            var regex = new System.Text.RegularExpressions.Regex(":");
            string[] words = regex.Split(str);
            Assert.Equals(new[] { FillMeIn }, words);

            //A full treatment of regular expressions is beyond the scope
            //of this tutorial. The book "Mastering Regular Expressions"
            //is highly recommended to be on your bookshelf
        }

        // Start RJG Adding Yet More 

        [TestMethod]
        public void InsertingStrings()
        {
            var str = "John Adams";
            Assert.Equals(FillMeIn, str.Insert(5, "Quincy "));

            // Note that Insert() does not change the value of immutable string str
            // Assert.Equals(str, "John Quincy Adams"); // This will fail
            // But see below...
        }

        [TestMethod]
        public void CallingInsertDoesNotAssignUnlessYouExplicitlySaveTheResult()
        {
            var str = "John Adams";
            str = str.Insert(5, "Quincy ");
            Assert.Equals(FillMeIn, str);
        }

        [TestMethod]
        public void RemovingStrings()
        {
            var str = "OholeNE";
            str = str.Remove(1, 4);
            Assert.Equals(FillMeIn, str);
        }

        [TestMethod]
        public void UnderstandingTrim()
        {
            var str = "     All that really matters    ";
            Assert.Equals(FillMeIn, str.Trim());
        }

        [TestMethod]
        public void UnderstandingTrimStart()
        {
            var str = "     All that really matters    ";
            Assert.Equals(FillMeIn, str.TrimStart());
        }

        [TestMethod]
        public void UnderstandingTrimEnd()
        {
            var str = "     All that really matters    ";
            Assert.Equals(FillMeIn, str.TrimEnd());
        }

        // End RJG Adding Yet More 
    }
}
