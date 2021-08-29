using System;
using System.Collections;
using System.Collections.Generic;

namespace Delegates
{
    class Program
    {
        public static void Sort(Array array, IComparer comparer)
        {
            for (int i = array.Length - 1; i > 0; i--)
                for (int j = 1; j <= i; j++)
                {
                    object element1 = array.GetValue(j - 1);
                    object element2 = array.GetValue(j);
                    if (comparer.Compare(element1, element2) > 0)
                    {
                        object temp = array.GetValue(j);
                        array.SetValue(array.GetValue(j - 1), j);
                        array.SetValue(temp, j - 1);
                    }    
                }    
        }

        class StringLengthComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return (x as string).Length.CompareTo((y as string).Length);
            }
        }

        class StringComparer : IComparer
        {
            public bool Descending { get; set; }
            public int Compare(object x, object y)
            {
                return (x as string).CompareTo(y as string) * (Descending ? -1: 1) ;
            }
        }

        static void Main(string[] args)
        {
            var strings = new[] { "A", "B", "AA", "C", "BB", "FFF" };
            Sort(strings, new StringComparer() { Descending = true });
            Sort(strings, new StringLengthComparer());
        }
    }
}
