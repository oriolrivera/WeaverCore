namespace Product.UICross.droid.Views
{
    using global::Android.App;
    using global::Android.OS;
    using MvvmCross.Platforms.Android.Views;
    using Weaver.Common.ViewModels;

    [Activity(Label = "@string/app_name")]
    public class ProductDetailView : MvxActivity<ProductsDetailViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SetContentView(Resource.Layout.ProductDetailPage);
        }
    }
}