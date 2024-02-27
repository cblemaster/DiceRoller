using DiceRoller.MAUI.PageModels;

namespace DiceRoller.MAUI.Pages;

public partial class RollDicePage : ContentPage
{
    public RollDicePage(RollDicePageModel pageModel)
    {
        InitializeComponent();
        BindingContext = pageModel;
    }
}