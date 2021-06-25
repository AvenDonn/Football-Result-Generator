using System;
using System.Linq;
using System.Security.Cryptography;

namespace Football
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            var options = Enumerable.Repeat(0, 10)
                .Concat(Enumerable.Repeat(1, 8))
                .Concat(Enumerable.Repeat(2, 6))
                .Concat(Enumerable.Repeat(3, 5))
                .Concat(Enumerable.Repeat(4, 4))
                .Concat(Enumerable.Repeat(5, 2))
                .OrderBy(_ => rand.Next())
                .ToArray();
            int GetResult() => options[RandomNumberGenerator.GetInt32(0, options.Length)];

            var distribution = Enumerable.Range(0, 6)
                .ToDictionary(x => x, _ => 0);

            for (var i = 0; i < 1000000; i++)
            {
                distribution[GetResult()]++;
            }

            var totalResults = (double)distribution.Sum(x => x.Value);
            Console.WriteLine(string.Join(", ", distribution.Select(x=> $"{x.Key}: {x.Value} ({(x.Value / totalResults)* 100:0.00}%)")));

            string line;


            while ((line = Console.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                Console.WriteLine(GetResult());

            }
        }
    }
}
