namespace OCC.Pages;

public partial class Homepage : ContentPage
{
	public Homepage()
	{
		InitializeComponent();
	}

    private async void Clicked_Ac(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AcPage));

    }

    private async void Clicked_Gipe(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(GipePage));

    }
}