using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Tests
{
    public abstract class Test
    {
        int Repetitions { get => 5; set => Repetitions = value; }
        int Iterations { get; set; }
    }
}
