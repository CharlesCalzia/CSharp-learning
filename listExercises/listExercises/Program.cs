using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace listExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int> { 1, 3, 2, -1, 3, -1, -4, -5};
            List<int> numsEqual = new List<int> { 2, -1, 3, -4, -5, -5, 1 };
            List<int> negatives = new List<int> { -1, -1, -4, -5 };
            List<int> binarySearchList1 = new List<int> { -1, 0, 2, 6, 7, 8 };
            List<int> binarySearchList2 = new List<int> { 0, 2, 6, 7, 8 };
            List<int> primes1 = new List<int> { 2, 3, 5, 7 };
            List<int> primes2 = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47};

            Debug.Assert(Sum(nums) == -2);
            Debug.Assert(Sum(negatives) == -11);

            Debug.Assert(Max(nums) == 3);
            Debug.Assert(Max(negatives) == -1);

            Debug.Assert(Min(nums) == -5);
            Debug.Assert(Min(binarySearchList2) == 0);

            Debug.Assert(listEqual(Negative(nums), negatives)==true);
            Debug.Assert(listEqual(Negative(negatives), negatives) == true);
            Debug.Assert(listEqual(nums, numsEqual) == true);
            Debug.Assert(listEqual(nums, negatives) == false);

            Debug.Assert(basicSearch(3, nums) == true);
            Debug.Assert(basicSearch(17, nums) == false);

            Debug.Assert(binarySearch(-1, binarySearchList1) == true);
            Debug.Assert(binarySearch(5, binarySearchList1) == false);
            Debug.Assert(binarySearch(2, binarySearchList2) == true);

            Debug.Assert(sumTo(nums, negatives, -10)==true);
            Debug.Assert(sumTo(nums, negatives, -12) == false);

            

            var start = DateTime.Now;
            fastPrimeGenerator(10000);
            TimeSpan delta = DateTime.Now - start;
            Double ms = delta.TotalMilliseconds;
            Console.WriteLine($"{ms}ms");

            // Results (for non sieve algorithm) when ran the fastPrimeGenerator algorithm (on my laptop):
            // 10,000 in 14ms
            // 100,000 in 27ms
            // 1,000,000 in 238ms
            // 10,000,000 in 5342ms
            // 100,000,000 in 72358ms
        }
        static int Sum(List <int> list)
        {
            int sum = 0;
            foreach (int i in list)
                sum += i;
            return sum;
        }
        static int Max(List <int> list)
        {
            int max = list[0];
            foreach (int i in list)
                if (i > max)
                {
                    max = i;
                }
            return max;
        }
        static int Min(List <int> list)
        {
            int min = list[0];
            foreach (int i in list)
                if (i < min)
                {
                    min = i;
                }
            return min;
        }
        static List<int> Negative(List <int> list)
        {
            List<int> negativeNums = new List<int>();
            foreach (int i in list)
            {
                if (i < 0)
                {
                    negativeNums.Add(i);
                }
            }
            return negativeNums;
        }
        static bool listEqual(List <int> list1, List <int> list2)
        {
            foreach (int i in list1)
            {
                if(!list2.Contains(i)){
                    return false;
                }
            }
            foreach (int i in list2)
            {
                if (!list1.Contains(i))
                {
                    return false;
                }
            }
            return true;
        }
        static bool basicSearch(int term, List<int> list)
        {
            foreach (int i in list)
            {
                if (term == i)
                {
                    return true;
                }
            }
            return false;
        }
        static bool binarySearch(int term, List<int> list)
        {            
            int len = list.Count;
            List<int> returnList;

            if (len == 1) return list[0] == term;

            bool even = len % 2 == 0;
            int midTermInd = len / 2;
            int midTerm = list[midTermInd];

            if (term > midTerm)
            {             
                returnList = new List<int> (list.Skip((int)midTermInd));
            }
            else if (term == midTerm) return true;
            else
            {
                returnList = new List<int> (list.Take((int)midTermInd));
            }
            
            return binarySearch(term, returnList);
        }

        static bool sumTo(List<int> list1, List<int> list2, int target)
        // Works on O(n) time (where n is the length of the shortest list), since it only iterates through the shortest list
        // Worst case: must iterate through the entire shortest list (of list1 and list2)
        // Best case: the first item in the shortest list sums to the target
        // Average case: will run in n/2 time, as on average, it will have to iterate through half the shortest list
        // Doubling the size of both lists will only increase the time taken by double (and storage by double since the inputs take up double the space)
        // Will work very well on smaller processors, as this uses very little memory aside from the inputs and i (iterates through each number in the list)
        // This program is incredibly efficient in both memory usage and speedΩ
        {
            if (list1.Count > list2.Count){
                foreach (int i in list2)
                {
                    if (list2.Contains(target - i))
                    {
                        return true;
                    }
                }
            }
            else
            {
                foreach (int i in list1)
                {
                    if (list2.Contains(target - i))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static List<int> sievePrimes(int n)
        // Uses sieve of Eratosthenes (https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes), a very efficient algorithm for generating primes up to n
        // Runs in O(n log n) time
        // Worst case: low numbers of n will have a higher distribution of primes, meaning that it will take slightly longer relative to the size of n
        // Best case: n is a large number where all the large numbers are already removed
        // This algorithm will have a difficult time running on small processors when n is very large, as it requires a long list of numbers up to n
        // This algorithm is also pretty computationally intensive (for large values of n) as there are many numbers to divide by
        {
            List<int> nums = Enumerable.Range(2, n-1).ToList();
            int currentInd = 0;
            int current;
            int count = n - 1;
            while (currentInd < count)
            {
                current = nums[currentInd];

                while (true)
                {
                    bool breakFor = false;
                    for (int i = currentInd+1; i < count; i++)
                    {
                        if (nums[i] % current == 0)
                        {
                            nums.RemoveAt(i);
                            breakFor = true;
                            count--;
                            break;
                        }
                    }
                    if (!breakFor) break;
                }
                currentInd += 1;
            }
            return nums;
        }

        static List<int> fastPrimeGenerator(int n)
        {
            List<int> primes = new List<int>() { 2, 3 };
            
            for(int num=5; num<=n; num += 2)
            {
                int maxNum =(int)Math.Sqrt((double)num);
                bool isPrime = true;
                foreach (int i in primes)
                {
                    if (i > maxNum)
                    {
                        break;
                    }
                    if (num%i==0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(num);
                }

            }
            return primes;
        }

    }
}
