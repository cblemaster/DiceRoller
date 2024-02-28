using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiceRoller.MAUI.Models;
using DiceRoller.MAUI.Pages;
using DiceRoller.MAUI.Services;
using System.Collections.ObjectModel;

namespace DiceRoller.MAUI.PageModels;

public partial class RollAbilityScoresPageModel : ObservableObject
{
    [ObservableProperty]
    private ReadOnlyCollection<AbilityScoreResult> _rollResults = default!;

    [RelayCommand]
    private void HowItWorksClicked() => Shell.Current.Navigation.PushModalAsync(new HowItWorksPage());

    [RelayCommand]
    private void RollAbilityScoresClicked()
    {
        DiceRoll roller = new() { Sides = 6, Count = 4, Modifier = 4 };
        RollResults = roller.RollAbiltyScores().ToList().AsReadOnly();

        LoggingService.GenerateAbilityScoreResultsLog(RollResults);
    }
}
