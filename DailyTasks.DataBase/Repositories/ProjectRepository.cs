using DailyTasks.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
namespace DailyTasks.DataBase.Repositories
{

	public class ProjectRepository(MainDbContext mainDbContext)
	{
		private readonly MainDbContext _db = mainDbContext;

		public async Task<List<string>> Get()
		{
			return await _db.Projects
				.Select(x => x.Name)
				.ToListAsync();
		}

		public async Task Add(string name, string description, DateTime DeadLienTime)
		{
			ProjectEntity project = new ProjectEntity()
			{
				Name = name,
				Description = description,
				CreatedTime = DateTime.UtcNow,
				UpdatedTime = DateTime.UtcNow,
				DeadLineTime = DeadLienTime,
				IsCompleted = false
			};

			await _db.Projects.AddAsync(project);
			await _db.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			await _db.Projects.Where(x => x.Id == id).ExecuteDeleteAsync();
			await _db.SaveChangesAsync();
		}
	}
}
