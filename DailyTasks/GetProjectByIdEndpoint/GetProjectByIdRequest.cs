using Microsoft.AspNetCore.Mvc;

namespace DailyTasks.API.GetProjectByIdEndpoint
{
	public class GetProjectByIdRequest
	{
		[FromRoute]public int Id { get; set; }
	}
}
