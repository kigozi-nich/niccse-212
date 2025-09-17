using System;

namespace code;

public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
            throw new InvalidOperationException("No one in the queue.");

        var person = _people.Dequeue();

        if (person.Turns <= 0)
        {
            // Infinite turns
            _people.Enqueue(person);
        }
        else if (person.Turns > 1)
        {
            person.Turns -= 1;
            _people.Enqueue(person);
        }
        else
        {
            // Last turn, do not re-enqueue
            person.Turns = 0;
        }

        return person;
    }

    public override string ToString() => _people.ToString();
}
