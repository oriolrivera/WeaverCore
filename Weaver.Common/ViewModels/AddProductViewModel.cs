namespace Weaver.Common.ViewModels
{
    using Interfaces;
    using Models;
    using MvvmCross.Commands;
    using MvvmCross.Navigation;
    using MvvmCross.ViewModels;
    using Newtonsoft.Json;
    using Services;
    using System.Windows.Input;

    public class AddProductViewModel : MvxViewModel
    {
        private string name;
        private string price;
        private MvxCommand addProductCommand;
        private readonly IApiService apiService;
        private readonly IDialogService dialogService;
        private readonly IMvxNavigationService navigationService;
        private bool isLoading;

        public bool IsLoading
        {
            get => this.isLoading;
            set => this.SetProperty(ref this.isLoading, value);
        }

        public string Name
        {
            get => this.name;
            set => this.SetProperty(ref this.name, value);
        }

        public string Price
        {
            get => this.price;
            set => this.SetProperty(ref this.price, value);
        }

        public ICommand AddProductCommand
        {
            get
            {
                this.addProductCommand = this.addProductCommand ?? new MvxCommand(this.AddProduct);
                return this.addProductCommand;
            }
        }

        public AddProductViewModel(
            IApiService apiService,
            IDialogService dialogService,
            IMvxNavigationService navigationService)
        {
            this.apiService = apiService;
            this.dialogService = dialogService;
            this.navigationService = navigationService;
        }

        private async void AddProduct()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                this.dialogService.Alert("Error", "You must enter a product name.", "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.Price))
            {
                this.dialogService.Alert("Error", "You must enter a product price.", "Accept");
                return;
            }

            var price = decimal.Parse(this.Price);
            if (price <= 0)
            {
                this.dialogService.Alert("Error", "The price must be a number greather than zero.", "Accept");
                return;
            }

            this.IsLoading = true;
               
            var product = new Product
            {
                IsAvailabe = true,
                Name = this.Name,
                Price = price
            };


            var response = await this.apiService.PostAsync("/Products", product);

            this.IsLoading = false;

            if (!response.IsSuccess)
            {
                this.dialogService.Alert("Error", response.Message, "Accept");
                return;
            }

            var newProduct = (Product)response.Result;
            await this.navigationService.Close(this);
        }
    }
}
