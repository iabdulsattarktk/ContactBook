using ContactBook.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ContactServices>();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors();
app.UseStaticFiles();
app.MapControllers();

app.Run();