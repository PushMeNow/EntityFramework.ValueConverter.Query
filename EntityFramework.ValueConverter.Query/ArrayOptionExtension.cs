using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFramework.ValueConverter.Query
{
    public class ArrayOptionExtension : IDbContextOptionsExtension
    {
        public DbContextOptionsExtensionInfo Info { get; }

        public ArrayOptionExtension()
        {
            Info = new ArrayDbContextOptionsExtensionInfo(this);
        }

        public void ApplyServices(IServiceCollection services)
        {
            services.AddSingleton<IMethodCallTranslatorPlugin, ArrayTranslatorPlugin>();
        }

        public void Validate(IDbContextOptions options)
        {
        }
    }
}