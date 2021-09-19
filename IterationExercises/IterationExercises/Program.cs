using System;

namespace IterationExercises
{
    class Program
    {
        static void Countdown(int n)
        {
            for (int i = n; i > 0; i--){
                Console.Write($"{i}... ");
            }
            Console.WriteLine("Blast Off!!!");
        }
        static void timesTable(int i)
        {
            for(int j=1; j<=12; j++)
            {
                Console.WriteLine($"{j} * {i} = {j * i}");
            }
        }
        static void timesTable2(int i, int m)
        {
            for (int j = 1; j <= m; j++)
            {
                Console.WriteLine($"{j} * {i} = {j * i}");
            }
        }

        static void inputs()
        {
            /*Console.Write("Enter number to count down from: ");
            string int1Inp = Console.ReadLine();

            int int1 = int.Parse(int1Inp);
            Countdown(int1);*/

            Console.Write("Enter number to do times tables for: ");
            string int2Inp = Console.ReadLine();

            int int2 = int.Parse(int2Inp);
            timesTable(int2);

            Console.Write("Enter number to do times tables for: ");
            string int3Inp = Console.ReadLine();

            int int3 = int.Parse(int3Inp);

            Console.Write("Enter number of times tables for that number: ");
            string int4Inp = Console.ReadLine();

            int int4 = int.Parse(int4Inp);

            timesTable(int2);
        }
        static void Main(string[] args)
        {
            inputs();
        }
    }
}
