using OCC.Pages;

namespace OCC
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(GipePage), typeof(GipePage));
            Routing.RegisterRoute(nameof(AcPage), typeof(AcPage));
        }
    }
}
