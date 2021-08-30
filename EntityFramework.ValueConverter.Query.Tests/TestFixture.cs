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


        public TestContext Context { get; }

        private void InitDatabase()
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
            Context.TestEntities.Add(new TestEntity
                                     {
                                         Values = new[]
                                                  {
                                                      "2",
                                                      "2",
                                                      "3"
                                                  }
                                     });
            Context.SaveChanges();
        }
        
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}