using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ScheduleReminderApp.DAL;
using ScheduleReminderApp.Interceptors;
using ScheduleReminderApp.Repositories.Abstraction;
using ScheduleReminderApp.Repositories.Implementation;
using ScheduleReminderApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
                   .AddFluentValidation(x => {
                       x.ImplicitlyValidateChildProperties = true;
                       x.ImplicitlyValidateRootCollectionElements = true;
                       x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                   });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<AuditableEntitySaveChangesInterceptor>();
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IDateTime, DateTimeService>();
builder.Services.AddTransient<IReminderRepository, ReminderRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

