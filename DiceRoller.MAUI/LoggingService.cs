using System.Text;

namespace DiceRoller.MAUI
{
    public class LoggingService
    {
        private const string FILE = "DiceRollsLog.txt";
        private const string PATH = @"..\..\..\..\Log";
        
        public void WriteRollResultToLog(string selected, string rolls, string modifier, string total)
        {
            StringBuilder sb = new();
            sb.AppendLine("******************************");
            sb.AppendLine($"Dice Roll: {DateTime.Now.ToLongDateString()}");
            sb.AppendLine($"Selected dice: {selected}");
            sb.AppendLine($"Individual rolls: {rolls}");
            sb.AppendLine($"Modifier: {modifier}");
            sb.AppendLine($"TOTAL Result: {total}");
            sb.AppendLine("******************************");

            string directory = Environment.CurrentDirectory;
            string fullpath = Path.Combine(directory, PATH, FILE);

            try
            {
                using StreamWriter sw = new(fullpath, false);
                sw.WriteLine(sb);
            }
            catch (IOException) { throw; }
        }
    }
}
