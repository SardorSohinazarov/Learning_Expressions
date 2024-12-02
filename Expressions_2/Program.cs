using Expressions_2;
using System.Linq.Expressions;

Expression<Func<Person, bool>> expression = p => (p.Age > 18 && p.Age < 70) && p.Name.Contains("Ali");

var optimizedExpression = new ExpressionOptimizer().Visit(expression);
expression = (Expression<Func<Person, bool>>)optimizedExpression;
var queryBuilder = new SqlQueryBuilder<Person>();
string sqlQuery = queryBuilder.Translate(expression);

Console.WriteLine(sqlQuery);
//SELECT * FROM Person WHERE (((Age > 18) AND (Age <= 70)) AND Name LIKE '%' + 'Ali' + '%')

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
