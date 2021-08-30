using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query;

namespace EntityFramework.ValueConverter.Query
{
    public class ArrayTranslatorPlugin : IMethodCallTranslatorPlugin
    {
        public IEnumerable<IMethodCallTranslator> Translators { get; }

        public ArrayTranslatorPlugin()
        {
            Translators = new[]
                          {
                              new ArrayTranslator()
                          };
        }
    }
}