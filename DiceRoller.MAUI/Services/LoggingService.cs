using DiceRoller.MAUI.Models;
using Microsoft.UI.Xaml.Controls.Primitives;
using System.Text;

namespace DiceRoller.MAUI.Services
{
    public static class LoggingService
    {
        private static readonly string FILE = $"DiceRollsLog_{DateTime.Now.ToString("M-d-yyyy H_mm_ss")}.txt".Replace(" ", "_");
        private const string PATH = @"..\..\..\..\..\Logs";

        public static void GenerateRollResultLog(string selected, string rolls, string modifier, string total)
        {
            StringBuilder sb = new();
            sb.AppendLine("******************************");
            sb.AppendLine($"Dice Roll: {DateTime.Now.ToString()}");
            sb.AppendLine($"Selected dice: {selected}");
            sb.AppendLine($"Individual rolls: {rolls}");
            sb.AppendLine($"Modifier: {modifier}");
            sb.AppendLine($"TOTAL Result: {total}");
            sb.AppendLine("******************************");
            WriteToLog(sb);
        }

        public static void GenerateAbilityScoreResultsLog(IEnumerable<AbilityScoreResult> scores)
        {
            StringBuilder sb = new();
            sb.AppendLine("******************************");
            sb.AppendLine($"Ability Score Rolls: {DateTime.Now.ToString()}\n");
            foreach (AbilityScoreResult score in scores)
            {
                sb.AppendLine($"Discarded roll: {score.DiscardedRoll}");
                sb.AppendLine($"Rolls: {score.Rolls}");
                sb.AppendLine($"TOTAL Result: {score.RollTotal}");
                if (scores.ToList().IndexOf(score) != scores.ToList().Count - 1)
                {
                    sb.AppendLine();
                }
            }
            sb.AppendLine("******************************");
            WriteToLog(sb);
        }

        private static void WriteToLog(StringBuilder sb)
        {
            string directory = AppContext.BaseDirectory;
            string fullpath = Path.Combine(directory, PATH, FILE);

            try
            {
                using StreamWriter sw = new(fullpath, true);
                sw.WriteLine(sb);
            }
            catch (IOException) { throw; }
        }
    }
}
