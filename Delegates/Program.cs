using System;
using System.Collections;
using System.Collections.Generic;

namespace Delegates
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Func<int, int> f = x => x + 1;

            Console.WriteLine(f(1));

            Func<int> generator = () => rnd.Next();

            Console.WriteLine(generator);

            Func<double, double, double> h = (a, b) =>
                {
                    b = a % b;
                    return b % a;
                };

            Action<int> print = x => Console.WriteLine(x);

            print(generator());

            Action printRandomNumber = () => Console.WriteLine(rnd.Next());
            Action printRandomNumber1 = () => print(generator());
        }
    }
}
