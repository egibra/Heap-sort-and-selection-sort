using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Algoritmu_1labaratorinis.MyDataArray;

namespace Algoritmu_1labaratorinis
{
    public abstract class DataArray
    {
        public int length;
        public abstract double this[int index] { get;set; }
        public abstract void Swap(int i, int j);

        public void Print(int n)
        {
            for (int i = 0; i < n; i++)
                Console.WriteLine(this[i]);
            Console.WriteLine();
        }

    }
}
