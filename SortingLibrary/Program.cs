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
            int[] ints = new int[6] { 2, 1, 5, 4, 2, 8 };
            int[] ints4 = new int[10] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] ints2 = new int[5] { 1, 2, 3, 4, 5 };
            int[] ints3 = new int[5] { 1, 2, 3, 4, 5 };
            PrintArray(ints4);
            //Sorter<int>.Merge(ints2, ints3, ints4);
            Sorter<int>.MergeSort(ints4);
            Console.WriteLine();
            PrintArray(ints4);
        }

        static void PrintArray<T>(IEnumerable<T> array)
        {
            foreach (T t in array)
            {
                Console.Write(t + ", ");
            }
        }
    }
}
