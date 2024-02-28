using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DiceRoller.MAUI.PageModels
{
    public partial class HowItWorksPageModel : ObservableObject
    {
        [RelayCommand]
        private void CloseClicked() => Shell.Current.Navigation.PopModalAsync();
    }
}
