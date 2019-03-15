using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using alura.Droid;
using Android.Content;
using Android.Provider;
using Xamarin.Forms;
using alura.Media;
using Plugin.CurrentActivity;

[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace alura.Droid
{
    [Activity(Label = "alura", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ICamera
    {
        public void TirarFoto()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);

            var activity = CrossCurrentActivity.Current.Activity;

            activity.StartActivityForResult(intent, 0);
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}