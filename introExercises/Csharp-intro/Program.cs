using System;

namespace Csharp_intro
{
    class Program
    {
        static int task1()
        {
            float minutesInt = 0;
            float secondsInt = 0;
            while (true)
            {
                Console.Write("How many minutes? ");
                string minutes = Console.ReadLine();
                if (float.TryParse(minutes, out minutesInt) == false)
                {
                    Console.WriteLine("Not a valid number of minutes");
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                Console.Write("How many seconds? ");
                string seconds = Console.ReadLine();
                if (float.TryParse(seconds, out secondsInt) == false)
                {
                    Console.WriteLine("Not a valid number of seconds");
                }
                else
                {
                    break;
                }
            }
            float totalSeconds = secondsInt + (minutesInt * 60);
            float hours = totalSeconds / 3600;
            float metreSpeed = 10000 / totalSeconds;
            float mileSpeed = (10 / 1.6f) / hours;
            Console.WriteLine($"Your speed is {mileSpeed}mph or {Math.Round(Convert.ToDecimal(metreSpeed), 2)}m/s");
            return 0;
        }
        static void task2()
        {
            Console.Write("Enter number to show multiplication table for: ");
            string num1 = Console.ReadLine();
            int num = Convert.ToInt32(num1);

            Console.Write("Enter maximum number of time tables to do: ");
            string num2 = Console.ReadLine();
            int multiplication = Convert.ToInt32(num2);

            for (int i=0; i<=multiplication; i++)
            {
                Console.Write($"{i}   ");
            }
            Console.WriteLine();

            for (int i=0; i<=multiplication; i++)
            {
                Console.Write($"{ num* i}   ");
            }
            Console.WriteLine();
        }
        static void task3()
        {
            Console.Write("Enter which what you would like to enter: \n\tr) Radius\n\ta) Area\n\tc) Circumference\n\n > ");
            string input = Console.ReadLine();
            const double PI = Math.PI;
            if (input == "r")
            {
                
                Console.Write("Enter the radius of your circle: ");
                string radius1 = Console.ReadLine();
                double radius = double.Parse(radius1);

                double area = (PI * (radius * radius));
                double circumference = 2 * PI * radius;

                Console.WriteLine($"Your circle has an area of {Math.Round(Convert.ToDecimal(area), 2)} and a circumference of {Math.Round(Convert.ToDecimal(circumference), 2)}");

            }
            else if (input == "a")
            {
                Console.Write("Enter the area of your circle: ");
                string area1 = Console.ReadLine();
                double area = double.Parse(area1);

                double radius = Math.Sqrt(area / PI);
                double circumference = 2 * PI * radius;

                Console.WriteLine($"Your circle has a radius of {Math.Round(Convert.ToDecimal(radius), 2)} and a circumference of {Math.Round(Convert.ToDecimal(circumference), 2)}");

            }
            else if (input == "c")
            {
                Console.Write("Enter the circumference of your circle: ");
                string circum1 = Console.ReadLine();
                double circum = double.Parse(circum1);

                double radius = circum / (2 * PI);
                double area = PI * radius * radius;

                Console.WriteLine($"Your circle has a radius of {Math.Round(Convert.ToDecimal(radius), 2)} and an area of {Math.Round(Convert.ToDecimal(area), 2)}");

            }
            else
            {
                Console.WriteLine("Not a valid option");
                task3();
            }
        }

        static int olympiad1()
        {
            Console.Write("Enter password to verify: ");
            string password = Console.ReadLine();
            int pLen = password.Length;

            for (int len=1; len < pLen; len++)
            {
                for(int pointer=0; pointer<pLen-len; pointer++)
                {
                    string p1 = password.Substring(pointer, len);
                    string p2 = password.Substring(pointer + len, len);
                    Console.WriteLine($"p1: {p1}, p2: {p2}");

                    if (p1 == p2)
                    {
                        Console.WriteLine("Invalid");
                        return 0;
                    }
                }
            }
            Console.WriteLine("Valid");
            return 1;
        }

        static void olympiad2()
        {
            Console.Write("Enter Lojban string: ");
            string input = Console.ReadLine();

            input = input.Replace("1", "pa").Replace("2", "re").Replace("3", "ci").Replace("4", "vo").Replace("5", "mu").Replace("6", "xa").Replace("7", "ze").Replace("8", "bi").Replace("9", "so").Replace("0", "no");
            Console.Write(input);
        }

            static void inputs()
            {
                while (true)
                {
                    Console.Write("Enter which program you would like to run (a, b, c or q): \n\ta) Running\n\tb) Multiplication\n\tc) Circle geometry\n\tq) Quit\n\n > ");
                    string input = Console.ReadLine();
                    if (input == "a")
                    {
                        task1();
                    }
                    else if (input == "b")
                    {
                        task2();
                    }
                    else if (input == "c")
                    {
                        task3();
                    }
                    else if (input == "q")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not a valid option");
                        inputs();
                    }
                }
            }

        static int calcPi(int n)
        {
            double inCircle = 0;
            for (int i = 0; i < 100000000; i++)
            {
                Random rnd = new Random();
                double x = rnd.Next((-1 * n), n);
                double y = rnd.Next((-1 * n), n);
                

                double dist = Math.Sqrt((x * x) + (y * y));
                //Console.WriteLine($"{x},{y},{dist}");
                if (dist < Convert.ToDouble(n))
                {
                    inCircle++;
                }
            }
            Console.WriteLine((inCircle/100000000)*4);
            return 0;
        }

        static void Main(string[] args)
        {
            //inputs();
            calcPi(10000);
        }
    }
}