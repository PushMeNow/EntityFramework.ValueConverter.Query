using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using EntityFramework.ValueConverter.Query.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace EntityFramework.ValueConverter.Query
{
    public class ArrayTranslator : IMethodCallTranslator
    {
        private static readonly MethodInfo _method = typeof(FunctionsExtensions).GetMethod(nameof(FunctionsExtensions.Contains),
                                                                                           new[]
                                                                                           {
                                                                                               typeof(DbFunctions),
                                                                                               typeof(string[]),
                                                                                               typeof(string)
                                                                                           });

        public SqlExpression Translate(SqlExpression instance,
                                       MethodInfo method,
                                       IReadOnlyList<SqlExpression> arguments,
                                       IDiagnosticsLogger<DbLoggerCategory.Query> logger)
        {
            if (method != _method)
            {
                return instance;
            }

            var prop = arguments.ElementAt(1);
            var @const = arguments.ElementAt(2) as SqlConstantExpression;

            return new LikeExpression(prop,
                                      new SqlConstantExpression(Expression.Constant($"%{@const!.Value}%"), new StringTypeMapping("nvarchar(max)")),
                                      null,
                                      RelationalTypeMapping.NullMapping);
        }
    }
}