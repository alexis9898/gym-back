using BLL.Interface;
using BLL.Mapper;
using BLL.Service;
using DAL.Data;
using DAL.Interface;
using DAL.Repository;
using Jym_back.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(op =>
{
    op.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDataContext>(op=>op.UseSqlServer(builder.Configuration.GetConnectionString("AppDB")));
builder.Services.AddAutoMapper(typeof(AppMapper));

builder.Services.AddScoped<IMuscleRepository,MuscleRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IExerciseMuscleRepository, ExerciseMuscleRepository>();
builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();
builder.Services.AddScoped<IWorkoutMuscleRepository, WorkoutMuscleRepository>();
builder.Services.AddScoped<IWorkoutExerciseRepository,WorkoutExerciseRepository>();
builder.Services.AddScoped<ISetRepository, SetRepository>();

builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IMuscleService, MuscleService>();
builder.Services.AddScoped<IExerciseMuscleService, ExerciseMuscleService>();
builder.Services.AddScoped<IWorkoutService, WorkoutService>();
builder.Services.AddScoped<IWorkoutMuscleService, WorkoutMuscleService>();
builder.Services.AddScoped<IWorkoutExerciseService, WorkoutExerciseService>();
builder.Services.AddScoped<ISetService, SetService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();


app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
