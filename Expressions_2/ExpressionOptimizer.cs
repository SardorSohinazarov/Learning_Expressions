using System;
using System.Linq.Expressions;

public class ExpressionOptimizer : ExpressionVisitor
{
    protected override Expression VisitBinary(BinaryExpression node)
    {
        // Chap va o'ng qismlarni optimallashtirish
        var left = Visit(node.Left);
        var right = Visit(node.Right);

        // Takrorlanayotgan shartlarni olib tashlash
        if (left is ConstantExpression leftConst && right is ConstantExpression rightConst)
        {
            // Agar ikkala qism ham bo'sh yoki teng bo'lsa, optimallashtirilgan holda
            bool leftValue = Convert.ToBoolean(leftConst.Value);
            bool rightValue = Convert.ToBoolean(rightConst.Value);

            return Expression.Constant(leftValue && rightValue);
        }

        // AND (&&) yoki OR (||) bilan takroriy shartlarni chiqarib tashlash
        if (node.NodeType == ExpressionType.AndAlso && left == right)
        {
            return left; // Takrorlanadigan qismni olib tashlash
        }

        return Expression.MakeBinary(node.NodeType, left, right);
    }

    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        // MethodCallExpression uchun, masalan, Contains optimallashtirish
        if (node.Method.Name == "Contains" && node.Object != null && node.Arguments.Count == 1)
        {
            var memberExp = (MemberExpression)node.Object;
            var argument = (ConstantExpression)node.Arguments[0];

            // Agar izlanayotgan qiymat bo'sh bo'lsa, shartni olib tashlash
            if (argument.Value is string searchString && string.IsNullOrWhiteSpace(searchString))
            {
                return Expression.Constant(true);
            }
        }

        return base.VisitMethodCall(node);
    }
}