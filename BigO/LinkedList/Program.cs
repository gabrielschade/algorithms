using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkedList
{
    using System;
    using System.Text;

    // you can also use other imports, for example:
    // using System.Collections.Generic;

    // you can write to stdout for debugging purposes, e.g.
    // Console.WriteLine("this is a debug message");

    public class Photo
    {
        public string City { get; set; }
        public string FileName { get; set; }
        public string RawDateTime { get; set; }
        public DateTime DateTime { get; set; }
        public int Order { get; set; }
        public string FinalName { get; set; }

        public string GetFileExtension()
        {
            string s = this.FileName;
            int index = -1;
            index = Math.Max(s.LastIndexOf(".png"), s.LastIndexOf(".jp"));

            return s.Substring(index, s.Length - index);
        }
    }

    class Solution2
    {

        public string SafeGetProperty(string[] raw, int index)
        {
            if (index >= raw.Length) return string.Empty;
            return index == 0 ? raw[index] : raw[index].Substring(1,raw[index].Length-1);
        }

        //HashMap Creation to group each photo per city
        public Dictionary<string, List<Photo>> CreateDictionary(string S)
        {
            int order = 0;
            Dictionary<string, List<Photo>> map = new Dictionary<string, List<Photo>>();
            foreach (string line in S.Split('\n'))
            {
                string[] rawProperties = line.Split(',');
                Photo photo = new Photo();
                photo.Order = order;
                photo.FileName = SafeGetProperty(rawProperties, 0);
                photo.City = SafeGetProperty(rawProperties, 1);
                photo.RawDateTime = SafeGetProperty(rawProperties, 2);
                DateTime dt;
                DateTime.TryParse(photo.RawDateTime, out dt);
                photo.DateTime = dt;
                order++;

                if (!map.ContainsKey(photo.City))
                {
                    map[photo.City] = new List<Photo>();
                }
                map[photo.City].Add(photo);
            }

            return map;
        }

        public string solution(string S)
        {
            Dictionary<string, List<Photo>> map =
                CreateDictionary(S);

            List<Photo> results = new List<Photo>();
            foreach (string key in map.Keys)
            {
                List<Photo> photos = map[key];
                photos = photos.OrderBy(photo => photo.DateTime).ToList();
                int order = 1;
                int digits = photos.Count.ToString().Length;
                foreach (Photo photo in photos)
                {
                    string city = photo.City;
                    string extension = photo.GetFileExtension();
                    string textOrder = order.ToString();
                    while (textOrder.Length < digits)
                    {
                        textOrder = "0" + textOrder;
                    }
                    photo.FinalName = string.Concat(city, textOrder, extension);
                    results.Add(photo);
                    order++;
                }
            }

            results = results.OrderBy(photo => photo.Order).ToList();
            StringBuilder result = new StringBuilder();
            foreach (var photo in results)
            {
                result.AppendLine(photo.FinalName);
            }

            return result.ToString();
        }
    }







    public class Solution
    {

        public IList<IList<int>> Subsets(int[] nums)
        {
            List<List<int>> results = new List<List<int>>();
            results.Add(new List<int>());
            for (int index = 0; index < nums.Length; index++)
            {
                for (int innerIndex = results.Count - 1; innerIndex >= 0; innerIndex--)
                {
                    var newList = results[innerIndex].Select(e => e).ToList();
                    newList.Add(nums[index]);
                    results.Add(newList);
                }
            }
            
            return (IList < IList<int> > ) results.Select(l => l as IList<int>);
        }
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int[] result = new int[k];
            for (int index = 0; index < nums.Length; index++)
            {
                if (map.ContainsKey(nums[index]))
                {
                    map[nums[index]] = map[nums[index]] + 1;
                }
                else
                {
                    map.Add(nums[index], 1);
                }
            }

            SortedList<int, int> list = new SortedList<int, int>();
            foreach (int key in map.Keys)
            {
                list.Add(key, map[key]);
            }

            for (int i = 0; i < k; i++)
                result[i] = list.Keys[i];

            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Solution2 a = new Solution2();
            a.solution("photo.jpg, Warsaw, 2013-09-05 14:08:15\njohn.png, London, 2015-06-20 15:13:22\nmyFriends.png, Warsaw, 2013-09-05 14:07:13\nEiffel.jpg, Paris, 2015-07-23 08:03:02\npisatower.jpg, Paris, 2015-07-22 23:59:59\nBOB.jpg, London, 2015-08-05 00:02:03\nnotredame.png, Paris, 2015-09-01 12:00:00\nme.jpg, Warsaw, 2013-09-06 15:40:22\na.png, Warsaw, 2016-02-13 13:33:50\nb.jpg, Warsaw, 2016-01-02 15:12:22\nc.jpg, Warsaw, 2016-01-02 14:34:30\nd.jpg, Warsaw, 2016-01-02 15:15:01\ne.png, Warsaw, 2016-01-02 09:49:09\nf.png, Warsaw, 2016-01-02 10:55:32\ng.jpg, Warsaw, 2016-02-29 22:13:11");
            
            Console.WriteLine();
            Console.ReadKey();
        }

        public static bool LoopDetection<T>(LinkedList<T> list)
        {
            Dictionary<T, LinkedListNode<T>> map = new Dictionary<T, LinkedListNode<T>>();
            var node = list.First;
            while (node == null)
            {
                if (map.ContainsKey(node.Value) && map[node.Value].Equals(node))
                {
                    return true;
                }

                node = node.Next;
            }

            return false;
        }

        public static bool LoopDetection2<T>(LinkedList<T> list)
        {
            var node = list.First;
            var fastNode = list.First;
            while (node != null && fastNode != null)
            {
                if (node.Equals(fastNode))
                {
                    return true;
                }

                node = node.Next;
                fastNode = fastNode.Next?.Next;
            }

            return false;
        }

        public static LinkedListNode<T> Intersect<T>(LinkedList<T> first, LinkedList<T> second)
        {
            Dictionary<T, LinkedListNode<T>> map = new Dictionary<T, LinkedListNode<T>>();
            LinkedListNode<T> node = first.First;
            while (node != null)
            {
                map.Add(node.Value, node);
                node = node.Next;
            }

            node = second.First;
            while (node != null)
            {
                if (map.ContainsKey(node.Value) && map[node.Value].Equals(node))
                {
                    return node;
                }
            }

            return null;
        }

        public static (LinkedListNode<int>, bool) PalindromeR(LinkedListNode<int> node, int length)
        {
            if (length == 0) return (node, true);
            else if (length == 1) return (node.Next, true);

            var (nodeToCompare, result) = PalindromeR(node.Next, length - 2);
            result = result &= nodeToCompare.Value == node.Value;
            return (nodeToCompare.Next, result);
        }

        public static bool Palindrome(LinkedList<int> list)
        {
            if (list.Count <= 1) return true;
            Stack<int> stack = new Stack<int>();
            var current = list.First;
            int index = 0;

            while (current != null)
            {
                if (index < list.Count / 2)
                    stack.Push(current.Value);
                else if (index > list.Count / 2 || (index == list.Count / 2 && list.Count % 2 == 0))
                {
                    int value = stack.Pop();
                    if (value != current.Value)
                        return false;
                }


                current = current.Next;
                index++;
            }

            return true;


        }

        public static void SumLists(LinkedList<int> first, LinkedList<int> second)
        {
            int rest = 0;
            LinkedListNode<int> currentFirst = first.First;
            LinkedListNode<int> currentSecond = second.First;
            while (currentFirst != null)
            {
                currentFirst.Value += currentSecond.Value + rest;
                rest = currentFirst.Value / 10;
                currentFirst.Value = currentFirst.Value % 10;
                currentFirst = currentFirst.Next;
                currentSecond = currentSecond.Next;
            }

            if (rest > 0)
            {
                first.AddLast(rest);
            }
        }

        public static void PartitionList(LinkedList<int> list, int partition)
        {
            LinkedListNode<int> smaller = list.First;
            LinkedListNode<int> bigger = list.Last;
            int sindex = 0;
            int bindex = list.Count - 1;
            int aux;
            while (sindex < bindex)
            {
                if (smaller.Value >= partition)
                {
                    if (bigger.Value < partition)
                    {
                        aux = smaller.Value;
                        smaller.Value = bigger.Value;
                        bigger.Value = aux;

                        smaller = smaller.Next;
                        bigger = bigger.Previous;
                        sindex++;
                        bindex--;
                    }
                    else
                    {
                        bindex--;
                        bigger = bigger.Previous;
                    }
                }
                else
                {
                    if (bigger.Value >= partition)
                    {
                        smaller = smaller.Next;
                        bigger = bigger.Previous;
                        sindex++;
                        bindex--;
                    }
                    else
                    {
                        smaller = smaller.Next;
                        sindex++;
                    }
                }
            }
        }

        public static void DeleteNode<T>(LinkedListNode<T> node)
        {
            var current = node;
            current.Value = current.Next.Value;
            //current.Next = current.Next.Next;
        }

        public static LinkedListNode<T> FindKthLast<T>(LinkedList<T> list, int kLast)
        {
            if (kLast > list.Count) return null;

            int index = 0;
            LinkedListNode<T> current = list.First;
            LinkedListNode<T> foundedNode = null;

            while (current != null && foundedNode == null)
            {
                if (list.Count - kLast == index)
                {
                    foundedNode = current;
                }

                current = current.Next;
                index++;
            }

            return foundedNode;
        }

        public static LinkedListNode<T> FindKthLastPointers<T>(LinkedList<T> list, int kLast)
        {
            LinkedListNode<T> current = list.First;
            LinkedListNode<T> advancedPointer = current;
            int extraPositions = kLast - 1;
            while (extraPositions > 0)
            {
                advancedPointer = advancedPointer.Next;
                extraPositions--;
            }

            while (advancedPointer.Next != null)
            {
                advancedPointer = advancedPointer.Next;
                current = current.Next;
            }

            return current;
        }

        public static LinkedListNode<T> FindKthLastRecursive<T>(LinkedListNode<T> current, int size, int kLast, int index)
        {
            if (current == null) return null;

            if (size - kLast == index)
            {
                return current;
            }
            else
            {
                return FindKthLastRecursive(current.Next, size, kLast, index + 1);
            }
        }

        public static void RemoveDupplicates(LinkedList<int> list)
        {
            Dictionary<int, bool> map = new Dictionary<int, bool>();
            LinkedListNode<int> current = list.First;
            while (current != null)
            {
                var next = current.Next;
                if (map.ContainsKey(current.Value))
                {
                    list.Remove(current);
                    //current.Previous.Next = current.Next;
                    //if (current.Next != null)
                    //    current.Next.Previous = current.Previous;
                }
                else
                {
                    map.Add(current.Value, true);
                }
                current = next;
            }
        }
    }
}
