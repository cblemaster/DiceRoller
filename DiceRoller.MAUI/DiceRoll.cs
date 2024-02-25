namespace DiceRoller.MAUI
{
    public class DiceRoll
    {
        private readonly uint[] _validSides = {2, 3, 4, 6, 8, 10, 12, 20, 100 };
        private readonly Random _random = new();
                
        public required uint Sides { get; set; }
        public required uint Count { get; set; }
        public required int Modifier { get; set; }

        public bool IsSidesValid => _validSides.Contains<uint>(Sides);
        public bool IsModifierValid => Modifier is <= 100 and >= (-100);
        public bool IsCountValid => Count > 0;

        public int Roll() => throw new NotImplementedException();
    }
}
