using System.Linq.Expressions;
using System.Text;

namespace Expressions_2
{
    /// <summary>
    /// https://chatgpt.com/share/67483c51-19c8-8005-8536-905058abb108
    /// </summary>
    public class SqlQueryBuilder<T> : ExpressionVisitor
    {
        private StringBuilder _queryBuilder = new StringBuilder();

        public string Translate(Expression<Func<T,bool>> expression)
        {
            _queryBuilder.Clear();
            var entityName = typeof(T).Name;
            _queryBuilder.Append($"SELECT * FROM {entityName} WHERE ");
            Visit(expression);
            return _queryBuilder.ToString();
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            _queryBuilder.Append("(");
            Visit(node.Left);

            _queryBuilder.Append($" {GetSqlOperator(node.NodeType)} ");

            Visit(node.Right);
            _queryBuilder.Append(")");
            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Type == typeof(string))
            {
                _queryBuilder.Append($"'{node.Value}'"); // String qiymat uchun qo‘shtirnoq qo‘shish
            }
            else
            {
                _queryBuilder.Append(node.Value); // Raqamlar yoki boshqa oddiy qiymatlar uchun
            }
            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            _queryBuilder.Append(node.Member.Name); // Model ustun nomi
            return node;
        }

        private string GetSqlOperator(ExpressionType expressionType)
        {
            return expressionType switch
            {
                ExpressionType.Equal => "=",
                ExpressionType.NotEqual => "!=",
                ExpressionType.GreaterThan => ">",
                ExpressionType.GreaterThanOrEqual => ">=",
                ExpressionType.LessThan => "<",
                ExpressionType.LessThanOrEqual => "<=",
                ExpressionType.AndAlso => "AND",
                ExpressionType.OrElse => "OR",
                _ => throw new NotSupportedException($"Operator {expressionType} not supported")
            };
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == "StartsWith")
            {
                Visit(node.Object);
                _queryBuilder.Append(" LIKE ");
                Visit(node.Arguments[0]);
                _queryBuilder.Append(" + '%'");
            }
            else if (node.Method.Name == "Contains")
            {
                Visit(node.Object);
                _queryBuilder.Append(" LIKE '%' + ");
                Visit(node.Arguments[0]);
                _queryBuilder.Append(" + '%'");
            }
            else if (node.Method.Name == "EndsWith")
            {
                Visit(node.Object);
                _queryBuilder.Append(" LIKE '%' + ");
                Visit(node.Arguments[0]);
            }
            else
            {
                throw new NotSupportedException($"Method {node.Method.Name} is not supported");
            }

            return node;
        }
    }
}
