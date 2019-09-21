using Weaver.Common.ViewModels;
using global::Android.App;
using global::Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace Product.UICross.droid.Views
{
                           
    [Activity(Label = "@string/app_name")]
    public class ProductsView : MvxAppCompatActivity<ProductsViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.ProductsPage);
        }
    }
}