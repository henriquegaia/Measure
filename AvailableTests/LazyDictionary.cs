using Library.Benchmark;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Tests
{
    public class LazyDictionary : IRunnable
    {
        public string FriendlyName => "Dictionary Storage - Lazy Vs Not Lazy";

        public void Compare()
        {
            int reps = 5;

            var res = GenerateResults();

            Execution.Measure("not lazy", reps, () =>
            {
                StorageNotLazy storageNotLazy = new StorageNotLazy();
                res = storageNotLazy.Results;
            });

            Lazy<Dictionary<long, long>> res2 = new Lazy<Dictionary<long, long>>(() => GenerateResults());
            Execution.Measure("lazy", reps, () =>
            {
                StorageLazy storageLazy = new StorageLazy();
                res2 = storageLazy.Results;
            });
        }

        public static Dictionary<long, long> GenerateResults()
        {
            var ret = new Dictionary<long, long>();
            for (int i = 0; i < 1_000_000; i++)
            {
                ret[i] = i;
            }
            return ret;
        }
    }

    class StorageNotLazy
    {
        public StorageNotLazy()
        {
            GetResults();
        }

        private Dictionary<long, long> _results;

        public Dictionary<long, long> Results
        {
            get
            {
                return _results != null
                    ? _results
                    : GetResults();
            }

            set => _results = value;
        }

        private Dictionary<long, long> GetResults()
        {
            return LazyDictionary.GenerateResults();
        }
    }

    class StorageLazy
    {
        public Lazy<Dictionary<long, long>> Results { get; set; }

        public StorageLazy()
        {
            Results = new Lazy<Dictionary<long, long>>(() => GetResults());
        }

        private Dictionary<long, long> GetResults()
        {
            return LazyDictionary.GenerateResults();
        }
    }
}
