using System.Data;
using System.Runtime.InteropServices.JavaScript;
using Movies.API.Midlewares;
using Movies.Application.Abstractions;
using Movies.Application.Common.Commands.Genres;
using Movies.Application.Mapping;
using Movies.Application.Services;
using Movies.Persistence.Common.Commands.Genres;
using Movies.Persistence.Migrations;
using Npgsql;



public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        
        var needCommitMigrations = builder.Configuration.GetValue<Boolean>("NeedCommitMigrations");
        if (needCommitMigrations)
        {
            Migration migration = new Migration(builder.Configuration);
            migration.DoMigrations();
        }
        
        
        

        builder.Services.AddControllers();

        builder.Services.AddScoped<IDbConnection>(_ =>
        {
            var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");
            return new NpgsqlConnection(connectionString);
        });

        builder.Services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(typeof(CreateGenreHandler).Assembly, 
                typeof(CreateGenreCommand).Assembly));

        builder.Services.AddScoped<IGenresService, GenresService>();
        builder.Services.AddScoped<IDirectorsService, DirectorsService>();
        builder.Services.AddScoped<IMoviesService, MoviesService>();

        builder.Services.AddAutoMapper(typeof(GenresMappingProfile).Assembly);


        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();


        builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
        
        

        var app = builder.Build();



        app.MapControllers();

        app.UseExceptionHandler();

        app.UseRouting();
        app.Run();
    }
}
