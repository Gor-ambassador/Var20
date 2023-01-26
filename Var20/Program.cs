/*
а) Сортировка выбором

в) Сортировка простыми вставками

е) Быстрая сортировка 
*/

using CreateBD20.DBStructure;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace CreateBD20
{
    class Program
    {
        /// <summary>
        /// This function is made for sorting list of elements using selection sort. It measures sorting time
        /// </summary>
        /// <returns>
        /// Sorted List of Infos
        /// </returns>
        /// <param name="input">
        /// List of Infos that we want to sort
        /// </param>
        public static Info[] SelectionSort(Info[] input)
        {
            Info[] output = new Info[input.Length];

            input.CopyTo(output, 0);

            DateTime start = DateTime.Now;

            int counter = input.Length;

            for(int i = 0; i < counter; ++i)
            {
                int min = i;
                //Ставим минимум на i-тое место

                for(int j = i; j < counter; ++j)
                    if (output[j] < output[min])
                        min = j;

                Info x = output[i];
                output[i] = output[min];
                output[min] = x;
            }

            DateTime end = DateTime.Now;

            Console.WriteLine($"Select sort, {input.Length} elements, {(end - start).TotalMilliseconds} ms");

            return output;
        }

        /// <summary>
        /// This function is made for sorting list of elements using insert sort. It measures sorting time
        /// </summary>
        /// <returns>
        /// Sorted List of Infos
        /// </returns>
        /// <param name="input">
        /// List of Infos that we want to sort
        /// </param>
        public static Info[] InsertSort(Info[] input)
        {
            Info[] output = new Info[input.Length];
            input.CopyTo(output, 0);

            DateTime start = DateTime.Now;

            int counter = output.Length;

            for (int i = 1; i < counter; ++i)
            {
                for(int j = i - 1; j >= 0; --j)
                {
                    if (output[j] > output[j + 1]) //[1]>[0]     
                    {
                        Info x = output[j];
                        output[j] = output[j + 1];
                        output[j + 1] = x;
                    }
                    else break;
                }
            }

            DateTime end = DateTime.Now;

            Console.WriteLine($"Insert sort, {input.Length} elements, {(end - start).TotalMilliseconds} ms");

            return output;
        }

        /// <summary>
        /// This function is used as interface for quick sort
        /// </summary>
        /// <returns>
        /// Sorted List of Infos
        /// </returns>
        /// <param name="input">
        /// List of Infos that we want to sort
        /// </param>
        
        public static Info[] QuickSortInterface(Info[] input)
        {
            Info[] output = new Info[input.Length];
            input.CopyTo(output, 0);
            DateTime start = DateTime.Now;

            QuickSort(output, 0, output.Length - 1);

            DateTime end = DateTime.Now;

            Console.WriteLine($"Quick sort, {input.Length} elements, {(end - start).TotalMilliseconds} ms");

            return output;
        }

        /// <summary>
        /// This recursive function is made for sorting list of elements using quick sort. It measures sorting time. 
        /// </summary>
        /// <param name="input">
        /// List of Info
        /// </param>
        /// /// <param name="start">
        /// Position of sort_start
        /// </param>
        /// /// <param name="end">
        /// Position of sort_end
        /// </param>
        public static void QuickSort(Info[] input, int start, int end)
        {
            if (start == end) return;

            if (end - start == 1)
            {
                if (input[end] < input[start])
                {
                    Info x = input[start];
                    input[start] = input[end];
                    input[end] = x;
                }
                return;
            }

            int med = (start + end) / 2;

            int i = start, j = end;

            while(i < j)
            {
                while (input[i] < input[med]) ++i;
                while (input[j] > input[med]) --j;

                if (i <= j)
                {
                    Info x = input[i];
                    input[i] = input[j];
                    input[j] = x;
                    ++i;
                    --j;
                }
            }

            if(j > start) QuickSort(input, start, j);
            if(i < end) QuickSort(input, i, end);

            return;
        }

        static void Main(string[] args)
        {
            using (DataContext100 db = new DataContext100())
            {
                Info[] infos = db.Info.ToArray();
                SelectionSort(infos);
                InsertSort(infos);
                QuickSortInterface(infos);
            };

            using (var db = new DataContext1000())
            {
                Info[] infos = db.Info.ToArray();
                SelectionSort(infos);
                InsertSort(infos);
                QuickSortInterface(infos);
            };

            using (var db = new DataContext10000())
            {
                Info[] infos = db.Info.ToArray();
                SelectionSort(infos);
                InsertSort(infos);
                QuickSortInterface(infos);
            };

            using (var db = new DataContext20000())
            {
                Info[] infos = db.Info.ToArray();
                SelectionSort(infos);
                InsertSort(infos);
                QuickSortInterface(infos);
            };

            using (var db = new DataContext40000())
            {
                Info[] infos = db.Info.ToArray();
                SelectionSort(infos);
                InsertSort(infos);
                QuickSortInterface(infos);
            };

            using (var db = new DataContext60000())
            {
                Info[] infos = db.Info.ToArray();
                SelectionSort(infos);
                InsertSort(infos);
                QuickSortInterface(infos);
            };

            using (var db = new DataContext80000())
            {
                Info[] infos = db.Info.ToArray();
                SelectionSort(infos);
                InsertSort(infos);
                QuickSortInterface(infos);
            };
            
            using (var db = new DataContext100000())
            {
                Info[] infos = db.Info.ToArray();
                SelectionSort(infos);
                InsertSort(infos);
                QuickSortInterface(infos);
            };
        }
    }
}