using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var numArray = new[] { 1, 5, 0, 3, 9, 4, 2, 8, 16, 22, 21, 18, 16, 7};
            char input = 't';
            while (input.Equals('q') == false)
            {
                Console.WriteLine("Press L for linear search.\nB for binary search.\nQ to quit.");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine("");
                if (input.Equals('q'))
                {
                    break;
                }
                else if (input.Equals('l'))
                {
                    Console.WriteLine("Linear Search:\n" +
                        "Enter integer to search for:");
                    try
                    {
                        int val = int.Parse(Console.ReadLine());
                        var index = BinarySearch(numArray, val);
                        Print(index);
                    }
                    catch (FormatException) { Console.WriteLine("Unepected Input. Please enter an integer"); }
                    catch (Exception ex) { Console.WriteLine("Unexpect Error: " + ex.ToString()); }
                }
                else if (input.Equals('b'))
                {
                    var cloneArray=new int [numArray.Length+1];

                    cloneArray = (int[])numArray.Clone();

                    Array.Sort(cloneArray);

                    Console.WriteLine("Binary Seach:\n" +
                        "Enter integer to search for:");
                    try {int val = int.Parse(Console.ReadLine());
                        var index = BinarySearch(cloneArray, val);
                        Print(index);
                    }
                    catch(FormatException) { Console.WriteLine("Unepected Input. Please enter an integer"); }
                    catch (Exception ex) { Console.WriteLine("Unexpect Error: " + ex.ToString()); }
                }
                else
                {
                    Console.WriteLine("Unexpected input. Please try again.\n" +
                        "Press L for linear search.\nB for binary search.\nQ to quit.");
                }
            }

        }


        private static void Print(int printable)
        {
            if (printable == -1)
            {
                Console.WriteLine("The input was not in the array.");
            }
            else
            {
                Console.WriteLine("The index for the input is "+printable);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        private static int BinarySearch(int[] array, int item)
        {
            int L = 0;
            int R = array.Length - 1;
            while (L <= R)
            {
                var mid = (L + R) / 2;
                if (array[mid] == item)
                {
                    return mid;
                }
                if (item < array[mid])
                    R = mid - 1;
                else
                    L = mid + 1;
            }
            return -1;
        }


        private static int LinearSearch(int[] array, int item)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
