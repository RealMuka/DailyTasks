using DailyTasks.DataBase.Configurations;
using DailyTasks.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DailyTasks.DataBase
{
	public class MainDbContext(IConfiguration configuration) : DbContext
	{
		private readonly IConfiguration _configuration = configuration;

		public DbSet<ProjectEntity> Projects { get; set; }
		public DbSet<TaskEntity> Tasks { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseNpgsql(_configuration.GetConnectionString("MainDbContext"));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProjectConfiguration());
			modelBuilder.ApplyConfiguration(new TaskConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}
