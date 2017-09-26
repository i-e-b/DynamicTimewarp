using System;

namespace Demo
{
    class Program
    {
        static void Main()
        {
            var seq_A = new[] { 0, 0, 0, 3, 6, 13, 25, 22, 7, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var seq_B = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 5, 12, 24, 23, 8, 3, 1, 0, 0, 0, 0, 0 };
            var seq_C = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -4, -5, -12, -24, -23, -8, -3, -1, 0, 0, 0, 0, 0 };
            var seq_D = new[] { 25, 0, -25, 0, 25, 0, -25, 0, 25, 0, -25, 0, 25, 0, -25, 0, 25, 0, -25, 0, 25, 0, -25, 0 };


            Func<int, int, int> costFunc = (a, b) => Math.Abs(Math.Abs(a) - Math.Abs(b));

            var costAA = DynamicTimewarp.Compare(seq_A, seq_A, costFunc);

            var costAB = DynamicTimewarp.Compare(seq_A, seq_B, costFunc);
            var costBC = DynamicTimewarp.Compare(seq_B, seq_C, costFunc);
            var costAC = DynamicTimewarp.Compare(seq_A, seq_C, costFunc);
            var costAD = DynamicTimewarp.Compare(seq_A, seq_D, costFunc);


            Console.WriteLine("Total cost A<->A: " + costAA);

            Console.WriteLine("Total cost  A->B: " + costAB);
            Console.WriteLine("Total cost  B->C: " + costBC);
            Console.WriteLine("Total cost  A->C: " + costAC);
            Console.WriteLine("Total cost  A->D: " + costAD);

            Console.ReadLine();
        }
    }
}
