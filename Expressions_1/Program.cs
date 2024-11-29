using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Expressions_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Learning
            // 📚 Expressionlarni o'rganamiz | GPT bilan
            // Expressionlar C# kodini ifodalash uchun ishlatiladigan obyektlar

            // Constant Expressions
            /*
            Expression constantIntExpression = Expression.Constant(5);
            Console.WriteLine(constantIntExpression.NodeType);
            Console.WriteLine(constantIntExpression.Type);
            Console.WriteLine(constantIntExpression.ToString());

            Expression constantStringExpression = Expression.Constant("Sardor");
            Console.WriteLine(constantStringExpression.NodeType);
            Console.WriteLine(constantStringExpression.Type);
            Console.WriteLine(constantStringExpression.ToString());
            */

            // Parameter Expressions
            /*
            Expression parametrIntExpression = Expression.Parameter(typeof(int), "x");
            Console.WriteLine(parametrIntExpression.NodeType);
            Console.WriteLine(parametrIntExpression.Type);
            Console.WriteLine(parametrIntExpression.ToString());

            Expression parametrStringExpression = Expression.Parameter(typeof(string), "name");
            Console.WriteLine(parametrStringExpression.NodeType);
            Console.WriteLine(parametrStringExpression.Type);
            Console.WriteLine(parametrStringExpression.ToString());
            */

            // Binary Expressions
            /*
            Expression left = Expression.Constant(1);
            Expression right = Expression.Constant(2);
            Expression addExpression = Expression.Add(left, right);

            Console.WriteLine(addExpression);
            Console.WriteLine(addExpression.Type);
            Console.WriteLine(addExpression.ToString());
            */

            // 🔄 Compile qilish
            // Expressionlarni ishlatish uchun Compile qilish kerak
            /*
            ParameterExpression param = Expression.Parameter(typeof(int), "x");
            Expression body = Expression.Add(param, Expression.Constant(1));
            Expression<Func<int, int>> lambda = Expression.Lambda<Func<int, int>>(body, param);
            Console.WriteLine(lambda);
            var compiledExpression = lambda.Compile();
            Console.WriteLine(compiledExpression(5));
            */
            #endregion

            #region HomeTask
            /// 📚 Mashqlar
            /// ✍️ Mashq 1: O‘zingizning birinchi ifodangizni yarating
            //Quyidagi ifodani yarating va uni kompilyatsiya qilib, bajaring:

            //Parametrlarni(x, y, z) yarating.
            //x* y uchun Multiply ifodasini yarating.
            //x* y va z ni qo‘shish uchun Add ifodasini yarating.
            //Kompilyatsiya qilib, natijani hisoblang.

            // 1 Code
            /*
            ParameterExpression parametrx = Expression.Parameter(typeof(int), "x");
            ParameterExpression parametry = Expression.Parameter(typeof(int), "y");
            ParameterExpression parametrz = Expression.Parameter(typeof(int), "z");

            Expression multyple = Expression.Multiply(parametrx, parametry);
            Console.WriteLine(multyple);

            Expression add = Expression.Add(multyple, parametrz);
            Console.WriteLine(add);

            var lambdaExpression = Expression.Lambda<Func<int, int, int, int>>(body: add, parametrx, parametry, parametrz);
            Func<int, int, int, int> compiledLambdaExpression = lambdaExpression.Compile();
            int result = compiledLambdaExpression(2, 3, 4);

            Console.WriteLine($"Natija: {result}");
            */



            //1️ Arifmetik ifoda
            //Ifoda: (a + b) * (c - d)

            //Qadamlar:
            //a, b, c, d parametrlarini yarating.
            //(a + b) va(c - d) uchun alohida Add va Subtract ifodalarini yarating.
            //Ularni Multiply yordamida birlashtiring va natijani hisoblang.
            //Input:
            //a = 4, b = 2, c = 8, d = 3
            //Expected Output:
            //(4 + 2) * (8 - 3) = 6 * 5 = 30
            /*
            ParameterExpression a = Expression.Parameter(typeof(int), "a");
            ParameterExpression b = Expression.Parameter(typeof(int), "b");
            ParameterExpression c = Expression.Parameter(typeof(int), "c");
            ParameterExpression d = Expression.Parameter(typeof(int), "d");

            Expression add = Expression.Add(a, b);
            Expression subtract = Expression.Subtract(c, d);
            Expression multiply = Expression.Multiply(add, subtract);
            var lambda = Expression.Lambda<Func<int, int, int, int, int>>(multiply, a, b, c, d);
            var compiledLambda = lambda.Compile();
            Console.WriteLine(compiledLambda(4, 2, 8, 3));
            */



            //2 If -else shartli ifoda
            //Ifoda: agar x > 5 bo‘lsa(x * 2), aks holda(x +3)

            //Qadamlar:
            //            x parametrini yarating.
            //            x > 5 uchun GreaterThan ifodasini yarating.
            //x * 2 va x +3 ifodalarini yarating.
            //Shartni tekshirib, Condition (ternary operator) yordamida tanlang.
            //Input:
            //            x = 4 va x = 6
            //Expected Output:

            //x = 4: 4 + 3 = 7
            //x = 6: 6 * 2 = 12
            /*
            ParameterExpression x = Expression.Parameter(typeof(int), "x");
            Expression @if = Expression.GreaterThan(x, Expression.Constant(5));
            Expression then = Expression.Multiply(x, Expression.Constant(2));
            Expression @else = Expression.Add(x, Expression.Constant(3));
            Expression ifElse = Expression.Condition(@if, then, @else);

            var lambda = Expression.Lambda<Func<int, int>>(ifElse, x);
            var compiledLambda = lambda.Compile();
            Console.WriteLine(compiledLambda(4));
            Console.WriteLine(compiledLambda(6));
            */



            //3️ Logik ifoda
            //Ifoda: (a > b) && (c < d)

            //Qadamlar:
            //            a, b, c, d parametrlarini yarating.
            //            a > b va c<d ifodalarini yarating.
            //AndAlso (va) operatori bilan birlashtiring.
            //Natijani true yoki false qaytaring.
            //Input:
            //a = 5, b = 3, c = 2, d = 6
            //Expected Output:
            //(5 > 3) && (2 < 6) = true

            /*
            ParameterExpression a = Expression.Parameter(typeof(int), "a");
            ParameterExpression b = Expression.Parameter(typeof(int), "b");
            ParameterExpression c = Expression.Parameter(typeof(int), "c");
            ParameterExpression d = Expression.Parameter(typeof(int), "d");

            Expression left = Expression.GreaterThan(a, b);
            Expression right = Expression.LessThan(c, d);
            Expression andAlso = Expression.AndAlso(left, right);
            //|| Expression.OrElse(left, right);

            var lambda = Expression.Lambda<Func<int, int, int, int, bool>>(andAlso, a, b, c, d);
            var compiledLambda = lambda.Compile();
            Console.WriteLine(compiledLambda(5, 3, 2, 6));
            */

            //4 Fibonacci sonini topish(Rekursiya bilan)
            //Ifoda: Fibonacci(n) – rekursiv holda n - chi Fibonacci sonini hisoblash.

            //Qadamlar:
            //n parametrini yarating.
            //Rekursiv holda Fibonacci(n - 1) + Fibonacci(n - 2) ifodasini yarating.
            //Natijani hisoblang.
            //Input:
            //            n = 5
            //Expected Output:
            //5 - chi Fibonacci soni: 5(0, 1, 1, 2, 3, 5)



            /*
             * Bajarish kerak
             */

            #endregion
        }
    }
}
