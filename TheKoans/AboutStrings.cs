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
            Assert.AreEqual(typeof(FILL_ME_IN), str.GetType(), "What did Arial say to Serif? - Sorry, you're not my Type.");
        }

        [TestMethod]
        public void SingleQuotedStringsAreNotStrings()
        {
            var str = 'H';
            Assert.AreEqual(typeof(FILL_ME_IN), str.GetType(), "A single tree does not a forest make.");
        }

        [TestMethod]
        public void CreateAStringWhichContainsDoubleQuotes()
        {
            var str = "Hello, \"World\"";
            Assert.AreEqual(FILL_ME_IN, str.Length, "If the length is wrong and you're trapped, consider ways to escape this...");
        }

        [TestMethod]
        public void AnotherWayToCreateAStringWhichContainsDoubleQuotes()
        {
            //The @ symbol creates a 'verbatim string literal'. 
            //Here's one thing you can do with it:
            var str = @"Hello, ""World""";
            Assert.AreEqual(FILL_ME_IN, str.Length, "So many quotes, so few characters...");
        }

        [TestMethod]
        public void VerbatimStringsCanHandleFlexibleQuoting()
        {
            var strA = @"Verbatim Strings can handle both ' and "" characters (when escaped)";
            var strB = "Verbatim Strings can handle both ' and \" characters (when escaped)";
            Assert.AreEqual(FILL_ME_IN, strA.Equals(strB), "You've been told three times what Verbatim Strings can handle single and double quotes.. well, I guess this makes it four.");
        }
        
        [TestMethod]
        public void VerbatimStringsCanHandleMultipleLinesToo()
        {
            //A verbatim string literal is one in which no escape
            //sequences are processed.  It contains exactly the
            //characters entered, and can also span multiple lines. 
            var verbatimString = @"I
am a
broken line";
            Assert.AreEqual(FILL_ME_IN, verbatimString.Length, "Is a newline one or two characters?");
            //Tip: What you create for the literal string will have to 
            //escape the newline characters.
            var literalString = FILL_ME_IN;
            Assert.AreEqual(literalString, verbatimString, "It wouldn't be cheating if you looked down.  No, not at your feet; the method below.");
        }

        [TestMethod]
        public void ACrossPlatformWayToHandleLineEndings()
        {
            //Since line endings are different on different platforms
            //(\r\n for Windows, \n for Linux) you shouldn't just type in
            //the hardcoded escape sequence. A much better way
            //(We'll handle concatenation and better ways of that in a bit)
            var literalString = "I" + Environment.NewLine + "am a" + Environment.NewLine + "broken line";
            var vebatimString = FILL_ME_IN;
            Assert.AreEqual(literalString, vebatimString, "Is a newline one or two characters?");
        }

        [TestMethod]
        public void PlusWillConcatenateTwoStrings()
        {
            var str = "Hello, " + "World";
            Assert.AreEqual(FILL_ME_IN, str, "Such a simple phrase, and yet sometimes it takes so much code just to make it happen..");
        }

        [TestMethod]
        public void PlusConcatenationWillNotModifyOriginalStrings()
        {
            var strA = "Hello, ";
            var strB = "World";
            var fullString = strA + strB;
            Assert.AreEqual(FILL_ME_IN, strA, "The Method name suggests it wouldn't be modified, but only one way to find out");
            Assert.AreEqual(FILL_ME_IN, strB, "Well, I guess checking both variables is technically an OTHER way...");
            Assert.AreEqual(FILL_ME_IN, fullString, "I think they purposefully call it concatenation to make it sound as complex as it really is");
        }

        [TestMethod]
        public void PlusEqualsWillModifyTheTargetString()
        {
            var strA = "Hello, ";
            var strB = "World";
            strA += strB;
            Assert.AreEqual(FILL_ME_IN, strA, "Are you a parrot now?");
            Assert.AreEqual(FILL_ME_IN, strB, "Why did they stop at world?  Why not 'Universe'?  Why not 'Zoidberg'?");
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
            Assert.AreEqual(FILL_ME_IN, originalString, "'Be yourself. The world worships the original.' - Jacques Cocteau");

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
            Assert.AreEqual(FILL_ME_IN, str.Length, "When Charles M. Schulz drew Charlie Brown's screams (AAAARGH!) - did he ever wonder if he mispelled them?");

            //The tradeoff is that you have to create a StringBuilder object, 
            //which is a higher overhead than a string. So the rule of thumb
            //is that if you need to concatenate less than 5 strings, += is fine.
            //If you need more than that, use a StringBuilder. 
        }

        [TestMethod]
        public void LiteralStringsInterpretsEscapeCharacters()
        {
            var str = "\n";
            Assert.AreEqual(FILL_ME_IN, str.Length, "This is just like 'the sound of one hand clapping'...");
        }

        [TestMethod]
        public void VerbatimStringsDoNotInterpretEscapeCharacters()
        {
            var str = @"\n";
            Assert.AreEqual(FILL_ME_IN, str.Length, "'True art selects and paraphrases, but seldom gives a verbatim translation.' - Thomas Bailey Aldrich");
        }

        [TestMethod]
        public void VerbatimStringsStillDoNotInterpretEscapeCharacters()
        {
            var str = @"\\\";
            Assert.AreEqual(FILL_ME_IN, str.Length, "Perhaps it would help to look up the definition of verbatim, eh?");
        }

        [TestMethod]
        public void YouDoNotNeedConcatenationToInsertVariablesInAString()
        {
            var world = "World";
            var str = String.Format("Hello, {0}", world);
            Assert.AreEqual(FILL_ME_IN, str, "Usually this is the first thing that programmers do..");
        }

        [TestMethod]
        public void AnyExpressionCanBeUsedInFormatString()
        {
            var str = String.Format("The square root of 9 is {0}", Math.Sqrt(9));
            Assert.AreEqual(FILL_ME_IN, str, ".NET will convert the value into a string, but you still have to do the math.");
        }

        [TestMethod]
        public void YouCanGetASubstringFromAString()
        {
            var str = "Bacon, lettuce and tomato";
            Assert.AreEqual(FILL_ME_IN, str.Substring(19), "In one version of this overloaded method, you only need to specify where to begin.");
            Assert.AreEqual(FILL_ME_IN, str.Substring(7, 3), "In the other version, you also specify how far to go.");
        }

        [TestMethod]
        public void YouCanGetASingleCharacterFromAString()
        {
            var str = "Bacon, lettuce and tomato";
            Assert.AreEqual(FILL_ME_IN, str[6], "0-based arrays are sometimes confusing.. do you count the 0 or not?");
        }

        [TestMethod]
        public void SingleCharactersAreRepresentedByIntegers()
        {
            Assert.AreEqual(97, 'a');
            Assert.AreEqual(98, 'b');
            Assert.AreEqual(FILL_ME_IN, 'b' == ('a' + 1), "You can thank your Algebra teacher later..");
        }

        [TestMethod]
        public void StringsCanBeSplit()
        {
            var str = "Sausage Egg Cheese";
            string[] words = str.Split();
            Assert.AreEqual(new[] { FILL_ME_IN }, words, "Identify all the elements in the 'words' string array based on the 'str' string.  And hurry.. I'm getting hungry.");
        }

        [TestMethod]
        public void StringsCanBeSplitUsingCharacters()
        {
            var str = "Peter:Flopsy:Mopsy:Cottontail";
            string[] words = str.Split(':');
            Assert.AreEqual(new[] { FILL_ME_IN }, words, "I just had to find a way to split hares.");
        }

        [TestMethod]
        public void StringsCanBeSplitUsingRegularExpressions()
        {
            var str = "the:rain:in:spain";
            var regex = new System.Text.RegularExpressions.Regex(":");
            string[] words = regex.Split(str);
            Assert.AreEqual(new[] { FILL_ME_IN }, words, "Ever watch 'My Fair Lady'?  I don't think one could come up with a regular expression for how Eliza spoke.");

            //A full treatment of regular expressions is beyond the scope
            //of this tutorial. The book "Mastering Regular Expressions"
            //is highly recommended to be on your bookshelf:
            //http://www.amazon.com/Mastering-Regular-Expressions-Jeffrey-Friedl/dp/0596528124
        }

        // Start RJG adding more about strings

        [TestMethod]
        public void UnderstandingThePerformanceOfCheckingForEmptyStrings()
        {
            var str = "";
            // Below are 6 checks for an empty string.
            Assert.IsTrue(str.Equals(""));                  // first
            Assert.IsTrue(string.Equals(str, ""));          // second
            Assert.IsTrue(str == "");                       // third
            Assert.IsTrue(string.IsNullOrWhiteSpace(str));  // fourth (introduced in .NET 4.0)
            Assert.IsTrue(string.IsNullOrEmpty(str));       // fifth
            Assert.IsTrue(str.Length == 0);                 // sixth
            // These are listed in order of performance, from worst to best, i.e., == is preferred.
            // If you had FxCop installed, it would warn you of the performance
            // hit using the other implementations.
            // For more information on FxCop: https://www.microsoft.com/en-us/download/details.aspx?id=6544

            // Maybe there's a better way of sharing this information, but just add True
            // below after reading this.
            Assert.AreEqual(true, FILL_ME_IN, "Sometimes you need to take time and stop to smell the performance..");
        }

        [TestMethod]
        public void CaseMattersWhenComparingStrings()
        {
            var strProper = "United States of America";
            var strUpper = "UNITED STATES OF AMERICA";
            Assert.AreEqual(FILL_ME_IN, strProper.Equals(strUpper), "It's not what you say, it's how you say it.");
        }

        [TestMethod]
        public void ConvertTheCaseToMakeComparisonSoThatCaseDoesNotMatter()
        {
            var strProper = "United States of America";
            var strUpper = "UNITED STATES OF AMERICA";

            // Strings have built-in methods to do the conversion
            // Do a conversion on strProper to make it match strUpper
            Assert.AreEqual(FILL_ME_IN, strUpper, "How can you argue with something in ALL CAPS? Someone took the time to press the shift key..");
        }

        [TestMethod]
        public void OrUseThisToCompareStringsUsingCaseInsensitivity()
        {
            var strProper = "United States of America";
            var strUpper = "UNITED STATES OF AMERICA";

            Assert.AreEqual(String.Compare(strProper, strUpper, true), FILL_ME_IN, "Six of one, half a dozen of another.");

            // And be aware there are additional ways to compare (like .CompareTo), 
            // but that might be better under AboutObjects?
        }

        [TestMethod]
        public void InsertingStrings()
        {
            var str = "John Adams";
            Assert.AreEqual(str.Insert(5, "Quincy"), FILL_ME_IN, "I wonder if they called the 6th President of the United States 'Q', like we used to call the last Bush president 'W'...");

            // Note that Insert() does not change the value of immutable string str
            // Assert.AreEqual(str, "John Quincy Adams"); // This would not pass
            // But see below...
        }

        [TestMethod]
        public void CallingInsertDoesNotAssignUnlessYouExplicitlySaveTheResult()
        {
            var str = "John Adams";
            str = str.Insert(5, "Quincy ");
            Assert.AreEqual(FILL_ME_IN, str, "'To furnish the means of acquiring knowledge is... the greatest benefit that can be conferred upon mankind' - John Quincy Adams");
        }

        [TestMethod]
        public void RemovingStrings()
        {
            var str = "OholeNE";
            str = str.Remove(1, 4);
            Assert.AreEqual(str, FILL_ME_IN, "Channeling Tiger Woods might help you identify the resulting string from this 'hole' in 'ONE'...");
        }

        [TestMethod]
        public void UnderstandingTrim()
        {
            var str = "     All that really matters    ";
            Assert.AreEqual(str.Trim(), FILL_ME_IN, "Yes, they're simple exercises. But after learning multiple programming languages, you almost have to double check to make sure they do what you expect.");
        }

        [TestMethod]
        public void UnderstandingTrimStart()
        {
            var str = "     All that really matters    ";
            Assert.AreEqual(FILL_ME_IN, str.TrimStart(), "I find this easier to understand when seen in context of the other Trim functions.");
        }

        [TestMethod]
        public void UnderstandingTrimEnd()
        {
            var str = "     All that really matters    ";
            Assert.AreEqual(FILL_ME_IN, str.TrimEnd(), "I think Dan Brown did this to a lot of his books - build the suspense, add depth to the characters and the plot, then everything-is-resolved-quickly-in-a-few-pages-thend");
        }

        // End RJG Adding Yet More 
    }
}
