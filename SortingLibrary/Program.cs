using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = new int[10];
            FillArrayRandom(ints);
            //ints = new int[10] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] sorted = ints.OrderBy(x => x).ToArray();
            int[] ints4 = new int[10] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] ints2 = new int[5] { 1, 2, 3, 4, 5 };
            int[] ints3 = new int[5] { 1, 2, 3, 4, 5 };
            PrintArray(ints);
            //Sorter<int>.Merge(ints2, ints3, ints4);
            Sorter<int>.MergeSort(ints);
            Console.WriteLine();
            PrintArray(ints);
            Console.WriteLine();
            PrintArray(sorted);
            Console.WriteLine();
            Console.WriteLine(AreEqual(ints, sorted));
        }

        static void FillArrayRandom(int[] array)
        {
            Random rand = new Random();
            for (int i = 0; i < array.Count(); ++i)
            {
                array[i] = rand.Next(100001);
            }
        }

        static void PrintArray<T>(IEnumerable<T> array)
        {
            foreach (T t in array)
            {
                Console.Write(t + ", ");
            }
        }

        static bool AreEqual<T>(T[] A, T[] B) where T : IComparable
        {
            bool equal = true;

            for (int i = 0; i < A.Length; ++i)
            {
                if (A[i].CompareTo(B[i]) != 0)
                {
                    equal = false;
                    break;
                }
            }

            return equal;
        }
    }
}
