using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace code;

[TestClass]
public class TakingTurnsQueueTests
{
    [TestMethod]
    public void TestTakingTurnsQueue_FiniteRepetition()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);

        Person[] expectedResult = { bob, tim, sue, bob, tim, sue, tim, sue, tim, tim };

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        int i = 0;
        while (players.Length > 0)
        {
            if (i >= expectedResult.Length)
                Assert.Fail("Queue should have run out of items by now.");

            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
            i++;
        }
    }

    // Other test methods can be copied from the previous test class.
}
