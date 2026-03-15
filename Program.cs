using ConfigSetting;

var builder = WebApplication.CreateBuilder(args);

//Register options
builder.Services.Configure<MapApiOptions>(
    builder.Configuration.GetSection("MapApiSetting")
);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Optional: only if you are using OpenApi extension
// builder.Services.AddOpenApi();  

var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    // Optional: only if using OpenApi
    // app.MapOpenApi();

    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student API V1");
        c.DocumentTitle = "Student API Docs";
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
        c.InjectStylesheet("/swagger-ui/minimal.css"); 
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();