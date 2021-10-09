using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Views;

namespace ShellOverLayTest.Droid
{
    [Activity(Label = "ShellOverLayTest", 
        Icon = "@mipmap/icon", 
        Theme = "@style/MainTheme", 
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize 
                               | ConfigChanges.Orientation 
                               | ConfigChanges.UiMode 
                               | ConfigChanges.ScreenLayout
                               | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Window.AddFlags(WindowManagerFlags.LayoutNoLimits);
                Window?.SetFlags(WindowManagerFlags.LayoutNoLimits, WindowManagerFlags.LayoutNoLimits);
            }

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}