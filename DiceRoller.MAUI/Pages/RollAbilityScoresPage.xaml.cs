using DiceRoller.MAUI.PageModels;

namespace DiceRoller.MAUI.Pages;

public partial class RollAbilityScoresPage : ContentPage
{
    public RollAbilityScoresPage(RollAbilityScoresPageModel pageModel)
    {
        InitializeComponent();
        BindingContext = pageModel;
    }
}