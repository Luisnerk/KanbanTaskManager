using Kanban.Data;
using Kanban.Interfaces;
using Kanban.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kanban.Extensions;
public static class ApplicationServiceExtension
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration iConfig)
    {
        services.AddControllers();
        services.AddCors(options =>
            {
                options.AddPolicy(name: "CORS_1",
                                    policy =>
                                    {
                                        policy.WithOrigins("http://localhost:4200")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                                    });
            }
        );
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlite(iConfig.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<ITaskCardRepository, TaskCardRepository>();
    }
}