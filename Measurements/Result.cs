using System;
using System.Collections.Generic;
using System.Text;

namespace Measurements
{
    class Result
    {
        public DateTime CreatedAt { get; }
        public string TestName { get; }
        public double Average { get; }
        public double Minimum { get; }
        public double Maximum { get; }

        public Result(string testName, double average, double minimum, double maximum)
        {
            CreatedAt = DateTime.Now;
            TestName = testName;
            Average = average;
            Minimum = minimum;
            Maximum = maximum;
        }
    }
}
