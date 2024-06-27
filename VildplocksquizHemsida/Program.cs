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
            new QuizQuestion { Id = 1, ImageUrl = "/images/maskros_1.jpg", Answer = "maskros" },
            new QuizQuestion { Id = 2, ImageUrl = "/images/maskros_2.jpg", Answer = "maskros" },
            new QuizQuestion { Id = 3, ImageUrl = "/images/rödklöver_1.jpg", Answer = "rödklöver" },
            new QuizQuestion { Id = 4, ImageUrl = "/images/rödklöver_2.jpg", Answer = "rödklöver" },
            new QuizQuestion { Id = 5, ImageUrl = "/images/daggkåpa_1.jpg", Answer = "daggkåpa" },
            new QuizQuestion { Id = 6, ImageUrl = "/images/daggkåpa_2.jpg", Answer = "daggkåpa" },
            new QuizQuestion { Id = 7, ImageUrl = "/images/stensopp_1.jpg", Answer = "stensopp" },
            new QuizQuestion { Id = 8, ImageUrl = "/images/stensopp_2.jpg", Answer = "stensopp" },
            new QuizQuestion { Id = 9, ImageUrl = "/images/kantarell_1.jpg", Answer = "kantarell" }
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
