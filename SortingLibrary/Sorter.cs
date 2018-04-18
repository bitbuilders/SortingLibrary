using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingLibrary
{
    public class Sorter<T> where T : IComparable
    {
        public static void BubbleSort(T[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                for (int j = 0; j < array.Length - 1; ++j)
                {
                    if (array[j + 1].CompareTo(array[j]) < 0)
                    {
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        public static void SelectionSort(T[] array)
        {
            for (int i = 0; i < array.Length - 1; ++i)
            {
                T min = array[i];
                int index = i;
                for (int j = i + 1; j < array.Length; ++j)
                {
                    if (array[j].CompareTo(min) <= 0)
                    {
                        min = array[j];
                        index = j;
                    }
                }
                T temp = array[i];
                array[i] = min;
                array[index] = temp;
            }
        }

        public static void InsertionSort(T[] array)
        {
            for (int i = 1; i < array.Length; ++i)
            {
                for (int j = i; j >= 1; --j)
                {
                    if (array[j].CompareTo(array[j - 1]) <= 0)
                    {
                        T temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public static void MergeSort(T[] array)
        {
            if (array.Length > 1)
            {
                T[] first = CopyArrayIntoHalf(array, 0, array.Length / 2);
                T[] second = CopyArrayIntoHalf(array, array.Length / 2, array.Length);
                MergeSort(first);
                MergeSort(second);
                Merge(first, second, array);
            }
        }

        public static T[] CopyArrayIntoHalf(T[] array, int startIndex, int endIndex)
        {
            int numOfElements = (endIndex - startIndex);
            T[] newArray = new T[numOfElements];

            for (int i = startIndex; i < endIndex; ++i)
            {
                newArray[i - startIndex] = array[i];
            }

            return newArray;
        }

        public static void Merge(T[] firstHalf, T[] secondHalf, T[] array)
        {
            PrintArray(array);
            Console.Write("  [");
            PrintArray(firstHalf);
            Console.Write("|");
            PrintArray(secondHalf);
            Console.Write("]  ");
            Console.Write("  ---->  ");

            int first = 0;
            int second = 0;
            int index = 0;
            while (first < firstHalf.Length && second < secondHalf.Length)
            {
                //Console.Write($"Comparing {firstHalf[first]} and {secondHalf[second]}...   ");
                if (firstHalf[first].CompareTo(secondHalf[second]) <= 0)
                {
                    //Console.WriteLine($"{firstHalf[first]} won!");
                    array[index] = firstHalf[first];
                    ++first;
                }
                else
                {
                    //Console.WriteLine($"{secondHalf[second]} won!");
                    array[index] = secondHalf[second];
                    ++second;
                }
                ++index;
            }
            if (first == firstHalf.Length)
            {
                for (int i = index; i < array.Length; ++i)
                {
                    array[i] = secondHalf[second];
                    ++second;
                }
            }
            else
            {
                for (int i = index; i < array.Length; ++i)
                {
                    array[i] = firstHalf[first];
                    ++first;
                }
            }

            PrintArray(array);
            Console.WriteLine();
        }

        public static void QuickSort(T[] array)
        {

        }

        public static void PrintArray(IEnumerable<T> array)
        {
            foreach (T t in array)
            {
                Console.Write(t + ", ");
            }
        }
    }
}
