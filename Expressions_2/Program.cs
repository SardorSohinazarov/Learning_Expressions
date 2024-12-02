using Expressions_2;
using System.Linq.Expressions;

Expression<Func<Person, bool>> expression = p => (p.Age > 18 && p.Age <= 70) && p.Name.Contains("Ali");

var queryBuilder = new SqlQueryBuilder<Person>();
string sqlQuery = queryBuilder.Translate(expression);

Console.WriteLine(sqlQuery);
// Natija: SELECT * FROM People WHERE (Age > 18 AND Name = 'Ali')

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
