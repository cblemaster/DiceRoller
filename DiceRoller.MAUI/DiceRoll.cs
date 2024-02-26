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

            //TODO: d2 and d3
            if (Sides == 2) { }
            if (Sides == 3) { }

            // generate random for each Count and add to collection to return
            for (int i = 1; i <= Count; i++)
            {
                dieRolls.Add(GetRandom(Sides));
            }

            return dieRolls.AsEnumerable<uint>();
        }

        public uint RollPercentile()
        {
            // Per the 5th edition PH d100 is two (2) d10s
            // the first representing the tens place
            // the second representing the ones place

            uint tens = GetRandom(10);
            uint ones = GetRandom(10);

            if (tens == 0)
            {
                return ones == 0 ? 100 : ones;
            }

            string combined = tens.ToString() + ones;
            _ = uint.TryParse(combined, out uint percentile);

            return percentile;
        }

        public uint GetRandom(uint sides = 20) => (uint)(_random.Next((int)sides + 1));
    }
}
