using System.Text;

namespace DiceRoller.MAUI.Services
{
    public static class LoggingService
    {
        private static readonly string FILE = $"DiceRollsLog_{DateTime.Now.ToString("M-d-yyyy H_mm_ss")}.txt".Replace(" ", "_");
        private const string PATH = @"..\..\..\..\..\Logs";

        public static void WriteRollResultToLog(string selected, string rolls, string modifier, string total)
        {
            StringBuilder sb = new();
            sb.AppendLine("******************************");
            sb.AppendLine($"Dice Roll: {DateTime.Now.ToString()}");
            sb.AppendLine($"Selected dice: {selected}");
            sb.AppendLine($"Individual rolls: {rolls}");
            sb.AppendLine($"Modifier: {modifier}");
            sb.AppendLine($"TOTAL Result: {total}");
            sb.AppendLine("******************************");

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
