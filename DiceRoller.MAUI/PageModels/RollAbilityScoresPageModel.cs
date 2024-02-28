using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiceRoller.MAUI.Pages;

namespace DiceRoller.MAUI.PageModels
{
    public partial class RollAbilityScoresPageModel : ObservableObject
    {
        [RelayCommand]
        private void HowItWorksClicked() => Shell.Current.Navigation.PushModalAsync(new HowItWorksPage());
    }
}
