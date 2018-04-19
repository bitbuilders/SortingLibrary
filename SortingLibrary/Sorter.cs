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
            int first = 0;
            int second = 0;
            int index = 0;
            while (first < firstHalf.Length && second < secondHalf.Length)
            {
                if (firstHalf[first].CompareTo(secondHalf[second]) <= 0)
                {
                    array[index] = firstHalf[first];
                    ++first;
                }
                else
                {
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
        }

        public static void QuickSort(T[] array)
        {
            Quick(array, 0, array.Length);
        }

        public static void Quick(T[] array, int min, int max)
        {
            int pivot = min;
            // in place
            for (int i = 0; i < max; ++i)
            {
                if (array[i].CompareTo(array[pivot]) < 0)
                {
                    for (int j = i; j >= 1; --j)
                    {
                        if (array[j].CompareTo(array[j - 1]) < 0)
                        {
                            T temp = array[j];
                            array[j] = array[j - 1];
                            array[j - 1] = temp;
                            if (j == pivot) pivot = j - 1;
                            else if (j - 1 == pivot) pivot = j;
                        }
                    }
                }
            }

            pivot++;
            if (max - pivot > 1)
            {
                Quick(array, pivot, max);
            }
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
