namespace DiceRoller.Classes
{
    public class DiceResult
    {
        public DiceResult()
        {
            this.Results = new();
        }

        public DieTypes DieType { get; set; }
        public int NumberThrown { get; set; }
        public int Modifier { get; set; }
        public List<int> Results { get; set; }
        public int TotalResult => Results.Sum() + Modifier;

        public void RollDice()
        {
            Random rnd = new();
            for (int i = 0; i < NumberThrown; i++)
            {
                switch (DieType)
                {
                    case DieTypes.d2:  //1d2 = 1d4/2, round down
                        int d2Result = rnd.Next(1, (int)DieTypes.d4 + 1) / 2;
                        if (d2Result == 0) d2Result = 1;
                        Results.Add(d2Result);
                        break;
                    case DieTypes.d3:  //1d3 = 1d6/2, round down
                        int d3Result = rnd.Next(1, (int)DieTypes.d6 + 1) / 2;
                        if (d3Result == 0) d3Result = 1;
                        Results.Add(d3Result);
                        break;
                    default:
                        Results.Add(rnd.Next(1, (int)DieType + 1));
                        break;
                }
            }
        }

        public void RollAbilityScores()
        {
            this.DieType = DieTypes.d6;
            this.NumberThrown = 4;   //roll 4 dice
            this.Modifier = 0;
            this.RollDice();
            this.Results = this.Results.OrderBy(x => x).Take(3).ToList();  //take the highest 3
        }
    }
}