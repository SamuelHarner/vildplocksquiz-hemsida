using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using VildplocksquizHemsida.Data;
using VildplocksquizHemsida.Models; // Add this using directive
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("QuizDb"));

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
    if (!context.QuizQuestions.Any())
    {
        context.QuizQuestions.AddRange(
            new QuizQuestion { Id = 1, ImageUrl = "/images/maskros_1.jpg", Answer = "maskros", Credit = "David Monniaux", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
            new QuizQuestion { Id = 2, ImageUrl = "/images/maskros_2.jpg", Answer = "maskros", Credit = "Green Yoshi", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
            new QuizQuestion { Id = 3, ImageUrl = "/images/rödklöver_1.jpg", Answer = "rödklöver", Credit = "Ivar Leidus", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
            new QuizQuestion { Id = 4, ImageUrl = "/images/rödklöver_2.jpg", Answer = "rödklöver", Credit = "Tony Wills", License = "https://creativecommons.org/licenses/by/2.5/"}
        );
        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Quiz}/{action=Index}/{id?}");

app.Run();
