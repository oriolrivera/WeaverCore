namespace Weaver.Common.ViewModels
{
    using System.Windows.Input;
    using Interfaces;
    using Models;
    using MvvmCross.Commands;
    using MvvmCross.ViewModels;
    using Common.Services;
    using MvvmCross.Navigation;

    public class LoginViewModel : MvxViewModel
    {
        private string email;
        private string password;
        private MvxCommand loginCommand;
        private readonly IDialogService dialogService;
        private bool isLoading;
        private readonly IMvxNavigationService navigationService;
        private readonly INetworkProvider networkProvider;

        public bool IsLoading
        {
            get => this.isLoading;
            set => this.SetProperty(ref this.isLoading, value);
        }

        public string Email
        {
            get => this.email;
            set => this.SetProperty(ref this.email, value);
        }

        public string Password
        {
            get => this.password;
            set => this.SetProperty(ref this.password, value);
        }

        public ICommand LoginCommand
        {
            get
            {
                this.loginCommand = this.loginCommand ?? new MvxCommand(this.DoLoginCommand);
                return this.loginCommand;
            }
        }

        public LoginViewModel(
            IApiService apiService,
            IDialogService dialogService,
            IMvxNavigationService navigationService,
            INetworkProvider networkProvider)
        {
            this.dialogService = dialogService;
            this.navigationService = navigationService;
            this.networkProvider = networkProvider;
            this.IsLoading = false;
        }

        private async void DoLoginCommand()
        {
            /*if (string.IsNullOrEmpty(this.Email))
            {
                this.dialogService.Alert("Error", "You must enter an email.", "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                this.dialogService.Alert("Error", "You must enter a password.", "Accept");
                return;
            }  */

            /*if (!this.networkProvider.IsConnectedToWifi())
            {
                this.dialogService.Alert("Error", "The App requiered a internet connection, please check and try again.", "Accept");
                return;
            }   */

            this.IsLoading = true;          
            // TODO: request login
            this.IsLoading = false;
           // this.dialogService.Alert("Ok", "Fuck yeah!", "Accept");
            await this.navigationService.Navigate<ProductsViewModel>();
        }
    }
}
