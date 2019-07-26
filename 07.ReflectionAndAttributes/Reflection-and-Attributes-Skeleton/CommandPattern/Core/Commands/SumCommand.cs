using CommandPattern.Core.Contracts;
using System.Linq;

namespace CommandPattern.Core.Commands
{
    public class SumCommand : ICommand
    {
        public string Execute(string[] args)
        {
            int[] numbers = args.Select(int.Parse).ToArray();

            long sum = numbers.Sum(n => n);

            return $"Current sum: {sum}";
        }
    }
}
