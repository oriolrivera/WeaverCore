namespace Product.UICross.droid.Views
{
    using global::Android.App;
    using global::Android.OS;
    using MvvmCross.Platforms.Android.Views;
    using Weaver.Common.ViewModels;

    [Activity(Label = "@string/add_product")]
    public class AddProductView : MvxActivity<AddProductViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.SetContentView(Resource.Layout.AddProductPage);
        }
    }
}