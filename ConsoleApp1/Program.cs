using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            IEnumerable<int> ienumerable = GenerateIEnumerable();
            Console.WriteLine("");
            Console.WriteLine("IEnumerable has been created");

            ienumerable = FindElements(ienumerable);
            List<int> list = ienumerable.ToList();

            Console.WriteLine("");
            Console.WriteLine($"Count: {list.Count}");

            Console.WriteLine("");
            Console.WriteLine($"Any: {list.Any()}");

            Console.ReadKey();
        }

        static IEnumerable<T> FindElements<T>(IEnumerable<T> source)
        {
            foreach (T value in source)
            {
                Console.WriteLine($"The value {value} has been found.");
                yield return value;
            }
        }

        static IEnumerable<int> GenerateIEnumerable()
        {
            for (int index = 0; index < 10; index++)
            {
                Console.WriteLine($"The value {index} has been added.");
                yield return index;
            }
        }

        static List<int> GenerateList()
        {
            List<int> list = new List<int>();
            for (int index = 0; index < 10; index++)
            {
                Console.WriteLine($"The value {index} has been added.");
                list.Add(index);
            }

            return list;
        }

        int Count<T>(IEnumerable<T> source)
        {
            int count = 0;
            using (IEnumerator<T> enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    count++;
                }
            }

            return count;
        }

    }
}
