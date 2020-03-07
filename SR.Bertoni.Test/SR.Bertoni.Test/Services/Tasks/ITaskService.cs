using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SR.Bertoni.Test.Models.Task;

namespace SR.Bertoni.Test.Services.Tasks
{
    public interface ITaskService
    {
        Task<List<TaskModel>> GetTaskList();
        Task<TaskModel> GetTask(string id);
        Task<TaskModel> AddTask(TaskModel task);
        Task<bool> UpdateTask(string id, TaskModel task);
        Task<bool> DeleteTask(TaskModel task);
    }
}
