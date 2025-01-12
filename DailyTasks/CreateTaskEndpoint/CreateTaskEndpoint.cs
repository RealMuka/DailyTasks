using System.Threading;
using System.Threading.Tasks;
using DailyTasks.DataBase;
using DailyTasks.DataBase.Entities;
using DailyTasks.DataBase.Repositories;
using FastEndpoints;

namespace DailyTasks.API.CreateTaskEndpoint
{
	public class CreateTaskEndpoint(TaskRepository taskRepository) : Endpoint<TaskCreateRequest>
	{
		private readonly TaskRepository _taskRepository = taskRepository;
		public override void Configure()
		{
			Post("/api/task/create");
			AllowAnonymous();
		}

		public override async Task HandleAsync(TaskCreateRequest req, CancellationToken ct)
		{
			await _taskRepository.Add(req.Name, req.Description, req.DeadLine, req.ProjectId);
		}
	}
}
