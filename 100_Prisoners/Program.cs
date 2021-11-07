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
            List<Prisoner> pass = new List<Prisoner>();
            List<Prisoner> prisoners = CreatePrisoners();

            int[] cupboards = RandArr();
            Random rand = new Random();
            
            for (int i = 0; i < prisoners.Count; i++)
            {
                for (int j = 0; j < 50; i++)
                {
                    int cupboard = rand.Next(cupboards.Length);
                    
                    if (!prisoners[i].AlreadyChecked(cupboard))
                    {
                        if (cupboards[j] == prisoners[i].id)
                        {
                            pass.Add(prisoners[i]);
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        //static bool OptimizedPlay()
        //{
        //    int[] cupboards = RandArr();
        //}

        static List<Prisoner> CreatePrisoners()
        {
            List<Prisoner> prisoners = new List<Prisoner>();

            for (int i = 0; i < 100; i++)
            {
                Prisoner prisoner = new Prisoner(i);
                prisoners.Add(prisoner);
            }
            return prisoners;
        }
        
        static int[] RandArr()
        {
            Random rng = new Random();
            int[] cupboards = new int[100];

            for (int i = 0; i < cupboards.Length; i++)
            {
                cupboards[i] = i;
            }

            for (int i = cupboards.Length - 1; i > 0; i--)
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
