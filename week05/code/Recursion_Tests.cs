using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class RecursionTests
{
    [Test]
    public void TestSumSquaresRecursive()
    {
        Assert.AreEqual(14, Recursion.SumSquaresRecursive(3)); // 1^2 + 2^2 + 3^2 = 14
        Assert.AreEqual(0, Recursion.SumSquaresRecursive(0)); // Base case
    }

    [Test]
    public void TestPermutationsChoose()
    {
        var results = Recursion.PermutationsChoose("ABC", 2);
        Assert.AreEqual(new List<string> { "AB", "AC", "BA", "BC", "CA", "CB" }, results);
    }

    [Test]
    public void TestClimbingStairs()
    {
        var remember = new Dictionary<int, int>();
        Assert.AreEqual(4, Recursion.CountWaysToClimb(3, remember)); // 1 step, 1 step, 1 step / 1 step, 2 step / 2 step, 1 step / 3 step
    }

    [Test]
    public void TestGenerateBinaryPatterns()
    {
        var results = Recursion.GenerateBinaryPatterns("1*0*");
        Assert.AreEqual(new List<string> { "1000", "1010", "1100", "1110" }, results);
    }
}
