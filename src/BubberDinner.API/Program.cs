using BubberDinner.API.Common.Errors;
using BubberDinner.Application;
using BubberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
  
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, ServerProblemDetailsFactory>();
};

// Add services to the container.



var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();

}


