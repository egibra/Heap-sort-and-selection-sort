using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Algoritmu_1labaratorinis.MyDataList;

namespace Algoritmu_1labaratorinis
{
    abstract class DataList
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract double Head();
        public abstract double Next();
        public abstract double this [int index] { get; set; }
        public abstract void MovePointerAhead();
        public abstract bool HasPointerNext();
        public abstract bool HasNext();
        public abstract double Previous();
        public abstract bool HasPrevious();
        public abstract double PeekPrevious();
        public abstract double PeekNext();
        public abstract double Peek();
        public abstract void GoToPointer();
        public abstract void PrintList();
        public abstract void Swap();
        public abstract void Swap(double a, double b);
        public void Print(int n)
        {
            Console.WriteLine(Head());
            for (int i = 1; i < n - 1; i++)
                Console.WriteLine(Next());
            Console.WriteLine();
        }

    }
}
