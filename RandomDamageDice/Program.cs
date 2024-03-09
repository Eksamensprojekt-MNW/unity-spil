using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace RandomDamageDice
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int dices = 2;
            int diceSides = 6;
            int max = dices * diceSides;
            float[] optionsOut = [0, 1, 2, 3]; //2,3 4,5,6 7,8,9 10,11,12
            Dictionary<int, float> DiceOptions = new Dictionary<int, float>();
            int optionsCount = diceSides * dices - dices + 1;

            int sum = 3;
            int optionsPer = optionsCount / optionsOut.Length;

            for (int i = max, per = optionsPer, ind = optionsOut.Length - 1; i >= dices; i--, per--)
            {
                /*
                 * skal laves om
                 * bestem resultat ud fra hvor stor chance for at få tal (procent-kvartiler. hver outcome er et kvartil)
                 * bruger bestemmer hvilken procentdel chance for hvert resultat
                 */

                if (per > 0)
                {
                    DiceOptions.Add(i, optionsOut[ind]);
                    Console.WriteLine($"{i}, {optionsOut[ind]}");
                    continue;
                }
                else
                {
                    per = optionsPer;
                    if (ind > 0) ind--;
                }
            }
            return;
            /*
            for (int i = dices*diceSides; i >= dices; i--)
            {
                int max = dices * diceSides;
                float[] optionsOut = [0, 1, 2, 3]; //2,3,4,5,6,7,8,9,10,11,12
                int sum = i;

                float damage = RandomDiceDamage(dices, diceSides, optionsOut, sum);
            }*/
        }

        void setDiceOptions(int dices, int diceSides, float[] options, Dictionary<int, float> DiceOptions)
        {
            
        }

        static float RandomDiceDamage(int dices, int diceSides, float[] damageOptions, int sum)
        {
            //rolling the dices
            int[] rolls = new int[dices];
            Random random = new Random();
            for (int i = 0; i < dices; i++)
            {
                rolls[i] = random.Next(dices, diceSides + 1);
            }

            //calculating result
            int[] rollOptions = new int[diceSides*dices-dices+1];


            float rollsSum = sum;//rolls.Sum();
            float maxSum = diceSides * dices - dices + 1;
            int resultIndex = (int)((rollsSum / maxSum) * ((float)damageOptions.Length - 1));

            //the result
            //float result = damageOptions[resultIndex-1];
            Console.WriteLine($"{sum}: {resultIndex}");
            return sum;
        }
    }
}