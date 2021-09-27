using System;
using System.Collections.Generic;

namespace listExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static int Sum(List <int> list)
        {
            int sum = 0;
            foreach (int i in list)
                sum += i;
            return sum;
        }
    }
}
