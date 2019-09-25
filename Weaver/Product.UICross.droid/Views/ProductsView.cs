﻿using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;
using Weaver.Common.ViewModels;
using Toolbar = global::Android.Support.V7.Widget.Toolbar;

namespace Product.UICross.droid.Views
{
    [Activity(Label = "@string/products")]
    public class ProductsView : MvxAppCompatActivity<ProductsViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.SetContentView(Resource.Layout.ProductsPage);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
        }
    }
}