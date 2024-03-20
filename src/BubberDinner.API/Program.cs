using BubberDinner.Application;
using BubberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication().AddInfrastructure();
    builder.Services.AddControllers();
};

// Add services to the container.



var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();

}


