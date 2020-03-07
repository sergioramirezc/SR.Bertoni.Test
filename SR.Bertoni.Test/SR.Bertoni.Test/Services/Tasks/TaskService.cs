using SR.Bertoni.Test.Models.Task;
using SR.Bertoni.Test.Repository.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Bertoni.Test.Services.Tasks
{
    public class TaskService : ITaskService
    {
        private TaskRepository _taskRepository;

        public TaskService(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<TaskModel> AddTask(TaskModel task)
        {
            var taskRow = new TaskTable() { Id = task.Id, Name = task.Name, Status = task.Status };
            await _taskRepository.Create(taskRow);
            return task;
        }

        public async Task<bool> DeleteTask(TaskModel task)
        {
            await _taskRepository.Delete(task.Id);
            return true;
        }

        public Task<TaskModel> GetTask(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TaskModel>> GetTaskList()
        {
            var taskRows = await _taskRepository.GetAll();
            var tasks = taskRows.Select(s => new TaskModel() { Id = s.Id, Name = s.Name, Status = s.Status }).ToList();
            return tasks;
        }

        public async Task<bool> UpdateTask(string id, TaskModel task)
        {
            var taskRow = new TaskTable() { Id = task.Id, Name = task.Name, Status = task.Status };
            await _taskRepository.Update(taskRow, id);
            return true;
        }
    }
}
