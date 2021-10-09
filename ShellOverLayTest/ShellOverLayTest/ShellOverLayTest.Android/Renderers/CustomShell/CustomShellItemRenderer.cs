using Android.Content.Res;
using Android.OS;
using Android.Views;
using Android.Widget;
using Google.Android.Material.BottomNavigation;
using ShellOverLayTest.Views.Controls.ShellOverlay;
using Xamarin.Forms.Platform.Android;

namespace ShellOverLayTest.Droid.Renderers.CustomShell
{
    public class CustomShellItemRenderer : ShellItemRenderer
    {
        FrameLayout shellOverlay;
        View outerlayout;
        BottomNavigationView bottomView;
        IVisualElementRenderer viewRenderer;

        public CustomShellItemRenderer(IShellContext shellContext) : base(shellContext)
        {
        }

        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            outerlayout = base.OnCreateView(inflater, container, savedInstanceState);
            bottomView = outerlayout.FindViewById<BottomNavigationView>(Resource.Id.bottomtab_tabbar);
            shellOverlay = outerlayout.FindViewById<FrameLayout>(Resource.Id.bottomtab_tabbar_container);

            if (ShellItem is ShellOverlay overlay && overlay.Content != null)
                SetupOverlay();

            return outerlayout;
        }

        private void SetupOverlay()
        {
            var overlay = (ShellOverlay)ShellItem;

            bottomView.Measure((int)MeasureSpecMode.Unspecified, (int)MeasureSpecMode.Unspecified);

            outerlayout.Measure((int)MeasureSpecMode.Unspecified, (int)MeasureSpecMode.Unspecified);

            shellOverlay.RemoveAllViews();
            shellOverlay.AddView(ConvertFormsToNative(overlay.Content,
                new Xamarin.Forms.Rectangle(0, 0, Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Width / Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density, Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Height / Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density)));
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);

            SetupOverlay();
        }

        private View ConvertFormsToNative(Xamarin.Forms.View view, Xamarin.Forms.Rectangle size)
        {
            viewRenderer = Platform.CreateRendererWithContext(view, Context);
            var viewGroup = viewRenderer.View;
            viewRenderer.Tracker.UpdateLayout();

            if (view.HeightRequest > 0)
                size.Height = view.HeightRequest;

            var layoutParams = new ViewGroup.LayoutParams((int)(size.Width * Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density), (int)(size.Height * Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density));
            viewGroup.LayoutParameters = layoutParams;
            view.Layout(size);
            viewGroup.Layout(0, 0, (int)view.Width, (int)view.Height);
            return viewGroup;
        }
    }
}