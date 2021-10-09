using Android.Content;
using ShellOverLayTest.Droid.Renderers.CustomShell;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ShellOverLayTest.AppShell), typeof(CustomShellRenderer))]
namespace ShellOverLayTest.Droid.Renderers.CustomShell
{
    public class CustomShellRenderer : ShellRenderer
    {
        public CustomShellRenderer(Context context) : base(context)
        {
        }

        protected override IShellItemRenderer CreateShellItemRenderer(ShellItem shellItem)
        {
            return new CustomShellItemRenderer(this);
        }
       
    }
}