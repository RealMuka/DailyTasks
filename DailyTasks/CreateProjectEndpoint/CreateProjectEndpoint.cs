using DailyTasks.DataBase.Repositories;
using FastEndpoints;

namespace DailyTasks.API.CreateProjectEndpoint
{
	public class CreateProjectEndpoint : Endpoint<CreateProjectRequest>
	{
		private readonly ProjectRepository _repository;
		public CreateProjectEndpoint(ProjectRepository projectRepository)
		{
			_repository = projectRepository;
		}

		public override void Configure()
		{
			Post("/api/project/create");
			AllowAnonymous();
		}

		public override async Task HandleAsync(CreateProjectRequest req, CancellationToken ct)
		{
			await _repository.Add(req.Name, req.Description, req.DeadLineTime);

			await SendOkAsync($"Project with name: {req.Name} Created");
		}
	}
}
