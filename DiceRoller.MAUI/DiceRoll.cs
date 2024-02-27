namespace DiceRoller.MAUI
{
    public class DiceRoll
    {
        private readonly Random _random = new();
        public static IEnumerable<uint> ValidSides => [2, 3, 4, 6, 8, 10, 12, 20, 100];

        public required uint Sides { get; init; }
        public required uint Count { get; init; }
        public required int Modifier { get; init; }

        public bool IsSidesValid => ValidSides.Contains<uint>(Sides);
        public bool IsCountValid => (Sides == 2 || Sides == 3 || Sides == 100) && Count == 1 || Count > 0; // d2 and d3 can only be rolled with count of one (1); it also doesn't make sense to roll more than one (1) d100

        public bool IsModifierValid => Modifier is <= 100 and >= (-100);

        public IEnumerable<uint> Roll()
        {
            /* I consulted the 5th edition player's handbook
               for guidance on dice rolling rules */

            List<uint> dieRolls = [];

            if (!IsSidesValid || !IsModifierValid || !IsCountValid) { return dieRolls; }

            if (Sides == 100)   // d100 has special rules
            {
                dieRolls.Add(RollPercentile());
                return dieRolls;
            }
            if (Sides == 2)   // d2 has special rules
            {
                dieRolls.Add(Rolld2());
                return dieRolls;
            }
            if (Sides == 3)   // d3 has special rules
            {
                dieRolls.Add(Rolld3());
                return dieRolls;
            }

            // generate random for each Count and add to collection to return
            for (int i = 1; i <= Count; i++)
            {
                dieRolls.Add(GetRandom(Sides));
            }

            if (dieRolls.Any(d => d > Sides || d == 0))
            {
                // just need something here to set a breakpoint on for debugging; should maybe replace this with an exception long term?
                string a = string.Empty;
            }
            
            return dieRolls.AsEnumerable<uint>();

            uint RollPercentile()
            {
                // Per the 5th edition PH d100 is two (2) d10s
                // the first representing the tens place
                // the second representing the ones place

                uint tens = (uint)_random.Next(0, 10);
                uint ones = (uint)_random.Next(0, 10);

                if (tens == 0)
                {
                    return ones == 0 ? 100 : ones;
                }

                string combined = tens.ToString() + ones;
                _ = uint.TryParse(combined, out uint percentile);

                return percentile;
            }

            uint Rolld2()
            {
                // Per the 5th edition PH d2 is rolled
                // by assigning either odd or even to one
                // and the other to two for the result of 1d4

                uint roll = (uint)_random.Next(1, 5);
                return roll % 2 == 0 ? 1u : 2;
            }

            uint Rolld3()
            {
                // Per the 5th edition PH d3 is rolled
                // by dividing the result of 1d6 by two, round up

                uint roll = (uint)_random.Next(1, 7);
                
                if (roll % 2 == 0) { return roll / 2; }

                decimal half = (decimal)roll / 2;
                int drop = (int)half;
                int roundup = drop + 1;
                uint value = (uint)roundup;

                return value;
            }
        }

        public uint GetRandom(uint sides = 20) => (uint)(_random.Next((int)sides + 1));
    }
}
