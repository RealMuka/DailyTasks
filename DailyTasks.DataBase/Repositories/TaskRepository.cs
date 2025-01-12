using DailyTasks.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyTasks.DataBase.Repositories
{
	public class TaskRepository(MainDbContext db)
	{
		readonly MainDbContext _db = db;

		public async Task Add(string name, string description, DateTime deadLine, int projectId)
		{
			ProjectEntity? project = await _db.Projects
				.FirstOrDefaultAsync(p => p.Id == projectId);

			var task = new TaskEntity
			{
				Name = name,
				Description = description,
				CreatedTime = DateTime.UtcNow,
				UpdatedTime = DateTime.UtcNow,
				DeadLine = deadLine,
				Project = project,
				ProjectId = project.Id,
				IsCompleted = false
			};

			await _db.Tasks.AddAsync(task);
			await _db.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			await _db.Tasks.Where(t => t.Id == id).ExecuteDeleteAsync();
			await _db.SaveChangesAsync();
		}

		public async Task Change(int id, string name, string description, bool isCompleted)
		{
			await _db.Tasks.Where(c => c.Id == id)
				.ExecuteUpdateAsync(c =>
					c.SetProperty(s => s.Name, name)
					.SetProperty(s => s.Description, description)
					.SetProperty(s => s.IsCompleted, isCompleted));

			await _db.SaveChangesAsync();
		}

		public async Task<TaskEntity?> GetById(int id)
		{
			return await _db.Tasks
				.AsNoTracking()
				.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<List<TaskEntity>> GetByName(string name)
		{
			return await _db.Tasks
				.AsNoTracking()
				.Where(x => x.Name == name)
				.ToListAsync();
		}
	}
}
