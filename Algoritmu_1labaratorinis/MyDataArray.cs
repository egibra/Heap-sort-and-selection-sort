using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmu_1labaratorinis
{
    class MyDataArray : DataArray
    {
        double[] data;
        public MyDataArray(int n)
        {
            data = new double[n];
            length = n;
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                data[i] = random.Next(0, 10000);
            }
        }
        public override double this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }
        public override void Swap(int i, int j)
        {
            double temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }

    }
}
