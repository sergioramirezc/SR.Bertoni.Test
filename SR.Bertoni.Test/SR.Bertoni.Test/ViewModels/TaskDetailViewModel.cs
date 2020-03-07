using SR.Bertoni.Test.Models.Task;
using SR.Bertoni.Test.Services.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SR.Bertoni.Test.ViewModels
{
    public class TaskDetailViewModel : Base.ViewModelBase
    {
        private ITaskService _taskService;

        private TaskModel _task = new TaskModel();

        public TaskModel Task
        {
            get { return _task; }
            set
            {
                _task = value;
                RaisePropertyChanged(() => Task);
            }
        }

        private bool Create = false;

        public TaskDetailViewModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;
            await base.InitializeAsync(null);

            if (navigationData != null)
            {
                Task = navigationData as TaskModel;
            }
            else
            {
                Create = true;
            }

            IsBusy = false;
        }


        public ICommand DeleteCommand => new Command(() => DeleteAsync());

        private async void DeleteAsync()
        {
            await _taskService.DeleteTask(Task);
            await NavigationService.NavigateBackAsync();
        }

        public ICommand SaveCommand => new Command(() => SaveAsync());

        private async void SaveAsync()
        {
            if (Create)
            {
                Task.Id = Guid.NewGuid().ToString();
                await _taskService.AddTask(Task);
            }
            else
            {
                await _taskService.UpdateTask(Task.Id, Task);
            }
            await NavigationService.NavigateBackAsync();
        }

        public ICommand CancelCommand => new Command(() => CancelAsync());

        private async void CancelAsync()
        {
            await NavigationService.NavigateBackAsync();
        }
    }
}
