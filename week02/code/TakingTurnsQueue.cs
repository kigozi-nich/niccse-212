/// <summary>
/// Circular queue where each person has a number of turns.
/// Turns <= 0 means infinite turns.
/// </summary>
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
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        // Re-add person to the back if they have turns left or infinite turns
        if (person.Turns > 1 || person.Turns <= 0)
        {
            if (person.Turns > 1)
            {
                person.Turns -= 1;
            }

            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
