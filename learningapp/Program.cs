var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
// builder.Configuration.AddAzureAppConfiguration("Endpoint=https://appconfig1144.azconfig.io;Id=kE11;Secret=9lytouyB6rPwp1f71NJcNScFgyqEk2UlCXcGXua1rje7knw93e5zJQQJ99BBACi5YpzYBIbuAAABAZAC31cp");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
