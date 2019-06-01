using System;
using static System.Console;

namespace HeadTailsCS8
{
    class Program
    {
        static void Main() => WriteLine($"Total: {Soma(new[] { 1, 2, 3, 4, 5 })}");

        static int Soma(in ReadOnlySpan<int> ns) =>
            ns switch
            {
                //ReadOnlySpan<int>.Empty => 0, // we would love to do this but the compile can't yet understand, see https://github.com/dotnet/csharplang/issues/1431#issuecomment-497901047
                var x when x.IsEmpty => 0,
                var (head, tail) => head + Soma(tail)
            };
    }

    static class ArrayDeconstruction
    {
        public static void Deconstruct<T>(in this ReadOnlySpan<T> x, out T head, out ReadOnlySpan<T> tail)
        {
            head = x[0];
            tail = x.Slice(1);
        }
    }
}
