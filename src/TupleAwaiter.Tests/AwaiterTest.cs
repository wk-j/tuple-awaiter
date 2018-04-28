using System;
using Xunit;
using TupleAwaiter;
using System.Threading.Tasks;

namespace TupleAwaiter.Tests {
    public class AwaiterTest {

        Task<T> P<T>(T data) {
            return Task.FromResult(data);
        }

        [Fact]
        public async void AwaitForTuple() {
            var (a, b, c) = await (P(1), P("A"), P(true));
            Assert.Equal(1, a);
            Assert.Equal("A", b);
            Assert.Equal(true, c);
        }
    }
}
