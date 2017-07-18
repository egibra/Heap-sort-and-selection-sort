using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Algoritmu_1labaratorinis
{
    class HeapSortFile
    {
        public HeapSortFile()
        {
        }
        public void BeginFilesHeap()
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;            Test_File_Array_List(seed);
        }
        public static void Test_File_Array_List(int seed)
        {
            int n = 2000;
            string filename;
            filename = @"mydataarray.dat";
            MyFileArray myfilearray = new MyFileArray(filename, n, seed);
            using (myfilearray.fs = new FileStream(filename, FileMode.Open,
           FileAccess.ReadWrite))
            {
                Console.WriteLine("\n FILE ARRAY \n");
               // myfilearray.Print(n);
                Stopwatch sw = new Stopwatch();
                sw.Start();
                //myfilearray.Print(n);
                HeapSortArray(myfilearray);
                //myfilearray.Print(n);
                sw.Stop();
                var dataarrayTime = sw.Elapsed;
                sw.Reset();
                Console.WriteLine(" Analysis Heap sort FILE");
                Console.WriteLine(" ARRAY");
                Console.WriteLine(" N            Run time ");
                Console.WriteLine(" {0,-13}{1,10}", n, dataarrayTime);
                // myfilearray.Print(n);
               // Console.WriteLine("tiek uztruko su failais heap sort " + dataarrayTime);

            }
            filename = @"mydatalist.dat";
            MyFileList myfilelist = new MyFileList(filename, n, seed);
            using (myfilelist.fs = new FileStream(filename, FileMode.Open,
           FileAccess.ReadWrite))
            {
                Console.WriteLine("\n FILE LIST \n");
               // myfilelist.Print(n);
                Stopwatch sw = new Stopwatch();
                sw.Start();
               // myfilelist.Print(n);
                HeapSortList(myfilelist);
              //  myfilelist.Print(n);
                sw.Stop();
                var dataListTime = sw.Elapsed;
                Console.WriteLine(" Analysis Heap sort FILE");
                Console.WriteLine(" LIST");
                Console.WriteLine(" N            Run time ");
                Console.WriteLine(" {0,-13}{1,10}", n, dataListTime);
                //myfilelist.Print(n);
                //Console.WriteLine("tiek uztruko su failais list heap sort " + dataListTime);
            }
        }
        public static void HeapSortArray(DataArray array)
        {
            int i, j;
            double[] sorted = new double[array.length];
            for (i = array.length, j = 0; i > 0; i--, j++)
            {
                minHeapArray(array, i);
                sorted[j] = array[0];
                apkeitimas(array, 0, i - 1);              
            }

        }
        // sukuriamas medis, kiekviena saka turi po du narius. 
        // tikrinama ar tevine reiksme yra mazesne uz vaiko reiksme, jei taip, sukeiciamos. 
        // tevu tevas tampa maziausia reiksme. 
        public static void minHeapArray(DataArray array, int size)
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
                    apkeitimas(array, i, tmp);
                }
            }
        }
        public static void apkeitimas(DataArray array, int i, int min)
        {
            double temp = array[i];
            array[i] = array[min];
            array[min] = temp;
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
    }
}
