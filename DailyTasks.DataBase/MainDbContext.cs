using DailyTasks.DataBase.Configurations;
using DailyTasks.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyTasks.DataBase
{
	public class MainDbContext(DbContextOptions<MainDbContext> options) : DbContext(options)
	{
		public DbSet<ProjectEntity> Projects { get; set; }
		public DbSet<TaskEntity> Tasks { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProjectConfiguration());
			modelBuilder.ApplyConfiguration(new TaskConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}
