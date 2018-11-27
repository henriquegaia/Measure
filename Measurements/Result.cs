using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Benchmark
{
    public class Result
    {
        public DateTime CreatedAt { get; }
        public string TestName { get; }
        public double Average { get; }
        public double Minimum { get; }
        public double Maximum { get; }
        public IDictionary<int, double> Repetitions { get; }

        public Result(DateTime createdAt, string testName, double average, double minimum, double maximum, IDictionary<int, double> repetitions)
        {
            CreatedAt = createdAt;
            TestName = testName;
            Average = average;
            Minimum = minimum;
            Maximum = maximum;
            Repetitions = repetitions;
        }
    }
}
