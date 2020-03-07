using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Bertoni.Test.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SR.Bertoni.Test.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskListView : ContentPage
    {
        public TaskListView()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await((TaskListViewModel)this.BindingContext).InitializeAsync(null);
        }
    }
}