using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Algoritmu_1labaratorinis
{
    class MyFileArray : DataArray
    {
        public static double [] data;
        public MyFileArray(string filename, int n, int seed)
        {
            data = new double[n];
            length = n;
            Random rand = new Random(seed);
            for (int i = 0; i < length; i++)
            {
                data[i] = rand.NextDouble();
            }
            if (File.Exists(filename)) File.Delete(filename);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename,
               FileMode.Create)))
                {
                    for (int j = 0; j < length; j++)
                        writer.Write(data[j]);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public FileStream fs { get; set; }
        public override double this[int index]
        {
            set
            {
                Byte[] data = BitConverter.GetBytes(value);
                fs.Seek(8 * index, SeekOrigin.Begin);
                fs.Write(data, 0, 8);
            }
            get
            {
                Byte[] data = new Byte[8];
                fs.Seek(8 * index, SeekOrigin.Begin);
                fs.Read(data, 0, 8);
                double result = BitConverter.ToDouble(data, 0);
                return result;
            }
        }

        public override void Swap(int i, int j)
        {
            double temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
    }

}
