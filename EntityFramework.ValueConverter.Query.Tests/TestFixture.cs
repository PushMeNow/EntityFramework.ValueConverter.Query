using System;
using EntityFramework.ValueConverter.Query.Tests.Entities;

namespace EntityFramework.ValueConverter.Query.Tests
{
    public class TestFixture : IDisposable
    {
        public TestFixture()
        {
            Context = new TestContext();

            InitDatabase();
        }


        public TestContext Context { get; set; }

        public void InitDatabase()
        {
            Context.TestEntities.Add(new TestEntity
                                     {
                                         Values = new[]
                                                  {
                                                      "1",
                                                      "2",
                                                      "3"
                                                  }
                                     });
            Context.SaveChanges();
        }
        
        public void Dispose()
        {
            // if (!_disposed)
            // {
            //     _disposed = true;
            //     
            //     Context.TestEntities.RemoveRange(Context.TestEntities.ToArray());
            //     Context.SaveChanges();
            // }
            
            Context.Dispose();
        }
    }
}