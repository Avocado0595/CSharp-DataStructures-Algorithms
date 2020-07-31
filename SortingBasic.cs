using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Console02
{
    class Program
    {
        public static void swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a=b;
            b=temp;
        }
        public static int BubbleSort(List<int> list)
        {
            int count =0;
            for (int i=0; i<list.Count; i++)
            {
                for (int j=i; j<list.Count; j++)
                {
                    if (list[i] > list[j])
                        {
                            var temp = list[i];
                            list[i]=list[j];
                            list[j]=temp;
                            count+=1;
                        }
                }
            }
            return count;
        }

        public static int SelectionSort(List<int> list)
        {
            int count =0;
            for (int i=0; i<list.Count; i++)
            {
                int index = i;
                for (int j=i+1; j<list.Count; j++)
                {
                    if (list[index] > list[j])
                        {
                            index = j;
                            count+=1;
                        }
                }
                var temp = list[i];
                list[i]=list[index];
                list[index]=temp;
            }
            return count;
        }

        public static int InsertSort(List<int> list)
        {
            int ins, temp, count=0;
            
            for (int i=1; i<list.Count; i++)
            {
                ins =i;
                temp = list[ins];
                while (ins >0 && list[ins-1] > temp)
                {
                    list[ins] = list[ins-1];
                    count++;
                    ins--;
                }
                list[ins] = temp;
                
            }
            return count;
        }

        public static void print(List<int> list)
        {
            foreach(var i in list)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Random rand = new Random();
            List<int> list = new List<int>();
            for (int i=0; i<10000; i++)
            {
                list.Add(rand.Next(100));
            }
            List<int> list2 = new List<int>();
            List<int> list3 = new List<int>();
            list2.AddRange(list);
            list3.AddRange(list);
            
           // print(list);
           Console.WriteLine(InsertSort(list));
           Console.WriteLine(BubbleSort(list2));
           Console.WriteLine(SelectionSort(list3));



        }
    }
}
