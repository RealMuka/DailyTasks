using System.Threading.Tasks;
using DailyTasks.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DailyTasks.DataBase.Configurations
{
	public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
	{
		public void Configure(EntityTypeBuilder<TaskEntity> builder)
		{
			builder.HasIndex(t => t.Id);

			builder.HasOne(x => x.Project)
				.WithMany(x => x.Tasks);
		}
	}
}
