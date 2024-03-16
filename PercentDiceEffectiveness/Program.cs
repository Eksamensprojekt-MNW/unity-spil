namespace PercentDiceEffectiveness
{
    internal class Program
    {
        //dice settings
        static int dices;
        static int diceSides;

        //number of possible dice sums, to calculate sum percentage accurately
        static int diceThrowSums = dices * diceSides - dices + 1;

        //returns an effect percentage
        //string: action the effect applies to
        //float: holds the percentage to get an effect. Effect is chosen from percentage's index
        static Dictionary<string, float[]> effectPercentages = new Dictionary<string, float[]>();

        //returns an effect
        //string: action the effect applies to
        //float: holds the effect, chosen from previous dictionary's percentage index
        static Dictionary<string, float[]> effects = new Dictionary<string, float[]>();

        static void Main(string[] args)
        {

        }

        /// <summary>
        /// Sets the dice values
        /// </summary>
        /// <param name="dices"></param> amount of dices
        /// <param name="diceSides"></param> amount of sides on a dice
        public static void setDiceSettings(int dicesCount, int diceSidesCount)
        {
            dices = dicesCount;
            diceSides = diceSidesCount;
            diceThrowSums = diceSides * dices - dices + 1;
        }

        /// <summary>
        /// Sets a list of percentage possibilities, for effect calculations
        /// </summary>
        /// <param name="categoryName"></param> what is the effect applied to
        /// <param name="effectChances"></param> what is the chance to get an index specified effect
        /// <param name="effectOptions"></param> what are the options to choose from, picked with percentage
        public static void setEffects(string categoryName, float[] effectChances, float[] effectOptions)
        {
            float[] upscaleChances = new float[effectChances.Length]; //takes percentages to upscale from individual to 0-100%
            for (int i = 0; i < effectChances.Length; i++) //makes changes
            {
                if (i == 0) upscaleChances[i] = effectChances[i];
                else upscaleChances[i] = effectChances[i] + upscaleChances[i - 1];
            }

            effectPercentages.Add(categoryName, upscaleChances);
            effects.Add(categoryName, effectOptions);
        }

        /// <summary>
        /// Returns an effect based on the percentage options, belonging to action name
        /// </summary>
        /// <param name="categoryName"></param> name of action
        /// <returns></returns>
        public static float getEffect(string categoryName, int sum_)
        {
            //gets the percentages to choose from, for effect choice later
            float[] percentages = effectPercentages[categoryName];

            //gets a random percentage from dice throw, to compare with percent choices
            int[] throws = new int[dices]; //throw results
            Random random = new Random();
            for (int i = 0; i < dices; i++) //throw dices
            {
                throws[i] = random.Next(1, diceSides + 1); //save results
            }
            int sum = sum_; // throws.Sum();
            float percent = (float)(sum - dices + 1) / diceThrowSums; //calculates percentage. sum - dices + 1 to avoid sum overflow, while keeping accuracy
            Console.WriteLine("percent: " + percent);

            //gets the effect from percentage
            for (int i = 0; i < percentages.Length; i++)
            {
                if (percent <= percentages[i])
                {
                    Console.WriteLine($"percent: {percent}, percent[{i}]: {percentages[i]}");
                    return effects[categoryName][i];
                }
            }

            return 0;
        }
    }
}
