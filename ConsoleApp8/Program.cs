using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;

namespace ConsoleApp8
{
    internal class Program
    {
        static void showResult(int x, int y, Func<int, int, int> op)
        {
            Console.WriteLine("Result = " + op(x, y));
        }

        static void DoOperation(int a, int b, Action<int, int> op)
        {
            op(a, b);
        }

        static void Add(int x, int y)
        {
            Console.WriteLine($"{x} + {y} = {x + y}");
        }

        // delegate bool FilterInt(int x);

        static int Sum(int[] numbers, /*FilterInt*/ Predicate<int> func) // тоже самое но возвращает bool
        {
            int result = 0;
            foreach (int i in numbers) {
                if (func(i)) result += i;
            }
            return result;
        }

        public int CountChar(string str, char ch)
        {
            int count = 0;
            foreach (char c in str)
            {
                if (c == ch) count++;
            }
            return count;
        }


    static void Main(string[] args)
        {
          
            DoOperation(10, 6, Add);
            DoOperation(10, 6, (int x, int y) => Console.WriteLine($"{x} * {y} = {x * y}"));

            BankAccount ba = new BankAccount(1000000M);
            ba.Notify += SMSService.sendMessage;
            ba.Notify += AndroidService.showNotification;
            ba.Notify += delegate (string t)
            {
                Console.WriteLine($"Anonimous: {t}");
            };

            Console.WriteLine();

            ba.Notify += (string t) => Console.WriteLine($"Lambda: {t}");

            ba.WithDraw(1000);
            ba.WithDraw(1000000);
            ba.Deposit(5000);
            ba.Deposit(-5000);

            Console.WriteLine();
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int sumEvenNumbers = Sum(arr, (int x) => x % 2 == 0);
            Console.WriteLine(sumEvenNumbers);

            int sumOfOddNumbers = Sum(arr, delegate (int x)
            {
                return x % 2 != 0;
            });
            Console.WriteLine(sumOfOddNumbers);

            Console.WriteLine();

            int sumEvenNumbers2 = Sum(arr, (int x) => x % 3 == 0);
            Console.WriteLine(sumEvenNumbers2);

            int sumOfOddNumbers2 = Sum(arr, delegate (int x)
            {
                return x % 3 == 0;
            });
            Console.WriteLine(sumOfOddNumbers2);

            Console.WriteLine();

            showResult(4, 2, (int x, int y) => x + y);
            showResult(4, 2, (int x, int y) => x - y);
            showResult(4, 2, (int x, int y) => x * y);
            Console.WriteLine();

            int[] arr2 = { 1, 2, 3 };
            int sumOfSqueares = arr.Sum((int x) => x * x);
            Console.WriteLine(sumOfSqueares);
            Console.WriteLine();

            //string str = "AABACDD";
            // Console.WriteLine(CountChar(str, 'A'));

             string s = "Привет Мир!";
            int count = s.CharCount('и');
            Console.WriteLine(count);

            Console.WriteLine();

            ArrayList list = new ArrayList();
            list.Add(2.3);
            list.Add(55);

            Console.WriteLine("list.Capacity = " + list.Capacity);

            list.AddRange(new string[] { "Hello", "world", "!" });
            Console.WriteLine("list.Capacity = " + list.Capacity);

            foreach (object o in list)
            {
                Console.WriteLine(o);
            }
            Console.WriteLine();
            list.RemoveAt(0);
            list.Reverse();

            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            Console.WriteLine();
            ArrayList list2 = new ArrayList();

            list2.Add(11);
            list2.Add(5);
            list2.Add(10);
            list2.Sort();
            Console.WriteLine(list2.Contains(11));

            foreach(int x in list2)
            { Console.WriteLine(x); }

            Console.ReadKey();
        }
    }
}
