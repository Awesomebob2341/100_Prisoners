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
                guessCount = 0;
                while (guessCount < maxGuesses)
                {
                    int cupboard = rand.Next(cupboards.Length);

                    if (!prisoners[i].AlreadyChecked(cupboard))
                    {
                        if (prisoners[i].id == cupboards[cupboard])
                        {
                            pass.Add(prisoners[i]);
                            guessCount += 50;
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

        static bool OptimizedPlay()
        {
            List<Prisoner> pass = new List<Prisoner>();
            List<Prisoner> prisoners = CreatePrisoners();

            int[] cupboards = RandArr();

            int maxGuesses = 51;
            int guessCount = 0;

            int cupboard = 0;

            for (int i = 0; i < prisoners.Count(); i++)
            {
                guessCount = 0;
                cupboard = 0;

                while (guessCount < maxGuesses)
                {
                    if (guessCount == 0)
                    {
                        cupboard = prisoners[i].id;

                        if (prisoners[i].id == cupboards[cupboard])
                        {
                            pass.Add(prisoners[i]);
                            guessCount += 51;
                        }
                        else
                        {
                            prisoners[i].AddCupboard(cupboard);
                            guessCount++;
                        }
                    }
                    else if (guessCount > 0)
                    {
                        cupboard = cupboards[cupboard];

                        if (prisoners[i].id == cupboards[cupboard])
                        {
                            pass.Add(prisoners[i]);
                            guessCount += 50;
                        }
                        else if (prisoners[i].id != cupboards[cupboard] && prisoners[i].CupboardsCheckedCount() >= 50)
                        {
                            return false;
                        }
                        else
                        {
                            prisoners[i].AddCupboard(cupboard);
                            guessCount++;
                        }
                    }
                }
            }
            return true;
        }

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
            List<bool> optOutcomes = new List<bool>();
            List<bool> randOutcomes = new List<bool>();

            int totalRuns = 1000000;

            double optPass = 0.0;
            double optFail = 0.0;
            double optPercentPass = 0.0;

            double randPass = 0.0;
            double randFail = 0.0;
            double randPercentPass = 0.0;

            for (int i = 0; i < totalRuns; i++)
            {
                optOutcomes.Add(OptimizedPlay());
            }

            for (int i = 0; i < totalRuns; i++)
            {
                randOutcomes.Add(RandomPlay());
            }

            for (int i = 0; i < optOutcomes.Count(); i++)
            {
                if (optOutcomes[i])
                    optPass++;
                else
                    optFail++;
            }

            for (int i = 0; i < randOutcomes.Count(); i++)
            {
                if (randOutcomes[i])
                    randPass++;
                else
                    randFail++;
            }

            optPercentPass = Math.Round(100 * optPass / totalRuns, 2);
            randPercentPass = Math.Round(100 * randPass / totalRuns, 2);

            Console.WriteLine("{0} sessions were played using the optimized method. {1} iterations passed, {2} iterations failed. {3}% chance of success",
                              totalRuns, optPass, optFail, optPercentPass);

            Console.WriteLine("{0} sessions were played using a random method. {1} iterations passed, {2} iterations failed. {3}% chance of success",
                              totalRuns, randPass, randFail, randPercentPass);

            Console.ReadKey();
        }
    }
}
