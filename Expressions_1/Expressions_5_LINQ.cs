using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;

namespace Expressions_1
{
    /// <summary>
    /// https://chatgpt.com/share/67483c51-19c8-8005-8536-905058abb108
    /// </summary>
    internal class Expressions_5_LINQ
    {
        public static List<Person> persons = new List<Person>
        {
            new Person { FirstName = "John", LastName = "Jons", Age = 25 },
            new Person { FirstName = "Jane", LastName = "Jill", Age = 12 },
            new Person { FirstName = "Jack", LastName = "Pol", Age = 30 },
            new Person { FirstName = "Jill", LastName = "Hill", Age = 15 }
        };
        public static void Main()
        {
            #region 1-usul
            //var filtered = persons.Where(p => p.Age > 18);
            //Console.WriteLine(JsonSerializer.Serialize(filtered, options: new JsonSerializerOptions() { WriteIndented = true }));
            #endregion

            #region 2-usul
            //var parametr = Expression.Parameter(typeof(Person), "p");
            //var ageProperty = Expression.Property(parametr, "Age");
            //var eighteen = Expression.Constant(18);

            //var greaterThan = Expression.GreaterThan(ageProperty, eighteen);

            //var lambda = Expression.Lambda<Func<Person, bool>>(greaterThan, parametr);

            //var filtered = persons.Where(lambda.Compile());
            //Console.WriteLine(JsonSerializer.Serialize(filtered, options: new JsonSerializerOptions() { WriteIndented = true }));
            #endregion

            #region 3-usul dynamic filter
            //var key = "Jill";
            //var propertyName = "FirstName";
            ////var propertyName = "LastName";

            //var parametr = Expression.Parameter(typeof(Person), "p");
            //var property = Expression.Property(parametr, propertyName);
            //var equal = Expression.Equal(property, Expression.Constant(key));

            //var lambda = Expression.Lambda<Func<Person, bool>>(equal, parametr);
            //var filtered = persons.Where(lambda.Compile());
            //Console.WriteLine(JsonSerializer.Serialize(filtered, options: new JsonSerializerOptions() { WriteIndented = true }));
            #endregion

            #region 4-usul bir nechta filterni qo'shish
            var key = "Jill";
            var age = 18;

            var propertyName = "FirstName";
            //var propertyName = "LastName";
            var parametr = Expression.Parameter(typeof(Person), "p");
            var propertyString = Expression.Property(parametr, propertyName);
            var propertyAge = Expression.Property(parametr, "Age");

            var equal = Expression.Equal(propertyString, Expression.Constant(key));
            var greatherThan = Expression.GreaterThan(propertyAge, Expression.Constant(age));
            var combinedFilter = Expression.AndAlso(greatherThan, equal);
            Console.WriteLine(combinedFilter);

            var lambda = Expression.Lambda<Func<Person, bool>>(combinedFilter, parametr);
            var filtered = persons.Where(lambda.Compile());
            Console.WriteLine(JsonSerializer.Serialize(filtered, options: new JsonSerializerOptions() { WriteIndented = true }));
            #endregion
        }
    }

    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}