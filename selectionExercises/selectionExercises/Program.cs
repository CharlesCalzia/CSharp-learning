using System;
using System.Linq;

namespace selectionExercises
{
    class Program
    {
        static void task1()
        {
            Console.Write("Enter first number: ");
            string int1Inp = Console.ReadLine();
            Console.Write("Enter second number: ");
            string int2Inp = Console.ReadLine();

            int int1 = int.Parse(int1Inp);
            int int2 = int.Parse(int2Inp);

            if (int1 == int2) Console.WriteLine("Those numbers are equal\n");
            else Console.WriteLine("Those numbers are not equal\n");
        }

        static void task2()
        {
            Console.Write("Enter number to check if it is even: ");
            string int1Inp = Console.ReadLine();

            int int1 = int.Parse(int1Inp);

            if (int1 %2==0) Console.WriteLine("That number is even\n");
            else Console.WriteLine("That number is odd\n");
        }

        static void task3()
        {
            Console.Write("Enter year to check if it is a leap year: ");
            string int1Inp = Console.ReadLine();

            int int1 = int.Parse(int1Inp);
            if (int1 % 400 == 0) Console.WriteLine("That year is a leap year\n");
            else if (int1 % 4 == 0 & int1 % 100 != 0) Console.WriteLine("That year is a leap year\n");
            else Console.WriteLine("That year is not a leap year\n");

        }

        static void task4()
        {
            Console.Write("Enter first number: ");
            string int1Inp = Console.ReadLine();
            Console.Write("Enter second number: ");
            string int2Inp = Console.ReadLine();
            Console.Write("Enter third number: ");
            string int3Inp = Console.ReadLine();

            int int1 = int.Parse(int1Inp);
            int int2 = int.Parse(int2Inp);
            int int3 = int.Parse(int3Inp);

            if (int1 >= int2 && int1 >= int3) Console.WriteLine("The first number is the largest\n");
            else if (int2 >= int1 && int2 >= int3) Console.WriteLine("The second number is the largest\n");
            else if (int3 >= int2 && int3 >= int1) Console.WriteLine("The third number is the largest\n");
            else Console.WriteLine("Hmm\n");
        }

        static void task5()
        {
            Console.Write("Enter x: ");
            string inpx = Console.ReadLine();
            Console.Write("Enter y: ");
            string inpy = Console.ReadLine();

            double x = double.Parse(inpx);
            double y = double.Parse(inpy);

            string quadrant;

            if (x < 0 && y > 0) quadrant = "top left";
            else if (x > 0 && y > 0) quadrant = "top right";
            else if (x < 0 && y < 0) quadrant = "bottom left";
            else quadrant="bottom right";

            Console.WriteLine($"This point is in the {quadrant} quadrant");

            Console.Write("Enter radius: ");
            string rad = Console.ReadLine();

            double radius = double.Parse(rad);

            double dist = Math.Sqrt((x * x) + (y * y));
            if (dist < radius) Console.WriteLine("X and Y are in the circle");
            else Console.WriteLine("X and Y are not in the circle");


            Console.Write("Enter circle's center's x co-ordinate: ");
            string centx = Console.ReadLine();
            Console.Write("Enter circle's center's y co-ordinate: ");
            string centy = Console.ReadLine();

            double centerx = double.Parse(inpx);
            double centery = double.Parse(inpy);

            double distCircleX = centerx - x;
            double distCircleY = centery - y;

            double distCircle = Math.Sqrt((distCircleX * distCircleX) + (distCircleY * distCircleY));

            if (distCircle < radius) Console.WriteLine("X and Y are in the circle");
            else Console.WriteLine("X and Y are not in the circle");
        }

        static void task6()
        {
            Console.Write("Enter quiz score: ");
            string quiz1 = Console.ReadLine();
            Console.Write("Enter block test score: ");
            string block1 = Console.ReadLine();
            Console.Write("Enter final test score: ");
            string final1 = Console.ReadLine();

            float quiz = float.Parse(quiz1);
            float block = float.Parse(block1);
            float final = float.Parse(final1);

            float avg = (quiz + block + final) / 3;
            if (avg >= 90) Console.WriteLine("A*\n");
            else if (avg >= 80) Console.WriteLine("A\n");
            else if (avg >= 70) Console.WriteLine("B\n");
            else if (avg >= 50) Console.WriteLine("C\n");
            else if (avg < 50) Console.WriteLine("F\n");
            else Console.WriteLine("None\n");
        }
              
        static void task7()
        {
            Console.Write("Enter triangle's first side: ");
            string side11 = Console.ReadLine();
            Console.Write("Enter triangle's second side: ");
            string side12 = Console.ReadLine();
            Console.Write("Enter triangle's third side: ");
            string side13 = Console.ReadLine();

            float side1 = float.Parse(side11);
            float side2 = float.Parse(side12);
            float side3 = float.Parse(side13);

            if (side1 == side2 && side2 == side3) Console.WriteLine("Equilateral");
            else if (side1 + side2 < side3 || side2 + side3 < side1 || side1 + side3 < side2) Console.WriteLine("Impossible");
            else if (side1 == side2 || side2 == side3 || side1 == side3) Console.WriteLine("Isosceles");
            else Console.WriteLine("Scalene");
        }

        static void inputs()
        {
            while (true)
            {
                Console.Write("Enter which program you would like to run (a, b, c, d, e, f, g or q): \n\ta) Check equal\n\tb) Even or odd\n\tc) Leap year\n\td) Greatest value\n\te) Co-ordinates\n\tf) Grades\n\tg) Triangle\n\tq) Quit\n\n > ");
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
                else if (input == "d")
                {
                    task4();
                }
                else if (input == "e")
                {
                    task5();
                }
                else if (input == "f")
                {
                    task6();
                }
                else if (input == "g")
                {
                    task7();
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

        static void Main(string[] args)
        {
            inputs();
        }
    }
}
