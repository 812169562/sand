using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sand.Extensions
{
        public static class FilterExtension
        {
            public static IQueryable<T> Filter<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate,
                object condition)
            {
                if (condition == null)
                    return source;
                if (condition is string)
                    if (string.IsNullOrEmpty(condition.ToString()))
                        return source;
                return source.Where(predicate);
            }

            public static Expression<Func<T, bool>> Filter<T>(this Expression<Func<T, bool>> first,
                Expression<Func<T, bool>> second, object condition)
            {
                if (condition == null)
                    return first;
                if (condition is string)
                    if (string.IsNullOrEmpty(condition.ToString()))
                        return first;
                return first.Compose(second, Expression.And);
            }

            /// <summary>
            /// 过滤查询表达式
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="first"></param>
            /// <param name="second"></param>
            /// <returns></returns>
            public static Expression<Func<T, bool>> Filter<T>(this Expression<Func<T, bool>> first,
                Expression<Func<T, bool>> second)
            {
                if (second == null)
                    return first;
                var value = GetValue(second);
                if (value == null)
                    return first;
                if (value is string && string.IsNullOrEmpty(value.ToString()))
                    return first;
                return first.Compose(second, Expression.And);
            }

            /// <summary>
            /// 表达式右边的值
            /// </summary>
            /// <param name="expression">表达式</param>
            /// <returns></returns>
            public static object GetValue(Expression expression)
            {
                if (expression == null)
                    return null;
                switch (expression.NodeType)
                {
                    case ExpressionType.Lambda:
                        return GetValue(((LambdaExpression)expression).Body);
                    case ExpressionType.Convert:
                        return GetValue(((UnaryExpression)expression).Operand);
                    case ExpressionType.Equal:
                    case ExpressionType.NotEqual:
                    case ExpressionType.GreaterThan:
                    case ExpressionType.LessThan:
                    case ExpressionType.GreaterThanOrEqual:
                    case ExpressionType.LessThanOrEqual:
                        return GetValue(((BinaryExpression)expression).Right);
                    case ExpressionType.Call:
                        return GetValue(((MethodCallExpression)expression).Arguments.FirstOrDefault());
                    case ExpressionType.MemberAccess:
                        return GetMemberValue((MemberExpression)expression);
                    case ExpressionType.Constant:
                        return GetConstantExpressionValue(expression);
                }
                return null;
            }

            private static object GetMemberValue(MemberExpression expression)
            {
                if (expression == null)
                    return null;
                var field = expression.Member as FieldInfo;
                if (field != null)
                {
                    var constValue = GetConstantExpressionValue(expression.Expression);
                    return field.GetValue(constValue);
                }
                var property = expression.Member as PropertyInfo;
                if (property == null)
                    return null;
                var value = GetMemberValue(expression.Expression as MemberExpression);
                return property.GetValue(value, null);
            }

            private static object GetConstantExpressionValue(Expression expression)
            {
                var constantExpression = (ConstantExpression)expression;
                return constantExpression.Value;
            }
        }
    }
