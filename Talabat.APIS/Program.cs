using Microsoft.EntityFrameworkCore;
using Talabat.Core.Repositories;
using Talabat.Repository;
using Talabat.Repository.Data;

namespace Talabat.APIS
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			// api = MC = AddControllers();

			#region CongigerServices
			builder.Services.AddControllers(); // api serives
											   // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			#region Swagger services
			builder.Services.AddEndpointsApiExplorer();// for swagger (serives)
			builder.Services.AddSwaggerGen(); // for swagger (serives)  
			#endregion

			builder.Services.AddDbContext<StoreData>(options => {
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
				
				});
			builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			#endregion

			var app = builder.Build();
			#region UpdateDataBase


			 
			using var scope = app.Services.CreateScope();
			var services = scope.ServiceProvider;
			var loggerfactory = services.GetRequiredService<ILoggerFactory>();
			try
			{
				var dbcontext = services.GetRequiredService<StoreData>(); // ask clr ecplicvity
				await dbcontext.Database.MigrateAsync(); // alpply migrations
				await StoreContextSeed.SeedAsync(dbcontext);
			}
			catch (Exception ex)
			{
				var logger = loggerfactory.CreateLogger<Program>();
				logger.LogError(ex, "Error happend with miggration");

			} 
			#endregion

			// Configure the HTTP request pipeline.
			#region Pipeline Kestrel
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers(); 
			#endregion

			app.Run();
		}
	}
}