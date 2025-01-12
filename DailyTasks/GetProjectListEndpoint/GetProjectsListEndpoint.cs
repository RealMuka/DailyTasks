using DailyTasks.DataBase.Repositories;
using FastEndpoints;

namespace DailyTasks.API.GetProjectListEndpoint
{
	public class GetProjectsListEndpoint(ProjectRepository repository) : EndpointWithoutRequest
	{
		private readonly ProjectRepository _repository = repository;

		public override void Configure()
		{
			Get("/api/projects/list");
			AllowAnonymous();
		}

		public override async Task HandleAsync(CancellationToken ct)
		{
			await _repository.Get();
		}
	}
}
