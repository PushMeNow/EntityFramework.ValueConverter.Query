using System;

namespace EntityFramework.ValueConverter.Query.Tests.Entities
{
    public class TestEntity
    {
        public Guid Id { get; set; }

        public string[] Values { get; set; }
    }
}