using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IteratorPattern
{
    internal class Program
    {
        static void Main()
        {
            var people = new People();
            people.AddPerson(new Person {Name = "Ismael", Age = 11});
            people.AddPerson(new Person {Name = "Zakaria", Age = 33});
            people.AddPerson(new Person {Name = "Abdel", Age = 27});

            foreach (Person person in people)
            {
                Console.WriteLine($"Hi i'm {person.Name} and i'm {person.Age}");
            }
            Console.Read();
        }
    }


    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }

    public class People : IEnumerable
    {
        private readonly List<Person> _collection = new List<Person>();

        public void AddPerson(Person person)
        {
            _collection.Add(person);
        }

        public IEnumerator GetEnumerator()
        {
            return new PeopleIterator(_collection);
        }
    }

    public class PeopleIterator : IEnumerator
    {
        private readonly List<Person> _collection;
        private int _position;

        public PeopleIterator(List<Person> collection)
        {
            _collection = collection;
        }

        public bool MoveNext()
        {
            _position++;
            return _position <= _collection.Count();
        }

        public void Reset()
        {
            _position = 0;
        }
        public object? Current => _collection[_position-1];
    }
}
