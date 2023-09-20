using Task.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.GetSection("PlatformSettings").Bind(Constants.settings);

ServiceConfigurator.Configure(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

DefaultFilesOptions DefaultFile = new DefaultFilesOptions();
DefaultFile.DefaultFileNames.Clear();
DefaultFile.DefaultFileNames.Add("Index.html");
app.UseDefaultFiles(DefaultFile);
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

MainWorker.InitializeService();

app.Run();
