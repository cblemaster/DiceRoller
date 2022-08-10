namespace DiceRoller.UI;

public interface IBasicUserInterface
{
    void Output(string message);

    void PauseOutput();

    Object PromptForSelection(Object[] options);
}