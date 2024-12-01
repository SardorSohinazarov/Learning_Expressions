using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Expressions_6
{
    /// <summary>
    /// https://chatgpt.com/share/67483c51-19c8-8005-8536-905058abb108
    /// </summary>
    internal class Expressions_6_Dynamic_Filters
    {
        public static List<Person> persons = new List<Person>
        {
            new Person { FirstName = "John", LastName = "Jons", Age = 25 },
            new Person { FirstName = "Jane", LastName = "Jill", Age = 12 },
            new Person { FirstName = "Jack", LastName = "Pol", Age = 30 },
            new Person { FirstName = "Jill", LastName = "Hill", Age = 15 },
            new Person { FirstName = "Sardor", LastName = "Sohinazarov", Age = 21 },
            new Person { FirstName = "Sarvar", LastName = "Sohinazarov", Age = 14 },
            new Person { FirstName = "Sanjar", LastName = "Sohinazarov", Age = 22 },
            new Person { FirstName = "Humoyun", LastName = "Isoqjonov", Age = 24 },
            new Person { FirstName = "Xudoyor", LastName = "Isoqjonov", Age = 24 },
        };

        public static void Main()
        {
            var propertyNames = new List<string> { "FirstName", "LastName"};

            var key = Console.ReadLine();

            var parametr = Expression.Parameter(typeof(Person), "p");

            var properties = propertyNames
                .Select(x => Expression.Property(parametr, x))
                .ToList();

            var conditions = properties.Select(x =>
                Expression.Equal(x, Expression.Constant(key))).ToList();

            var body = conditions.Aggregate((x, y) => Expression.OrElse(x, y));
            Console.WriteLine(body);
            var lambda = Expression.Lambda<Func<Person, bool>>(body, parametr);
            var filtered = persons.Where(lambda.Compile());

            Console.WriteLine(JsonSerializer.Serialize(filtered, options: new JsonSerializerOptions() { WriteIndented = true }));
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
