using System;
using System.Diagnostics;

namespace iterationExercises
{
    class Program
    {
        static void Countdown(int n)
        {
            for (int i = n; i > 0; i--)
            {
                Console.Write($"{i}... ");
            }
            Console.WriteLine("Blast Off!!!");
        }
        static void timesTable(int i, int m = 12)
        {
            for (int j = 1; j <= m; j++)
            {
                Console.WriteLine($"{j} * {i} = {j * i}");
            }
        }

        static double Ask(int n)
        {
            double sum = 0;
            for (int i=0; i<n; i++)
            {
                Console.Write("Enter number:\n\t>  ");
                string num = Console.ReadLine();
                double num1 = double.Parse(num);
                sum += num1;
            }
            Console.WriteLine($"The total of these numbers is {sum} and the average is {Math.Round(sum/n, 2)}");
            return sum;
        }

        static int Triangular(int n)
        {
            return (n * (n + 1)) / 2;
        }
        static int isISBN(string isbn)
        {
            int count = 0;
            int unknownInd = 0;
            for(int i=0; i<isbn.Length; i++)
            {
                char index = isbn[i];
                if (index != 'X' && index != '?')
                {
                    count += (index - '0') * (10 - i);
                }
                else if (index == '?') unknownInd = i;
                else if (index == 'X') count += 10;
            }
            for (int j=0; j<isbn.Length; j++)
            {
                if (((j * (10-unknownInd))+count) % 11 == 0)
                {
                    return j;
                }
            }
            return -1;
        }

        static ulong findLowest() //find smallest positive integer that is doubled when the last digit moves to the front
        {
            ulong number = 10;
            ulong modifiedNumber;
            while (true)
            {
                string numString = number.ToString();
                int strLen = numString.Length - 1;
                numString = numString[strLen] + numString.Substring(0,strLen);
                modifiedNumber = ulong.Parse(numString);
                if (modifiedNumber == 2 * number)
                {
                    Console.WriteLine($"{number}");
                    return number;
                }
                number += 1;
            }
        }

        static void inputs()
        {
            Console.Write("Enter number to count down from: ");
            string int1Inp = Console.ReadLine();
            int int1 = int.Parse(int1Inp);
            Countdown(int1);

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
            timesTable(int3, int4);

            Console.Write("Enter number of numbers you want to average: ");
            string int5Inp = Console.ReadLine();
            int int5 = int.Parse(int5Inp);
            Ask(int5);

            Console.WriteLine("\n--- Automatic tests ---\n");

            Console.WriteLine("Triangular: " + (Triangular(3) == 6 ? "Passed" : "Failed"));
            Console.WriteLine("Triangular: " + (Triangular(12) == 78 ? "Passed" : "Failed"));

            Console.WriteLine("ISBN: " + (isISBN("15688?111X") == 1 ? "Passed":"Failed"));
            Console.WriteLine("ISBN: " + (isISBN("020110?311") == 3 ? "Passed" : "Failed"));
        }
        static void Main(string[] args)
        {
            inputs();
        }
    }
}
