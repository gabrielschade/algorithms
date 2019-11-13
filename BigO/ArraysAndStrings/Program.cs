using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArraysAndStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[,] matrix = { { 1, 2, 0 }, { 4, 5, 6 }, { 7, 8, 9 } };
            //matrix = ZeroMatrix(matrix);
            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        Console.Write(matrix[i, j] + " " );
            //    }
            //    Console.WriteLine();
            //}
            Console.WriteLine(
                StringRotation("waterbottle", "erbottlewat")
        );

            Console.ReadKey();
        }

        public static bool StringRotation(string s1, string s2)
        {
            int foundIndex = -1;
            string rotate;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] == s2[0])
                {
                    foundIndex = i;
                    break;
                }
            }

            rotate = String.Concat(s1.Substring(foundIndex, s1.Length - foundIndex), s1.Substring(0, foundIndex));
            return rotate == s2;
        }

        public static int[,] ZeroMatrix(int[,] matrix)
        {
            bool[] rows = new bool[matrix.GetLength(0)];
            bool[] columns = new bool[matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == 0)
                    {
                        rows[i] = true;
                        columns[j] = true;
                    }
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (rows[i] || columns[j])
                    {
                        matrix[i,j] = 0;
                    }
                }
            }

            return matrix;
        }

        public static int[,] RotateMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = i; j < matrix.GetLength(1); j++)
                {
                    int aux = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = aux;
                }
            }

            return matrix;
        }

        static string StringCompression(string sample)
        {
            if (sample == null || sample.Length <= 1) return sample;

            StringBuilder builder = new StringBuilder();
            string compressed;
            char currentChar = sample[0];
            int count = 1;
            for (int i = 1; i < sample.Length; i++)
            {
                if (currentChar == sample[i])
                {
                    count++;
                }
                else
                {
                    builder.Append(currentChar.ToString());
                    builder.Append(count);
                    count = 1;
                    currentChar = sample[i];
                }
            }
            builder.Append(currentChar.ToString());
            builder.Append(count);
            compressed = builder.ToString();
            return compressed.Length < sample.Length
               ? compressed
               : sample;
        }

        public static bool OneModified(string before, string after)
        {
            int diffLength = after.Length - before.Length;
            string longest, smallest;

            if (diffLength > 1 || diffLength < -1) return false;

            if (diffLength == 1)
            {
                longest = after;
                smallest = before;
            }
            else
            {
                longest = before;
                smallest = after;
            }

            int count = 0;
            int j = 0;
            for (int i = 0; i < longest.Length; i++)
            {
                if (longest[i] == smallest[j])
                {
                    j++;
                }
                else
                {
                    count++;
                    if (diffLength == 0) j++;
                }

                if (count > 1) return false;
            }
            return true;
        }

        static bool PermutationPalindrome(string s)
        {
            char[] text = s.ToLower().ToCharArray();
            int odds = text.Length % 2;
            Dictionary<char, int> map = new Dictionary<char, int>();
            for(int i=0; i< text.Length; i++)
            {
                if (map.ContainsKey(text[i]))
                {
                    map[text[i]] = map[text[i]]+1;
                }
                else
                {
                    map.Add(text[i], 1);
                }
            }

            for(int i = 0; i < text.Length; i++)
            {
                int count = map[text[i]];
                if(count % 2 == 1)
                    odds--;

                if (odds < 0)
                    return false;
            }

            return true;
        }

        static string URLify2(char[] url, int trueLength)
        {
            int copyIndex = url.Length - 1;
            for(int index=trueLength-1; index>=0; index--)
            {
                if(url[index] == ' ')
                {
                    url[copyIndex] = '0';
                    url[copyIndex-1] = '2';
                    url[copyIndex - 2] = '%';
                    copyIndex -= 3;
                }
                else
                {
                    url[copyIndex] = url[index];
                    copyIndex--;
                }
            }

            return new string(url);
        }

        static string URLify(char[] url, int trueLength)
        {
            char[] newUrl = new char[url.Length];
            int index = 0;
            for(int count = 0; count < trueLength; count++)
            {
                if(url[count] == ' ')
                {
                    newUrl[index] = '%';
                    newUrl[index+1] = '2';
                    newUrl[index+2] = '0';
                    index += 3;
                }
                else
                {
                    newUrl[index] = url[count];
                    index++;
                }
            }

            return new string(newUrl);
        }

        static bool CheckPermutation(string first, string second)
        {
            if (first.Length != second.Length) return false;
            char[] firstChar = first.ToCharArray();
            char[] secondChar = second.ToCharArray();
            Array.Sort(firstChar);
            Array.Sort(secondChar);

            first = new string(firstChar);
            second = new string(secondChar);
            return first.Equals(second);
        }

        static bool IsUnique(string text)
        {
            Dictionary<char, bool> elements = new Dictionary<char, bool>();
            foreach(char charAt in text)
            {
                if (elements.ContainsKey(charAt))
                    return false;
                else
                    elements.Add(charAt, true);
            }

            return true;
        }
    }
}
