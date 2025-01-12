using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DailyTasks.DataBase.Entities
{
	public class TaskEntity
	{
		[Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int Id { get; set; }

		public string Name { get; set; } = String.Empty;

		public string Description { get; set; } = String.Empty;

		public DateTime CreatedTime { get; set; }

		public DateTime UpdatedTime { get; set; }

		public DateTime DeadLine { get; set; }

		public DateTime CompleteTime { get; set; }

		public bool IsCompleted { get; set; }

		public ProjectEntity? Project { get; set; }

		public int ProjectId { get; set; }
	}
}
