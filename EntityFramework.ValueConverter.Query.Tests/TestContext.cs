using System.Data.Common;
using System.Reflection;
using System.Threading.Tasks;
using EntityFramework.ValueConverter.Query.Tests.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EntityFramework.ValueConverter.Query.Tests
{
    public class TestContext : DbContext
    {
        private DbConnection _connection;

        public TestContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<TestEntity> TestEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            optionsBuilder.UseSqlite(_connection);
            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(new ArrayOptionExtension());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override void Dispose()
        {
            _connection?.Close();
            base.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await _connection.DisposeAsync();
            await base.DisposeAsync();
        }
    }
}