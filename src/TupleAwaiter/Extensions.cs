using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TupleAwaiter {

    public static class Extension {
        public static TaskAwaiter<(T1, T2)> GetAwaiter<T1, T2>(this (Task<T1>, Task<T2>) tasks) {
            return Task
                .WhenAll(tasks.Item1, tasks.Item2)
                .ContinueWith(arr => (tasks.Item1.Result, tasks.Item2.Result))
                .GetAwaiter();
        }
        public static TaskAwaiter<(T1, T2, T3)> GetAwaiter<T1, T2, T3>(this (Task<T1>, Task<T2>, Task<T3>) tasks) {
            return Task
                .WhenAll(tasks.Item1, tasks.Item2, tasks.Item3)
                .ContinueWith(arr => (tasks.Item1.Result, tasks.Item2.Result, tasks.Item3.Result))
                .GetAwaiter();
        }
        public static TaskAwaiter<(T1, T2, T3, T4)> GetAwaiter<T1, T2, T3, T4>(this (Task<T1>, Task<T2>, Task<T3>, Task<T4>) tasks) {
            return Task
                .WhenAll(tasks.Item1, tasks.Item2, tasks.Item3, tasks.Item4)
                .ContinueWith(arr => (tasks.Item1.Result, tasks.Item2.Result, tasks.Item3.Result, tasks.Item4.Result))
                .GetAwaiter();
        }
    }
}
