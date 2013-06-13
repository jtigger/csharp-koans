# Prerequisites
- Visual Studio 2010 Professional -- using MSTest and the Ordered Test Features, only available in Professional or better.
  (see http://msdn.microsoft.com/en-us/library/dd286704(v=vs.100).aspx)


# Getting Started

In most implementations of programming koans, there is a Koan Runner.  In this implementation, we chose to write them as MSTest test methods.

If you would like to follow the "Path to Enlightenment" (i.e. address the most rudamentary koans first and gradually increase with difficulty) then you will want to run the Ordered Test named "PathToEnlightenment".  Here's how:

* Visual Studio 2008 -- http://msdn.microsoft.com/en-us/library/ms182630(v=vs.90).aspx
* Visual Studio 2010 -- http://msdn.microsoft.com/en-us/library/ms182470(v=vs.100).aspx
* Visual Studio 2012 -- http://msdn.microsoft.com/en-us/library/ms182470(v=vs.110).aspx


## Quick Start

1. In Visual Studio, open the csharp-koans.sln
2. Open the "Test" pull-down menu, mouse over "Windows" and select "Test View"
3. In the "Test View" panel, at the top, click the Refresh button (an icon of a piece of paper with green arrows pointing at each other).
4. Find the Test named "pathtoenlightenment"
5. Right-Click and select "Run Selection" this will open the "Test Results" panel and show the "pathtoenlightenment" test, having failed.
6. In the "Test Results" panel, double-click on "pathtoenlightnment".  This will bring up a Test Results; tests will be in order along the "path to enlightenment".
7. Double-click on the top-most failing test
8. Read the "Error Message" section for a hint.
9. In the "Error Stack Trace" section, click on the link into the tests.
