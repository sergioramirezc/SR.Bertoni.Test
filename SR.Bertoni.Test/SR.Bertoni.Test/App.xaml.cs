using SR.Bertoni.Test.Repository;
using SR.Bertoni.Test.Services;
using SR.Bertoni.Test.ViewModels.Base;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SR.Bertoni.Test
{
    public partial class App : Application
    {
        public App()
        {
            DataLayer.Instance.SetDataBasePlatform();
            InitializeComponent();
            InitApp();
        }

        private void InitApp()
        {
            ViewModelLocator.RegisterDependencies();
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override async void OnStart()
        {
            base.OnStart();
            await InitNavigation();
        }
    }
}
