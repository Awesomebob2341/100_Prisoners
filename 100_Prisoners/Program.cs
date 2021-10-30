using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _100_Prisoners
{
    class Program
    {
        static bool RandomPlay()
        {
            int[] cupboards = RandArr();


        }

        //static bool OptimizedPlay()
        //{
        //    int[] cupboards = RandArr();
        //}

        static int[] RandArr()
        {
            Random rng = new Random();
            int[] cupboards = new int[100];

            for (int i = 0; i < cupboards.Length; i++)
            {
                cupboards[i] = i + 1;
            }

            for (int i = cupboards.Length-1; i > 0; i--)
            {
                int j = rng.Next(0, i + 1);
                int temp = cupboards[i];
                cupboards[i] = cupboards[j];
                cupboards[j] = temp;
            }
            return cupboards;
        }

        static void Main(string[] args)
        {

        }
    }
}
