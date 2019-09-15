namespace Product.UICross.droid.Views
{
    using Weaver.Common.ViewModels;
    using global::Android.App;
    using global::Android.OS;
    using MvvmCross.Platforms.Android.Views;    

    [Activity(Label = "@string/app_name")]
    public class ProductsView : MvxActivity<ProductsViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.ProductsPage);
        }
    }
}