using System;
using System.Collections.Generic;
using System.Linq;

namespace BigO.CSharp
{
    class Program
    {
        static bool IsEvenAt(int[] array, int index)
        => array[index] % 2 == 0;

        static bool ContainsValue(int[] array, int value)
        {
            foreach (int number in array)
            {
                if (number == value)
                    return true;
            }

            return false;
        }

        static bool ContainsDuplicatedValues(int[] array)
        {
            for(int index = 0; index < array.Length; index++)
            {
                for(int innerIndex = 0; innerIndex < array.Length; innerIndex++)
                {
                    if (index != innerIndex
                       && array[index] == array[innerIndex])
                        return true;
                }
            }
            return false;
        }

        static bool BinarySearch(int[] array, int number)
        {
            int first = 0;
            int last = array.Length - 1;
            int index = 0;
            while(first <= last)
            {
                index = (first + last) / 2;
                if (number > array[index])
                    first = index + 1;
                else if (number < array[index])
                    last = index - 1;
                else
                    return true;
            }
            return false;
        }

        static int Exponential(int number)
            => number <= 1 ? number
                           : Exponential(number - 1) + Exponential(number - 1);

        static void Main(string[] args)
        {
            int[] array = Enumerable.Range(1, 100).ToArray();
            BinarySearch(array,100);
        }
    }
}
