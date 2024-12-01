using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Expressions_2
{
    internal class Expressions_2
    {
        //public static void Main() 
        //{
        //    //Bu mavzuda biz Binary va Unary operatorlar bilan ishlashni o‘rganamiz.Binary operatorlar ikkita operand(masalan, +, -, *, /) bilan ishlaydi, Unary operatorlar esa bitta operand bilan(masalan, !, -).

        //    //📝 Reja:
        //    //Binary Operatorlar bilan ishlash

        //    //Arifmetik operatorlar(+, -, *, /)
        //    //Taqqoslash operatorlari(>, <, ==, !=)
        //    //Mantiqiy operatorlar(&&, ||)
        //    //Unary Operatorlar bilan ishlash

        //    //Salbiy(Negation) operator (-x)
        //    //Not(!x)
        //    //++x yoki --x kabi inkrement/dekrement operatorlar(Expression Trees uchun qo‘llanilmaydi, lekin boshqa usullar orqali ifodalanadi)




        //    #region Hometask
        //    //1
        //    //Ifoda: -(x + y) ifodasini yaratish va natijani hisoblash.

        //    //Input: x = 6, y = 4
        //    //Expected Output: -(6 + 4) = -10

        //    /*
        //    var x = Expression.Parameter(typeof(int), "x");
        //    var y = Expression.Parameter(typeof(int), "y");
        //    var add = Expression.Add(x, y);
        //    var neg = Expression.Negate(add);
        //    var lambda = Expression.Lambda<Func<int, int, int>>(neg, x, y);

        //    var compiled = lambda.Compile();

        //    Console.WriteLine(compiled(6, 4));
        //    */



        //    //2
        //    //Ifoda: (x != y) && (x > 0) ifodasini yaratish va natijani hisoblash.

        //    //Input: x = 5, y = 3
        //    //Expected Output: (5 != 3) && (5 > 0) = true

        //    var x = Expression.Parameter(typeof(int), "x");
        //    var y = Expression.Parameter(typeof(int), "y");
        //    var tengEmas = Expression.NotEqual(x, y);
        //    var katta = Expression.GreaterThan(x, Expression.Constant(0));
        //    var va = Expression.AndAlso(tengEmas, katta);
        //    var lambda = Expression.Lambda<Func<int, int, bool>>(va, x, y);
        //    var compiled = lambda.Compile();
        //    Console.WriteLine(compiled(5, 3));



        //    #endregion
        //}
    }
}
