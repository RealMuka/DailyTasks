using DailyTasks.DataBase.Entities;

namespace DailyTasks.API.GetProjectListEndpoint
{
	public class GetProjectsListResponse
	{
		public List<ProjectEntity> Projects { get; set; }
	}
}
