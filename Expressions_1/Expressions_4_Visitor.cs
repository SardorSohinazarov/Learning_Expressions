using System;
using System.Linq.Expressions;

namespace Expressions_4
{
    /// <summary>
    /// https://chatgpt.com/share/67483c51-19c8-8005-8536-905058abb108
    /// </summary>
    //internal class Expressions_4_Visitor
    //{
    //    public static void Main()
    //    {
    //        //Expression Tree'larda Visitor Pattern (Mezon Tizimi)
    //        //ExpressionVisitor nima?
    //        //ExpressionVisitor — bu Expression Tree'ni rekursiv tarzda ko'rib chiqish(traversal)
    //        //va kerakli o'zgarishlarni amalga oshirish uchun ishlatiladigan klass.
    //        //Bu pattern sizga Expression Tree'dagi har bir tugunni(node) ko'rib chiqish
    //        //va kerak bo'lganda o'zgartirish imkonini beradi.

    //        //Masalan, sizning maqsadingiz x + y ifodasida x ni z ga almashtirish bo'lsa,
    //        //ExpressionVisitor yordamida bu o'zgarishni amalga oshirishingiz mumkin.

    //        //Qanday holatlarda ishlatiladi?
    //        //Parametrlarni almashtirish: Expression Tree ichidagi ma'lum bir parametrni boshqasiga almashtirish.
    //        //Murakkab ifodalarni soddalashtirish: Matematik ifodalarni optimallashtirish yoki soddalashtirish.
    //        //Log qo‘shish yoki izlash: Expression Tree ichidagi ma'lum bir amalni izlash
    //        //va uning atrofida qo'shimcha kod kiritish.

    //        /*
    //        var x = Expression.Parameter(typeof(int), "x");
    //        var y = Expression.Parameter(typeof(int), "y");
    //        BinaryExpression add = Expression.Add(x, y);
    //        Console.WriteLine(add);
    //        var replacedadd = new ReplaceParameterVisitor(x, y).Visit(add);
    //        Console.WriteLine(replacedadd);
    //        */


    //        /*
    //        var x = Expression.Parameter(typeof(int), "x");
    //        var add = Expression.Add(Expression.Constant(0), x);
    //        Console.WriteLine(add);
    //        var simplifiedAdd = new SimplifyExpressionVisitor().Visit(add);
    //        Console.WriteLine(simplifiedAdd);
    //        */


    //        /*
    //        var x = Expression.Parameter(typeof(int), "x");
    //        var y = Expression.Parameter(typeof(int), "y");

    //        BinaryExpression add = Expression.Add(x, y);

    //        Console.WriteLine(add);

    //        var logVisitor = new LogVisitor();
    //        var add1 = logVisitor.Visit(add);

    //        Console.WriteLine(add1);

    //        var replacedadd = new ReplaceParameterVisitor(x, y).Visit(add);
    //        var add2 = logVisitor.Visit(replacedadd);

    //        Console.WriteLine(add2);

    //        var simplifiedAdd = new SimplifyExpressionVisitor().Visit(add);
    //        var add3 = logVisitor.Visit(simplifiedAdd);

    //        Console.WriteLine(add3);

    //        var compiledAdd = Expression.Lambda<Func<int, int, int>>(add, x, y).Compile();
    //        Console.WriteLine(compiledAdd(10, 20));
    //        */
    //    }
    //}

    public class ReplaceParameterVisitor : ExpressionVisitor
    {
        private readonly ParameterExpression _oldParameter;
        private readonly ParameterExpression _newParameter;

        public ReplaceParameterVisitor(
            ParameterExpression oldParameter,
            ParameterExpression newParameter)
        {
            _oldParameter = oldParameter;
            _newParameter = newParameter;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node == _oldParameter)
            {
                Console.WriteLine($"Parametr almashtirildi: {_oldParameter.Name} -> {_newParameter.Name}");
                return _newParameter;
            }

            return base.VisitParameter(node);
        }
    }

    public class SimplifyExpressionVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType == ExpressionType.Add
                && node.Right is ConstantExpression ce
                && (int)ce.Value == 0) 
            {
                Console.WriteLine($"Soddalashtirildi: {node} => {node.Left}");
                return Visit(node.Left);
            }

            if (node.NodeType == ExpressionType.Add
                && node.Left is ConstantExpression ce2
                && (int)ce2.Value == 0)
            {
                Console.WriteLine($"Soddalashtirildi: {node} => {node.Right}");
                return Visit(node.Left);
            }

            return base.VisitBinary(node);
        }
    }

    public class LogVisitor : ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            Console.WriteLine($"Amal: {node.NodeType}, Chap: {node.Left}, O'ng: {node.Right}");
            return base.VisitBinary(node);
        }
    }
}
