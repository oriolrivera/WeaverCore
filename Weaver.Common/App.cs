namespace Weaver.Common
{                       
    using MvvmCross.IoC;
    using MvvmCross.ViewModels;
    using Common.ViewModels;

    public class App : MvxApplication
    {
        public override void Initialize()
        {
            this.CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            this.RegisterAppStart<LoginViewModel>();
        }
    }
}
