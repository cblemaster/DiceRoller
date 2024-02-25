namespace DiceRoller.MAUI
{
    public class DiceRoll
    {
        private readonly uint[] _validSides = [2, 3, 4, 6, 8, 10, 12, 20, 100];
        private readonly Random _random = new();
                
        public required uint Sides { get; set; }
        public required uint Count { get; set; }
        public required int Modifier { get; set; }

        public bool IsSidesValid => _validSides.Contains<uint>(Sides);
        public bool IsModifierValid => Modifier is <= 100 and >= (-100);
        public bool IsCountValid => Count > 0 && ((Sides == 2 || Sides == 3) && Count == 1);    // d2 and d3 can only be rolled with count of one (1)

        public IEnumerable<uint> Roll()
        {
            /* I consulted the 5th edition player's handbook
               for guidance on dice rolling rules */
            
            if (Sides == 100) { return [RollPercentile()]; }    // d100 has special rules

            List<uint> dieRolls = [];

            if (!IsSidesValid || ! IsModifierValid || !IsCountValid) { return dieRolls; }

            // generate random for each Count and add to collection to return
            for (int i = 1; i <= Count; i++)
            {
                dieRolls.Add(GetRandom(Sides));
            }
            
            return dieRolls;
        }
        public uint RollPercentile()
        {
            // per the 5th edition PH d100 is two (2) d10s
            // the first representing the tens place
            // the second representing the ones place

            uint tens = GetRandom(10);
            uint ones = GetRandom(10);

            if (tens == 0)
            {
                return ones == 0 ? 100 : ones;
            }

            string combined = tens.ToString() + ones;
            return uint.TryParse(combined, out uint result)
                ? result
                : throw new InvalidCastException("An error occured calculating the percentile dice result.");
        }

        public uint GetRandom(uint sides = 20) => (uint)(_random.Next((int)sides + 1));
    }
}
