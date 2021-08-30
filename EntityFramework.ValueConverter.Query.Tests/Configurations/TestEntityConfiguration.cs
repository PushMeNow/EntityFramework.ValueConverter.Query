using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EntityFramework.ValueConverter.Query.Tests.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFramework.ValueConverter.Query.Tests.Configurations
{
    public class TestEntityConfiguration : IEntityTypeConfiguration<TestEntity>
    {
        public void Configure(EntityTypeBuilder<TestEntity> builder)
        {
            builder.HasKey(q => q.Id);

            builder.Property(q => q.Values)
                   .HasConversion(new ArrayValueConverter<string>());
        }
    }

    public class ArrayValueConverter<T> : ValueConverter<T[], string>
    {
        public ArrayValueConverter(string separator = ",", ConverterMappingHints mappingHints = null)
            : base(q => ConvertTo(q, separator),
                   q => ConvertFrom(q, separator),
                   mappingHints)
        {
        }

        private static string ConvertTo(IReadOnlyCollection<T> values, string separator) =>
            values == null || values.Count == 0 ? null : string.Join(separator, values);

        private static T[] ConvertFrom(string values, string separator) =>
            string.IsNullOrWhiteSpace(values)
                ? Array.Empty<T>()
                : values.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                        .Select(w => (T)Convert.ChangeType(w, typeof(T)))
                        .ToArray();
    }
}