using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Expressions_8
{
    /// <summary>
    /// Generic mapper class
    /// </summary>
    public class Mapper
    {
        /// <summary>
        /// Mapping uchun generic funksiya Expressions yordamida
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <returns></returns>
        public static Func<TSource, TDestination> CreateMapFunction<TSource, TDestination>()
            where TDestination : new()
        {
            var sourceParameter = Expression.Parameter(typeof(TSource), "source");
            var destinationVariable = Expression.Variable(typeof(TDestination), "destination");

            var assignments = typeof(TDestination)
                .GetProperties()
                .Select(destinationProp =>
                {
                    var sourceProp = typeof(TSource).GetProperty(destinationProp.Name);
                    if (sourceProp != null && sourceProp.CanRead && destinationProp.CanWrite && sourceProp.PropertyType == destinationProp.PropertyType)
                    {
                        var sourceValue = Expression.Property(sourceParameter, sourceProp);
                        var destinationProperty = Expression.Property(destinationVariable, destinationProp);
                        return Expression.Assign(destinationProperty, sourceValue);
                    }
                    return null;
                })
                .Where(assign => assign != null)
                .ToList();

            var block = Expression.Block(
                new[] { destinationVariable },
                new Expression[] { Expression.Assign(destinationVariable, Expression.New(typeof(TDestination))) }
                    .Concat(assignments)
                    .Concat(new[] { destinationVariable })
            );

            return Expression.Lambda<Func<TSource, TDestination>>(block, sourceParameter).Compile();
        }

        /// <summary>
        /// Mapping uchun generic funksiya Reflection yordamida
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TDestination MapWithReflection<TSource, TDestination>(TSource source)
            where TDestination : new()
        {
            var destination = new TDestination();

            var sourceProperties = typeof(TSource).GetProperties();
            var destinationProperties = typeof(TDestination).GetProperties();

            foreach (var sourceProp in sourceProperties)
            {
                var destinationProp = destinationProperties.FirstOrDefault(prop => prop.Name == sourceProp.Name);

                if (destinationProp != null && destinationProp.CanWrite && sourceProp.PropertyType == destinationProp.PropertyType)
                {
                    var value = sourceProp.GetValue(source);

                    destinationProp.SetValue(destination, value);
                }
            }

            return destination;
        }
    }

    //2. Expression Trees orqali Mapping

    //Ishlash Prinsipi:
    //Expression Trees yordamida kod compile-timeda yaratiladi
    //va delegate funksiyaga aylantiriladi, keyin esa bu funksiya ishlatiladi.

    //Afzalliklari:
    //Yuqori samaradorlik: Expression Trees kompilyatsiya qilingan kodni chaqiradi,
    //bu Reflection bilan solishtirganda ancha tez.
    //Compile-time xavfsizlik: Ko‘plab xatolar kod kompilyatsiya qilinishida aniqlanadi,
    //bu esa ishonchli va xavfsizroq kodga olib keladi.
    //Caching: Kompilyatsiya qilingan xaritalash funktsiyasini qayta-qayta ishlatish mumkin,
    //bu katta miqdordagi ma’lumotlarni qayta ishlashda juda samarali.

    //Kamchiliklari:
    //Murakkablik: Kodning murakkabligi ortadi, dastlabki o‘rganish va qo‘llash uchun ko‘proq vaqt talab qilinadi.
    //Moslashuvchanlik nisbatan kamroq: Reflection bilan solishtirganda run-timeda har xil sharoitlarga moslashish uchun ko‘proq kod yozish talab etiladi.


    //Qaysi biri Ma’qulroq?
    //Reflection:

    //Agar loyihada xaritalash tez-tez bajarilmasa yoki bir martalik jarayon bo‘lsa, Reflection soddaligi sababli mos bo‘ladi.
    //Bu usul moslashuvchan va tez-tez o‘zgarib turadigan obyektlar bilan ishlash uchun ideal.
    //Expression Trees:

    //Agar katta hajmdagi obyektlar xaritalansa yoki xaritalash jarayoni juda ko‘p marta takrorlansa, Expression Trees samaradorligi tufayli afzalroq bo‘ladi.
    //Bu yondashuv performance muhim bo‘lgan real-time yoki katta tizimlarda yaxshi natija beradi.
    internal class Expressions_8_Mapping
    {
        //public static void Main()
        //{
        //    Student student = new Student { Id = 1, FirstName = "John", LastName = "Doe", Age = 25, School = "Harvard" };

        //    var mapFunction = Mapper.CreateMapFunction<Student, Person>();
        //    Person person = mapFunction(student);

        //    Console.WriteLine($"Student:" +
        //        $" {person.FirstName}" +
        //        $" {person.LastName}" +
        //        $" {person.Age}"
        //        // +$" {person.School}"
        //        );
        //}
    }

    #region Test classes
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string School { get; set; }
    }
    #endregion
}
