using DiceRoller.MAUI.PageModels;

namespace DiceRoller.MAUI.Pages;

public partial class HowItWorksPage : ContentPage
{
	public HowItWorksPage()
	{
		InitializeComponent();
        HowItWorksPageModel pageModel = Shell.Current.Handler!.MauiContext!.Services.GetService<HowItWorksPageModel>()!;
        BindingContext = pageModel;
    }
}