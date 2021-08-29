﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Delegates
{
    class Program
    {
        public delegate int StringComparer(string x, string y);

        public static void SortString(string[] array, StringComparer comparer)
        {
            for (int i = array.Length - 1; i > 0; i--)
                for (int j = 1; j <= i; j++)
                {
                    var element1 = array[j-1];
                    var element2 = array[j];
                    if (comparer(element1, element2) > 0)
                    {
                        var temp = array[j];
                        array[j] = array[j-1];
                        array[j-1] = temp;
                    }    
                }    
        }

        public static int CompareStringLength(string x, string y)
        {
            return x.Length.CompareTo(y.Length);
        }

        //class StringComparer : IComparer<string>
        //{
        //    public bool Descending { get; set; }
        //    public int Compare(string x, string y)
        //    {
        //        return x.CompareTo(y) * (Descending ? -1: 1) ;
        //    }
        //}

        public class Comparer
        {
            public bool Descending { get; set; }

            public int Compare(string x, string y)
            {
                return x.CompareTo(y) * (Descending ? -1 : 1);
            }
        }

        static void Main(string[] args)
        {
            var strings = new[] { "A", "B", "AA", "C", "BB", "FFF" };

            var lengthComparer = new StringComparer(CompareStringLength);
            SortString(strings, lengthComparer);

            var obj = new Comparer { Descending = true };
            var simpleComparer = new StringComparer(obj.Compare);
            SortString(strings, simpleComparer);

        }
    }
}
