// See https://aka.ms/new-console-template for more information

using DiceRoller.Classes;
using DiceRoller.UI;

const string MAIN_MENU_OPTION_ROLL_DICE = "Roll Dice";
const string MAIN_MENU_OPTION_ROLL_ABILITY_SCORE = "Roll Ability Score";
const string MAIN_MENU_OPTION_EXIT = "Exit";
string[] MAIN_MENU_OPTIONS = { MAIN_MENU_OPTION_ROLL_DICE, MAIN_MENU_OPTION_ROLL_ABILITY_SCORE, MAIN_MENU_OPTION_EXIT }; //const has to be known at compile time, the array initializer is not const in C#

IBasicUserInterface ui = new MenuDrivenCLI();

bool isRolling = true;

while (isRolling)
{
    string mainMenuSelection = (string)ui.PromptForSelection(MAIN_MENU_OPTIONS);  // main menu prompt for selection
    if (mainMenuSelection == MAIN_MENU_OPTION_ROLL_DICE)
    {
        DisplayDieTypes();
        int dieSelection = -1;
        while (dieSelection == -1)
        {
            ui.Output("Select the die type you want to roll.");

            int.TryParse(Console.ReadLine(), out dieSelection);
            if (!ValidateDieTypeInput(dieSelection))
            {
                dieSelection = -1;
            }            
        }
        int numberToThrow = 0;
        while (numberToThrow <= 0)
        {
            ui.Output("Enter the number of dice to throw, positive whole number.");
            int.TryParse(Console.ReadLine(), out numberToThrow);
        }
        int modifier = -1111;
        while (modifier == -1111)
        {
            ui.Output("Enter modifier, positive or negative whole number.");
            int.TryParse(Console.ReadLine(), out modifier);
        }
        DiceResult result = new();
        result.DieType = GetDieTypeFromInput(dieSelection);
        result.NumberThrown = numberToThrow;
        result.Modifier = modifier;
        result.RollDice();
        DisplayDiceResults(result);
    }
    if (mainMenuSelection == MAIN_MENU_OPTION_ROLL_ABILITY_SCORE)
    {
        DiceResult result = new();
        result.RollAbilityScores();
        DisplayDiceResults(result);
    }
    if (mainMenuSelection == MAIN_MENU_OPTION_EXIT)
    {
        isRolling = false;
    }
}

void DisplayDieTypes()
{
    Console.WriteLine("Select type of dice to roll:");
    int counter = 1;
    foreach (var item in Enum.GetNames(typeof(DieTypes)))
    {
        Console.WriteLine(counter.ToString() + ") " +item.ToString());
        counter++;
    }
    Console.WriteLine('\n');
}

bool ValidateDieTypeInput(int dieSelection)
{
    if (dieSelection > 0 && dieSelection < 10) return true;
    return false;
}

DieTypes GetDieTypeFromInput(int dieSelection)
{
    return dieSelection switch
    {
        1 => DieTypes.d2,
        2 => DieTypes.d3,
        3 => DieTypes.d4,
        4 => DieTypes.d6,
        5 => DieTypes.d8,
        6 => DieTypes.d10,
        7 => DieTypes.d12,
        8 => DieTypes.d20,
        9 => DieTypes.d100,
        _ => throw new NotImplementedException(),
    };
}

static void DisplayDiceResults(DiceResult result)
{
    int counter = 1;
    foreach (int dieResult in result.Results)
    {
        Console.WriteLine(result.DieType.ToString() + " result #" + counter + ": " + dieResult);
        counter++;
    }
    Console.WriteLine("Modfier: " + result.Modifier);
    Console.WriteLine("TOTAL: " + result.TotalResult);
}