using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmu_1labaratorinis
{
    class Program
    {
        static Random random;

        static void Main(string[] args)
        {
           // SelectionSortFile naujas = new SelectionSortFile();
            //naujas.BeginFiles();
           // HeapSortFile naujas2 = new HeapSortFile();
           // naujas2.BeginFilesHeap();
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
            random = new Random(seed);
            RBtree(100);
            RBtree(200);
            RBtree(400);
            RBtree(800);
            RBtree(1600);
            RBtree(3200);
            RBtree(6400);
            // Console.ReadKey();
            // SelectionSortCompare();
            // Console.ReadKey();
            // HeapSortCompare();
            // MyDataArray array = new MyDataArray(15);
            // SelectionSortArray(array);
            //array.Print(15);
            //Console.WriteLine();
            //HeapSortArray(array);
            //array.Print(15);
            //MyDataList list = new MyDataList(15);
            //list.PrintList();
            //Console.WriteLine();
            //HeapSortList(list);
            //list.PrintList();

            Console.ReadKey();
        }
        // rikiuojamasis masyvas nuolat mazinamas po -1. rastas maziausias skaicius priskiriamas prie naujo masyvos sorted.
        // priskyrus maziausia skaiciu naujam masyvui, jis yra pasalinamas(sukeiciamas su paskutiniaja vieta tikrinamajame masyve).
        public static void HeapSortArray(MyDataArray array)
        {
            int i, j;
            double[] sorted = new double[array.length];
            for (i = array.length , j = 0; i > 0; i--, j++)
            {
                minHeapArray(array, i);
                sorted[j] = array[0];
                array.Swap(0, i - 1);
            }
            //for (i = 0; i < array.length; i++)
            //    Console.WriteLine(sorted[i]);
            //Console.ReadKey();
        }
        // sukuriamas medis, kiekviena saka turi po du narius. 
        // tikrinama ar tevine reiksme yra mazesne uz vaiko reiksme, jei taip, sukeiciamos. 
        // tevu tevas tampa maziausia reiksme. 
        public static void minHeapArray(MyDataArray array, int size)
        {
            int i, left, right, tmp;

            for (i = size / 2; i >= 0; i--)
            {


                //tevinis mazgas = i
                //tuomet vaikas is kaires = 2i
                //vaikas is desines = 2i+1
                tmp = i;
                left = (2 * i);
                right = (2 * i) + 1;
                // jei vaikas kaireje mazesnis uz teva -> vaiko indeksas tampa tevo indeksu
                if (left < size && array[left] < array[tmp])
                {
                    tmp = left;
                }

                // jei vaikas desineje mazesnis uz teva -> vaiko desineje indeksas tampa tevo indeksiu
                if (right < size && array[right] < array[tmp])
                {
                    tmp = right;
                }
                // jeigu buvo rastas mazesnis vaikas uz teva, jie yra apkeiciami
                if (tmp != i)
                {
                    array.Swap(i, tmp);
                }
            }
        }
        public static void MaxHeapifyList(DataList items, int n, int i)
        {
            int largest = i;   //Initialize largest as root
            int l = 2 * i + 1; //left = 2 * i + 1
            int r = 2 * i + 2; //right = 2 * i + 1

            //if left child is larger than root
            if (l < n && items[l] > items[largest])
            {
                largest = l;
            }

            //if right child is larger than largest so far
            if (r < n && items[r] > items[largest])
            {
                largest = r;
            }

            //if largest is not root
            if (largest != i)
            {
                Swap(items, i, largest);
                //Recursively heapify the affected sub-tree
                MaxHeapifyList(items, n, largest);
            }
        }

        public static void BuildMaxHeapList(DataList items)
        {
            int n = items.Length;
            //one by one checking all root nodes
            //and calling Heapify function
            //if they do not satisfy heap property
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                MaxHeapifyList(items, n, i);
            }
        }

        public static void HeapSortList(DataList starting)
        {
            DataList items = starting;
            int n = items.Length;

            BuildMaxHeapList(items);
            //One by one extract an element from heap
            //and get the sorted array
            for (int i = n - 1; i > 0; i--)
            {
                //Move top root element to end element
                Swap(items, 0, i);
                //n = n - 1;
                //call max heapify on the reduced heap
                MaxHeapifyList(starting, i, 0);
            }
        }

        private static void Swap(DataList items, int i, int j)
        {
            double temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }
        public static void HeapSortCompare()
        {
            int size = 6400;
            //Console.WriteLine("HeapSort Sort");
            Stopwatch sw = new Stopwatch();
            var array = new MyDataArray(size);
            sw.Start();
            HeapSortArray(array);
            sw.Stop();
            var dataArrayTime = sw.Elapsed;
            sw.Reset();
            Console.WriteLine("Analysis Heap sort");
            Console.WriteLine("ARRAY");
            Console.WriteLine("N            Run time ");
            Console.WriteLine("{0,-13}{1,10}", size, dataArrayTime);
            
                var array2 = new MyDataList(size);
                sw.Start();
                HeapSortList(array2);
                sw.Stop();
                var dataListTime = sw.Elapsed;
                sw.Reset();
            Console.WriteLine("Analysis Heap sort");
            Console.WriteLine("LIST");
            Console.WriteLine("N            Run time ");
            Console.WriteLine("{0,-13}{1,10}", size, dataListTime);


           // Console.WriteLine("Heap sort sorting 5000 elements in DataArray: " + dataArrayTime);

        }
        public static void SelectionSortCompare()
        {
            int size = 6400;
            Console.WriteLine("Selection Sort");
            Stopwatch sw = new Stopwatch();
            var array = new MyDataArray(size);
            sw.Start();
            SelectionSortArray(array);
            sw.Stop();
            var dataarrayTime = sw.Elapsed;
            sw.Reset();

            var list = new MyDataList(size);
            sw.Start();
            list.selectionSort();
            sw.Stop();
            var dataListTime = sw.Elapsed;
            Console.WriteLine("Analysis Selection sort");
            Console.WriteLine("LIST");
            Console.WriteLine("N            Run time ");
            Console.WriteLine("{0,-13}{1,10}", size, dataListTime);
           // Console.WriteLine("Selection sort sorting 5000 elements in DataArray: " + dataarrayTime);
            //Console.WriteLine("Selection sort sorting 5000 elements in ListArray: " + dataListTime);
        }
        public static void SelectionSortArray(MyDataArray array)
        {

            for (int i = 0; i < array.length - 1; i++)
            {
                int min = i;
                for (int j = i; j < array.length; j++)
                    if (array[min] < array[j])
                        min = j;

                array.Swap(i, min);
            }

        }
        public static void RBtree(int size)
        {

            string[] students = new string[size];
            Console.WriteLine("RBtree Sort");
            RedBlackTree tree = new RedBlackTree();
            for (int i = 0; i < size; i++)
            {
                string name = RandomName(10);
                tree.Insert(name);
                students[i] = name;

            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < size; i++)
                tree.Search(students[i]);
            sw.Stop();
            var dataarrayTime = sw.Elapsed;
            sw.Reset();
            Console.WriteLine("RBtree finding each name of {0}  in RBTree: {1} ", size,  dataarrayTime);

            Console.ReadKey();
        }
        static string RandomName(int size)
        {

            StringBuilder builder = new StringBuilder();
            char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
            for (int i = 1; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 *random.NextDouble() + 97)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

    }
}
