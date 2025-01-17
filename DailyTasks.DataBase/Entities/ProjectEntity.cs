using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyTasks.DataBase.Entities
{
	public class ProjectEntity
	{
		[Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

		public string Name { get; set; } = string.Empty;

		public string Description { get; set; } = String.Empty;

		public DateTime CreatedTime { get; set; }

		public DateTime UpdatedTime { get; set; }

		public DateTime DeadLineTime { get; set; }

		public DateTime FinishedTime { get; set; }

		public bool IsCompleted { get; set; }

		public List<TaskEntity> Tasks { get; set; } = new();
	}
}
