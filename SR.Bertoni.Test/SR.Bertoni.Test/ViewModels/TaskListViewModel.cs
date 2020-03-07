using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SR.Bertoni.Test.Extensions;
using SR.Bertoni.Test.Models.Task;
using SR.Bertoni.Test.Services.Tasks;
using SR.Bertoni.Test.ViewModels.Base;
using Xamarin.Forms;

namespace SR.Bertoni.Test.ViewModels
{
    class TaskListViewModel : ViewModelBase
    {
        private ITaskService _taskService;

        private ObservableCollection<TaskModel> _taskList;

        public ObservableCollection<TaskModel> TaskList
        {
            get { return _taskList; }
            set
            {
                _taskList = value;
                RaisePropertyChanged(() => TaskList);
            }
        }

        private TaskModel _selectedTask;

        public TaskModel SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                if (_selectedTask != null)
                {
                    SelectTaskAsync(_selectedTask);
                }
                RaisePropertyChanged(() => SelectedTask);
            }
        }

        public ICommand AddTaskCommand => new Command(() => AddTaskAsync());

        private async void AddTaskAsync()
        {
            await NavigationService.NavigateToAsync<TaskDetailViewModel>(null);
        }

        public async Task SelectTaskAsync(TaskModel task)
        {
            if (IsBusy)
            {
                return;
            }
            try
            {
                IsBusy = true;
                await NavigationService.NavigateToAsync<TaskDetailViewModel>(task);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public TaskListViewModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;
            await base.InitializeAsync(null);
            var list = await _taskService.GetTaskList();
            TaskList = list.ToObservableCollection();
            IsBusy = false;
        }
    }
}
