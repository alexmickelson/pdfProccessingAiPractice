using DotNetEnv;
using Web.Components;

Env.Load();

string key = Environment.GetEnvironmentVariable("AZURE_DI_KEY") ?? throw new Exception("AZURE_DI_KEY not set");
string endpoint = Environment.GetEnvironmentVariable("AZURE_DI_URL") ?? throw new Exception("AZURE_DI_URL not set");
    var ollamaUrl = Environment.GetEnvironmentVariable("OLLAMA_URL") ?? throw new Exception("OLLAMA_URL not set");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
