using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Expressions_7
{
    /// <summary>
    /// 
    /// </summary>
    internal class Expressions_7_Cache
    {
        private static readonly ConcurrentDictionary<string, Func<Person, bool>> cachedExpressions = new ConcurrentDictionary<string, Func<Person, bool>>();

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

        //public static void Main()
        //{
        //    string expressionCacheKey = "AgeGreaterThan18";
        //    Func<Person, bool> compiledExpression = GetOrCreate(expressionCacheKey);
        //    Func<Person, bool> compiledExpression2 = GetOrCreate(expressionCacheKey);

        //    var person = new Person { FirstName = "Ali", LastName = "Zoirov", Age = 20 };
        //    bool isAdult = compiledExpression(person);

        //    Console.WriteLine($"{person.FirstName} katta yoshli: {isAdult}");
        //}

        private static Func<Person, bool> GetOrCreate(string expressionCacheKey)
        {
            return cachedExpressions.GetOrAdd(expressionCacheKey, key =>
            {
                var parametr = Expression.Parameter(typeof(Person), "p");

                var ageProperty = Expression.Property(parametr, "Age");
                var eighteen = Expression.Constant(18);

                var greaterThan = Expression.GreaterThan(ageProperty, eighteen);

                var lambda = Expression.Lambda<Func<Person, bool>>(greaterThan, parametr);
                return lambda.Compile();
            });
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
