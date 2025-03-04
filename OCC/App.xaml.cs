﻿
namespace OCC
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window =base.CreateWindow(activationState);

            const int newWidth = 500;

            window.Width = newWidth;

            window.MaximumWidth = newWidth;
            window.MinimumWidth = newWidth;


            return window;
        }
    }
}
