using DailyTasks.DataBase.Entities;
using System;

namespace DailyTasks.API.CreateTaskEndpoint
{
	public class TaskCreateRequest
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public DateTime DeadLine { get; set; }

		public int ProjectId { get; set; }
	}
}
