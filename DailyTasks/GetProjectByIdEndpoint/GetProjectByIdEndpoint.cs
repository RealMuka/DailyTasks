using DailyTasks.DataBase.Entities;
using DailyTasks.DataBase.Repositories;
using FastEndpoints;

namespace DailyTasks.API.GetProjectByIdEndpoint
{
		public class GetProjectByIdEndpoint(ProjectRepository projectRepository) : EndpointWithoutRequest<GetProjectByIdResponse>
		{
			private readonly ProjectRepository _projectRepository = projectRepository;

			public override void Configure()
			{
				Get("/api/projects/{id}");
				AllowAnonymous();
			}

			public override async Task HandleAsync(CancellationToken ct)
			{
				int id = Route<int>("id");

				var project = await _projectRepository.GetById(id);

				if(project != null)
				{
					await SendAsync(new GetProjectByIdResponse
					{
						Project = project
					});
				}
				else
				{
					await SendStringAsync("Project id is invalid");
				}
			}
		}
}
