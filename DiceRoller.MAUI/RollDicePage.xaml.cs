namespace DiceRoller.MAUI;

public partial class RollDicePage : ContentPage
{
    public RollDicePage(RollDicePageModel pageModel)
    {
        InitializeComponent();
        BindingContext = pageModel;
    }
}