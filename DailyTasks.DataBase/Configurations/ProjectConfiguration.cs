using DailyTasks.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTasks.DataBase.Configurations
{
	public class ProjectConfiguration : IEntityTypeConfiguration<ProjectEntity>
	{
		public void Configure(EntityTypeBuilder<ProjectEntity> builder)
		{
			builder.HasIndex(x => x.Id);

			builder.HasMany(x => x.Tasks)
				.WithOne(x => x.Project)
				.HasForeignKey(x => x.ProjectId);
		}
	}
}
