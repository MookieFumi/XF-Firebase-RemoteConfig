using Foundation;
using UIKit;
using Xamarin.Forms;

namespace MyRemoteConfiguration.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            Firebase.Core.App.Configure();
            Rg.Plugins.Popup.Popup.Init();

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App(new IosInitializer()));

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
