using NUnit.Framework;
using System.Collections.Generic;
using Week5Code; // <--- Make sure this matches the namespace in Recursion.cs

[TestFixture]
public class RecursionTests
{
    [Test]
    public void TestSumSquaresRecursive()
    {
        Assert.AreEqual(14, Recursion.SumSquaresRecursive(3));
        Assert.AreEqual(0, Recursion.SumSquaresRecursive(0));
    }

    [Test]
    public void TestPermutationsChoose()
    {
        var results = Recursion.PermutationsChoose("ABC", 2);
        var expected = new List<string> { "AB", "AC", "BA", "BC", "CA", "CB" };
        CollectionAssert.AreEquivalent(expected, results);
    }

    [Test]
    public void TestClimbingStairs()
    {
        var memo = new Dictionary<int, int>();
        Assert.AreEqual(4, Recursion.CountWaysToClimb(3, memo));
    }

    [Test]
    public void TestGenerateBinaryPatterns()
    {
        var results = Recursion.GenerateBinaryPatterns("1*0*");
        var expected = new List<string> { "1000", "1001", "1100", "1101" };
        CollectionAssert.AreEquivalent(expected, results);
    }
}
