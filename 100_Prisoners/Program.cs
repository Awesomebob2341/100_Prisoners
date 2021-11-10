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

            int maxGuesses = 50;
            int guessCount = 0;

            for (int i = 0; i < prisoners.Count; i++)
            {
                while (guessCount < maxGuesses)
                {
                    int cupboard = rand.Next(cupboards.Length);

                    if (!prisoners[i].AlreadyChecked(cupboard))
                    {
                        if (prisoners[i].id == cupboards[cupboard])
                        {
                            pass.Add(prisoners[i]);
                            
                        }
                        else if (prisoners[i].CupboardsCheckedCount() == 50 && prisoners[i].id != cupboards[cupboard])
                        {
                            return false;
                        }
                        else
                        {
                            prisoners[i].AddCupboard(cupboard);
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
            List<bool> RandOutcomes = new List<bool>();
            double randomPass = 0.0;
            double randomFail = 0.0;
            double randPercentPass = 0.0;
            
            for (int i = 0; i < 100; i++)
            {
                RandOutcomes.Add(RandomPlay());
            }

            for (int i = 0; i < RandOutcomes.Count(); i++)
            {
                if (RandOutcomes[i])
                    randomPass++;
            }

            randPercentPass = randomPass / (randomPass + randomFail);

            Console.WriteLine("100 sessions were played using a random method. {0} iterations passed, {1} iterations failed. {2}% chance of success",
                              randomPass, randomFail, randPercentPass);

            Console.ReadKey();
        }
    }
}
