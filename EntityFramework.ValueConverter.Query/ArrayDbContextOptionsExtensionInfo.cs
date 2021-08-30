using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EntityFramework.ValueConverter.Query
{
    public class ArrayDbContextOptionsExtensionInfo : DbContextOptionsExtensionInfo
    {
        public ArrayDbContextOptionsExtensionInfo(IDbContextOptionsExtension extension) : base(extension)
        {
        }

        public override bool IsDatabaseProvider { get; }

        public override string LogFragment { get; }

        public override long GetServiceProviderHashCode()
        {
            return 0;
        }

        public override void PopulateDebugInfo(IDictionary<string, string> debugInfo)
        {
        }
    }
}