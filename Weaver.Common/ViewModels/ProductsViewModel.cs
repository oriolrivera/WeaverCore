namespace Weaver.Common.ViewModels
{         
    using Interfaces;
    using Models;
    using MvvmCross.Commands;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;
    using Newtonsoft.Json;
    using Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;

    public class ProductsViewModel : MvxViewModel
    {
        private List<Product> products;
        private readonly IApiService apiService;
        private readonly IDialogService dialogService;
        private readonly IMvxNavigationService navigationService;
        private MvxCommand addProductCommand;
        private MvxCommand<Product> itemClickCommand;

        public ProductsViewModel(
            IApiService apiService,
            IDialogService dialogService,
            IMvxNavigationService navigationService)
        {
            this.apiService = apiService;
            this.dialogService = dialogService;
            this.navigationService = navigationService;
        }

        public List<Product> Products
        {
            get => this.products;
            set => this.SetProperty(ref this.products, value);
        }

        public ICommand AddProductCommand
        {
            get
            {
                this.addProductCommand = this.addProductCommand ?? new MvxCommand(this.AddProduct);
                return this.addProductCommand;
            }
        }

        public ICommand ItemClickCommand
        {
            get
            {
                this.itemClickCommand = new MvxCommand<Product>(this.OnItemClickCommand);
                return itemClickCommand;
            }
        }

        private async void AddProduct()
        {
            await this.navigationService.Navigate<AddProductViewModel>();
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
            this.LoadProducts();
        }

        private async void OnItemClickCommand(Product product)
        {
            await this.navigationService.Navigate<ProductsDetailViewModel, NavigationArgs>(
                new NavigationArgs { Product = product });
        }

        private async void LoadProducts()
        {
            
            var response = await this.apiService.GetListAsync<Product>("Products");

            if (!response.IsSuccess)
            {
                this.dialogService.Alert("Error", response.Message, "Accept");
                return;
            }

            this.Products = (List<Product>)response.Result;
            this.Products = this.Products.OrderBy(p => p.Name).ToList();
        }
    }
}
