//TO-DO: Change namespace to file-scoped
//TO-DO: Create a Person record
//TO-DO: Make class immutable

namespace RecordsDemo
{
    public class PersonClass
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public PersonClass(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

    public record PersonRecord(string FirstName, string LastName);
}