using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Algoritmu_1labaratorinis
{
    class SelectionSortFile
    {
        public SelectionSortFile()
        {
        }
        public void BeginFiles()
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;            Test_File_Array_List(seed);
        }
        public static void Test_File_Array_List(int seed)
        {
            int n = 100;
            string filename;
            filename = @"mydataarray.dat";
            MyFileArray myfilearray = new MyFileArray(filename, n, seed);
            using (myfilearray.fs = new FileStream(filename, FileMode.Open,
           FileAccess.ReadWrite))
            {
                Console.WriteLine("\n FILE ARRAY \n");
                //myfilearray.Print(n);
                Stopwatch sw = new Stopwatch();
                sw.Start();
                SelectionSortArray(myfilearray);
                sw.Stop();
                var dataarrayTime = sw.Elapsed;
                sw.Reset();
                Console.WriteLine("Analysis Selection sort FILE");
                Console.WriteLine("ARRAY");
                Console.WriteLine("N            Run time ");
                Console.WriteLine("{0,-13}{1,10}", n, dataarrayTime);
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
                SelectionSortList(myfilelist);
                sw.Stop();
                var dataListTime = sw.Elapsed;
                sw.Reset();
                Console.WriteLine("Analysis Selection sort FILE");
                Console.WriteLine("LIST");
                Console.WriteLine("N            Run time ");
                Console.WriteLine("{0,-13}{1,10}", n, dataListTime);
                // myfilelist.Print(n);
            }
        }
        public static void SelectionSortList(DataList items)
        {
            double prevdata, currentdata;
            for (int i = items.Length - 1; i >= 0; i--)
            {
                currentdata = items.Head();
                for (int j = 1; j <= i; j++)
                {
                    prevdata = currentdata;
                    currentdata = items.Next();
                    if (prevdata > currentdata)
                    {
                        items.Swap(currentdata, prevdata);
                        currentdata = prevdata;
                    }

                }
            }
        }
        public static void SelectionSortArray(DataArray array)
        {
            
                for (int i = 0; i < array.length - 1; i++)
                {
                    int min = i;
                    for (int j = i; j < array.length; j++)
                        if (array[min] < array[j])
                            min = j;

                apkeitimas(array, i, min);
                }
            
        }        public static void apkeitimas(DataArray array, int i, int min)
        {
            double temp = array[i];
            array[i] = array[min];
            array[min] = temp;
        }
        public static void SelectionSortListt(DataList items)
        {
            double prevdata, currentdata;
            for (int i = items.Length - 1; i >= 0; i--)
            {
                currentdata = items.Head();
                for (int j = 1; j <= i; j++)
                {
                    prevdata = currentdata;
                    currentdata = items.Next();
                    if (prevdata > currentdata)
                    {
                        currentdata = prevdata;
                    }
                    items.Swap(currentdata, prevdata);
                }
            }
        }
    }
}
