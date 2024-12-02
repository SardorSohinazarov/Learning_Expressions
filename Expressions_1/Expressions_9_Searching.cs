using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Expressions_9
{
    /// <summary>
    /// https://chatgpt.com/share/67483c51-19c8-8005-8536-905058abb108
    /// </summary>
    class Expressions_9_Searching
    {
        /// <summary>
        /// Dynamic search function
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        static Func<Person, bool> CreateSearch(string propertyName, object value)
        {
            ParameterExpression param = Expression.Parameter(typeof(Person), "p");

            MemberExpression property = Expression.Property(param, propertyName);

            ConstantExpression constant = Expression.Constant(value);

            /*Contains metodini ishlatishning o‘rniga IndexOf metodini ishlatishning sababi,
             * String.Contains metodining to‘g‘ridan-to‘g‘ri StringComparison.OrdinalIgnoreCase parametri yo‘qligi.
             * String.Contains metodida katta-kichik harflarni farqlamaydigan qidiruvni amalga oshirish uchun qo‘lda StringComparison.
             * OrdinalIgnoreCase qo‘shish imkoni mavjud emas. Bu metod faqat oddiy Contains qidiruvini amalga oshiradi va harflar o‘rtasida farq qiladi.
             * IndexOf metodida esa StringComparison.OrdinalIgnoreCase parametrini ishlatib, katta va kichik harflarni farqlamaydigan qidiruvni qilish mumkin.
             * Bu metod, agar kerak bo‘lsa, qidiruvning pozitsiyasini yoki topilganligini bilish imkonini beradi,
             * shu bilan birga, harflarni farqlamay qidirishni amalga oshiradi.
             * Contains metodining imkoniyatlari limitlangan, shuning uchun IndexOf ishlatiladi, chunki u katta-kichik harf farqini e'tiborsiz qidirish imkonini beradi.*/
            MethodInfo indexOfMethod = typeof(string).GetMethod("IndexOf", new[] { typeof(string), typeof(StringComparison) });
            Expression indexOfCall = Expression.Call(property, indexOfMethod, constant, Expression.Constant(StringComparison.OrdinalIgnoreCase));

            Expression greaterThanOrEqualZero = Expression.GreaterThanOrEqual(indexOfCall, Expression.Constant(0));

            var lambda = Expression.Lambda<Func<Person, bool>>(greaterThanOrEqualZero, param);

            return lambda.Compile();
        }

        static void Main()
        {
            var people = new List<Person>
            {
                new Person { Name = "Ali", Age = 22, City = "Tashkent" },
                new Person { Name = "Zarina", Age = 28, City = "Samarkand" },
                new Person { Name = "Daniyar", Age = 35, City = "Bukhara" },
                new Person { Name = "Kamola", Age = 30, City = "Tashkent" },
                new Person { Name = "Aziza", Age = 17, City = "Fergana" }
            };

            var searchResult = CreateSearch("Name", "ali");

            var searchedPeople = people.Where(searchResult).ToList();

            Console.WriteLine("Searched People:");
            foreach (var person in searchedPeople)
            {
                Console.WriteLine($"{person.Name}, {person.Age}, {person.City}");
            }
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }
}

