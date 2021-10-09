using ShellOverLayTest.Views;
using System;
using System.Collections.Generic;
using ShellOverLayTest.Views.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellOverLayTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Overlay.Items.Add(new ShellContent { Route = nameof(MainPage), ContentTemplate = new DataTemplate(typeof(MainPage)) });
        }
    }
}
