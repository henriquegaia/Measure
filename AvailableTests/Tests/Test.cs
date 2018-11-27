using Library.Benchmark;
using System.Collections.Generic;

namespace Library.Tests
{
    public class Test
    {
        protected Execution Execution { get; }
        protected IDictionary<string, Result> Results{ get; }

        public Test() => Execution = new Execution();
    }
}
