using AdminPortal;
using AdminPortal.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "corsPolicy",
    b =>
    {
        b.WithOrigins("https://localhost:44458","https://localhost:7032", "https://code-red-tasks.azurewebsites.net")
            .WithHeaders("Origin")
            .WithMethods("GET");
    });
});
builder.Services.AddSingleton<IMongoRepo>(
    new MongoRepo(
        builder.Configuration.GetSection("CodeRedDatabase")["ConnectionString"],
        builder.Configuration.GetSection("CodeRedDatabase")["DatabaseName"]
    )
);
builder.Services.AddSingleton(typeof(IMongoService<,>), typeof(MongoService<,>));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors("corsPolicy");
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();
