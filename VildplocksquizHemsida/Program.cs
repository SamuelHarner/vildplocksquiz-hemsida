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
            new QuizQuestion { Id = 4, ImageUrl = "/images/rödklöver_2.jpg", Answer = "rödklöver", Credit = "Tony Wills", License = "https://creativecommons.org/licenses/by/2.5/"},
            new QuizQuestion { Id = 5, ImageUrl = "/images/bergbräsma_1.jpg", Answer = "bergbräsma", Credit = "Aelwyn", License = "https://creativecommons.org/licenses/by-sa/3.0/"},
            new QuizQuestion { Id = 6, ImageUrl = "/images/bergbräsma_2.jpg", Answer = "bergbräsma", Credit = "Rasbak", License = "https://creativecommons.org/licenses/by-sa/3.0/"},
            new QuizQuestion { Id = 7, ImageUrl = "/images/brännässla_1.jpg", Answer = "brännässla", Credit = "Pokrajac", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
            new QuizQuestion { Id = 8, ImageUrl = "/images/brännässla_2.jpg", Answer = "brännässla", Credit = "Skalle-Per Hedenhös", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
            new QuizQuestion { Id = 9, ImageUrl = "/images/cikoria_1.jpg", Answer = "cikoria", Credit = "Alvesgaspar", License = "https://creativecommons.org/licenses/by/2.5/" },
            new QuizQuestion { Id = 10, ImageUrl = "/images/cikoria_2.jpg", Answer = "cikoria", Credit = "Darkone", License = "https://creativecommons.org/licenses/by-sa/2.0/" },
            new QuizQuestion { Id = 11, ImageUrl = "/images/daggkåpa_1.jpg", Answer = "daggkåpa", Credit = "Michael Gasperl", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
            new QuizQuestion { Id = 12, ImageUrl = "/images/daggkåpa_2.jpg", Answer = "daggkåpa", Credit = "Fidelios", License = "Public Domain" },
            new QuizQuestion { Id = 13, ImageUrl = "/images/fläder_1.jpg", Answer = "fläder", Credit = "Willow", License = "https://creativecommons.org/licenses/by/2.5/" },
            new QuizQuestion { Id = 14, ImageUrl = "/images/fläder_2.jpg", Answer = "fläder", Credit = "Robert Flogaus-Faust", License = "https://creativecommons.org/licenses/by/4.0/" },
            new QuizQuestion { Id = 15, ImageUrl = "/images/gullviva_1.jpg", Answer = "gullviva", Credit = "Holger.Ellgaard", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
            new QuizQuestion { Id = 16, ImageUrl = "/images/gullviva_2.jpg", Answer = "gullviva", Credit = "Sten", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
            new QuizQuestion { Id = 17, ImageUrl = "/images/gökärt_1.jpg", Answer = "gökärt", Credit = "Robert Flogaus-Faust", License = "https://creativecommons.org/licenses/by/4.0/" },
            new QuizQuestion { Id = 18, ImageUrl = "/images/gökärt_2.jpg", Answer = "gökärt", Credit = "Kristian Peters", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
            new QuizQuestion { Id = 19, ImageUrl = "/images/harsyra_1.jpg", Answer = "harsyra", Credit = "Simon Koopmann", License = "https://creativecommons.org/licenses/by-sa/2.0/de/deed.en" },
            new QuizQuestion { Id = 20, ImageUrl = "/images/harsyra_2.jpg", Answer = "harsyra", Credit = "Jörg Hempel", License = "https://creativecommons.org/licenses/by-sa/3.0/de/deed.en" },
            new QuizQuestion { Id = 21, ImageUrl = "/images/humleblomster_1.jpg", Answer = "humleblomster", Credit = "Juan Sanchez", License = "https://creativecommons.org/licenses/by-sa/2.0/" },
            new QuizQuestion { Id = 22, ImageUrl = "/images/humleblomster_2.jpg", Answer = "humleblomster", Credit = "Olivier Pichard", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
            new QuizQuestion { Id = 23, ImageUrl = "/images/hägg_1.jpg", Answer = "hägg", Credit = "Ascilto", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
            new QuizQuestion { Id = 24, ImageUrl = "/images/hägg_2.jpg", Answer = "hägg", Credit = "Rasbak", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
            new QuizQuestion { Id = 25, ImageUrl = "/images/jordreva_1.jpg", Answer = "jordreva", Credit = "Svdmolen", License = "https://creativecommons.org/licenses/by/2.5/" },
            new QuizQuestion { Id = 26, ImageUrl = "/images/jordreva_2.jpg", Answer = "jordreva", Credit = "Rasbak", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
            new QuizQuestion { Id = 27, ImageUrl = "/images/kirskål_1.jpg", Answer = "kirskål", Credit = "Kristian Peters", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
            new QuizQuestion { Id = 28, ImageUrl = "/images/kirskål_2.jpg", Answer = "kirskål", Credit = "Kristian Peters", License = "https://creativecommons.org/licenses/by-sa/3.0/" }
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
