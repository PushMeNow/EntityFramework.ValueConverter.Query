using System;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.ValueConverter.Query.Extensions
{
    public static class FunctionsExtensions
    {
        public static bool Contains(this DbFunctions funcs, string[] array, string filter)
        {
            throw new InvalidOperationException("This method is for use with Entity Framework Core only and has no in-memory implementation.");
        }
    }
}