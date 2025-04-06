// Benchmark project code (using BenchmarkDotNet)
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace MyApp.Benchmarks
{
    public class OrderServiceBenchmark
    {
        private readonly OrderService _orderService = new OrderService();
        private List<Order> _orders;

        public OrderServiceBenchmark()
        {
            // Set up a list of orders for benchmarking
            _orders = new List<Order>
            {
                new() { Price = 100 },
                new() { Price = 50 },
                new() { Price = 200 }
            };
        }

        [Benchmark]
        public double Benchmark_CalculateTotal()
        {
            return _orderService.CalculateTotal(_orders);
        }

        [Benchmark]
        public bool Benchmark_IsOrderValid()
        {
            return _orderService.IsOrderValid(_orders.First());
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            // Run the benchmarks
            BenchmarkRunner.Run<OrderServiceBenchmark>();
        }
    }
}
