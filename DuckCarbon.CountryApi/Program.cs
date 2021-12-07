using Microsoft.OpenApi.Models;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

var builder = WebApplication.CreateBuilder(args);

// Console.WriteLine($"ConnectionString:SafeTravel: [{config["ConnectionStrings:SafeTravel"]}]");
// Swagger:OpenApiInfo -- mongoDb:safeTravel
OpenApiInfo openApiInfo = builder.Configuration.GetSection("Swagger:OpenApiInfo").Get<OpenApiInfo>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(openApiInfo.Version, openApiInfo);

    // options.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");
    // options.OrderActionsBy((desc) => {});
});

// builder.Services.AddScoped<CountryService>();

builder.Host.UseSerilog((hostBuilderContext, loggerConfiguration) =>
{
    loggerConfiguration.ReadFrom.Configuration(hostBuilderContext.Configuration);
});


using (var app = builder.Build())
{
    ILogger log = app.Services.GetRequiredService<ILogger<Program>>();

    log.LogInformation("Application start");

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint($"/swagger/{openApiInfo.Version}/swagger.json", $"{openApiInfo.Title} {openApiInfo.Version}"); 
        });

        log.LogInformation("Development environment");
    }
    else
    {
        log.LogInformation("Other environment");

        // app.UseExceptionHandler()
        // app.UseHsts();
        // app.UseCors();

        // app.UseHttpsRedirection();
        // app.UseStaticFiles();

        // Add this line; you'll need `using Serilog;` up the top, too
        //app.UseSerilogRequestLogging();
    }

    app.MapGet("/", () => "Hello World!");

    app.Run();

}
