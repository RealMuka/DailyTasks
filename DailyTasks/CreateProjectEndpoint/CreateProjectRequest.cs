namespace DailyTasks.API.CreateProjectEndpoint
{
	public class CreateProjectRequest
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public DateTime DeadLineTime { get; set; }
	}
}
