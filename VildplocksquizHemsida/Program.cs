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
                new QuizQuestion { Id = 12, ImageUrl = "/images/daggkåpa_2.jpg", Answer = "daggkåpa", Credit = "Fidelios", License = "https://creativecommons.org/public-domain/" },
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
                new QuizQuestion { Id = 28, ImageUrl = "/images/kirskål_2.jpg", Answer = "kirskål", Credit = "Kristian Peters", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 29, ImageUrl = "/images/kärleksört_1.jpg", Answer = "kärleksört", Credit = "Didier Descouens", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
                new QuizQuestion { Id = 30, ImageUrl = "/images/kärleksört_2.jpg", Answer = "kärleksört", Credit = "Bernd Haynold", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 31, ImageUrl = "/images/lomme_1.jpg", Answer = "lomme", Credit = "SaltySemanticSchmuck ", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
                new QuizQuestion { Id = 32, ImageUrl = "/images/lomme_2.jpg", Answer = "lomme", Credit = "Shizhao", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 33, ImageUrl = "/images/luktviol_1.jpg", Answer = "luktviol", Credit = "Strobilomyces", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 34, ImageUrl = "/images/luktviol_2.jpg", Answer = "luktviol", Credit = "Fritz Geller-Grimm", License = "https://creativecommons.org/licenses/by-sa/2.5/" },
                new QuizQuestion { Id = 35, ImageUrl = "/images/löktrav_1.jpg", Answer = "löktrav", Credit = "Ermell", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
                new QuizQuestion { Id = 36, ImageUrl = "/images/löktrav_2.jpg", Answer = "löktrav", Credit = "Didier Descouens", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
                new QuizQuestion { Id = 37, ImageUrl = "/images/myskmadra_1.jpg", Answer = "myskmadra", Credit = "Jopi", License = "https://creativecommons.org/public-domain/" },
                new QuizQuestion { Id = 38, ImageUrl = "/images/myskmadra_2.jpg", Answer = "myskmadra", Credit = "Hajotthu", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 39, ImageUrl = "/images/pepparrot_1.jpg", Answer = "pepparrot", Credit = "Pethan", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 40, ImageUrl = "/images/pepparrot_2.jpg", Answer = "pepparrot", Credit = "Raffi Kojian", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 41, ImageUrl = "/images/pors_1.jpg", Answer = "pors", Credit = "Hajotthu", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 42, ImageUrl = "/images/pors_2.jpg", Answer = "pors", Credit = "Sten", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 43, ImageUrl = "/images/ramslök_1.jpg", Answer = "ramslök", Credit = "Kurt Stüber", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 44, ImageUrl = "/images/ramslök_2.jpg", Answer = "ramslök", Credit = "Rodolph", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 45, ImageUrl = "/images/ryssgubbe_1.jpg", Answer = "ryssgubbe", Credit = "Anneli Salo", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 46, ImageUrl = "/images/ryssgubbe_2.jpg", Answer = "ryssgubbe", Credit = "Olivier Pichard", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 47, ImageUrl = "/images/sommargyllen_1.jpg", Answer = "sommargyllen", Credit = "Didier Descouens", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
                new QuizQuestion { Id = 48, ImageUrl = "/images/sommargyllen_2.jpg", Answer = "sommargyllen", Credit = "Hectonichus", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 49, ImageUrl = "/images/rönn_1.jpg", Answer = "rönn", Credit = "Marcus Bornestav", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 50, ImageUrl = "/images/rönn_2.jpg", Answer = "rönn", Credit = "Martin Olsson", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 51, ImageUrl = "/images/svavelticka_1.jpg", Answer = "svavelticka", Credit = "Shizhao", License = "https://creativecommons.org/licenses/by/2.0/" },
                new QuizQuestion { Id = 52, ImageUrl = "/images/svavelticka_2.jpg", Answer = "svavelticka", Credit = "Per A.J. Andersson", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 53, ImageUrl = "/images/tusensköna_1.jpg", Answer = "tusensköna", Credit = "Jonatan Svensson Glad", License = "https://creativecommons.org/public-domain/" },
                new QuizQuestion { Id = 54, ImageUrl = "/images/tusensköna_2.jpg", Answer = "tusensköna", Credit = "H. Zell", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 55, ImageUrl = "/images/vitplister_1.jpg", Answer = "vitplister", Credit = "Coyau", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 56, ImageUrl = "/images/vitplister_2.jpg", Answer = "vitplister", Credit = "MurielBendel", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
                new QuizQuestion { Id = 57, ImageUrl = "/images/vårlök_1.jpg", Answer = "vårlök", Credit = "Bernd Haynold", License = "https://creativecommons.org/licenses/by/2.5/" },
                new QuizQuestion { Id = 58, ImageUrl = "/images/vårlök_2.jpg", Answer = "vårlök", Credit = "Stefan.lefnaer", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
                new QuizQuestion { Id = 59, ImageUrl = "/images/ängssyra_1.jpg", Answer = "ängssyra", Credit = "Didier Descouens", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
                new QuizQuestion { Id = 60, ImageUrl = "/images/ängssyra_2.jpg", Answer = "ängssyra", Credit = "Vorzinek", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 61, ImageUrl = "/images/gatkamomill_1.jpg", Answer = "gatkamomill", Credit = "Ivar Leidus", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 62, ImageUrl = "/images/gatkamomill_2.jpg", Answer = "gatkamomill", Credit = "Walter Siegmund", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 63, ImageUrl = "/images/groblad_1.jpg", Answer = "groblad", Credit = "Iorsh", License = "https://creativecommons.org/public-domain/" },
                new QuizQuestion { Id = 64, ImageUrl = "/images/groblad_2.jpg", Answer = "groblad", Credit = "Rasbak", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 65, ImageUrl = "/images/hjortron_1.jpg", Answer = "hjortron", Credit = "Moravice", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
                new QuizQuestion { Id = 66, ImageUrl = "/images/hjortron_2.jpg", Answer = "hjortron", Credit = "Philipum", License = "https://creativecommons.org/public-domain/" },
                new QuizQuestion { Id = 67, ImageUrl = "/images/kamomill_1.jpg", Answer = "kamomill", Credit = "H. Zell", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 68, ImageUrl = "/images/kamomill_2.jpg", Answer = "kamomill", Credit = "Rob Hille", License = "https://creativecommons.org/public-domain/" },
                new QuizQuestion { Id = 69, ImageUrl = "/images/kantarell_1.jpg", Answer = "kantarell", Credit = "Strobilomyces", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 70, ImageUrl = "/images/kantarell_2.jpg", Answer = "kantarell", Credit = "Andreas Kunze", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 71, ImageUrl = "/images/mandelkremla_1.jpg", Answer = "mandelkremla", Credit = "Puchatech K.", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 72, ImageUrl = "/images/mjölkört_1.jpg", Answer = "mjölkört", Credit = "kallerna", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 73, ImageUrl = "/images/mjölkört_2.jpg", Answer = "mjölkört", Credit = "Ascilto", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
                new QuizQuestion { Id = 74, ImageUrl = "/images/odon_1.jpg", Answer = "odon", Credit = "David Gaya", License = "https://creativecommons.org/licenses/by-sa/2.5/" },
                new QuizQuestion { Id = 75, ImageUrl = "/images/odon_2.jpg", Answer = "odon", Credit = "Oleg Bor", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
                new QuizQuestion { Id = 76, ImageUrl = "/images/renfana_1.jpg", Answer = "renfana", Credit = "Ivar Leidus", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 77, ImageUrl = "/images/renfana_2.jpg", Answer = "renfana", Credit = "Ivar Leidus", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 78, ImageUrl = "/images/renfana_3.jpg", Answer = "renfana", Credit = "Georg Buzin", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
                new QuizQuestion { Id = 79, ImageUrl = "/images/röllika_1.jpg", Answer = "röllika", Credit = "Ivar Leidus", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 80, ImageUrl = "/images/röllika_2.jpg", Answer = "röllika", Credit = "SAplants", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
                new QuizQuestion { Id = 81, ImageUrl = "/images/röllika_3.jpg", Answer = "röllika", Credit = "TomSmithNP", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
                new QuizQuestion { Id = 82, ImageUrl = "/images/stensopp_1.jpg", Answer = "stensopp", Credit = "Michael Wood", License = "https://creativecommons.org/licenses/by-sa/3.0" },
                new QuizQuestion { Id = 83, ImageUrl = "/images/stensopp_2.jpg", Answer = "stensopp", Credit = "Rob Hille", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 84, ImageUrl = "/images/svart_trumpetsvamp_1.jpg", Answer = "svart trumpetsvamp", Credit = "Wolfgangw", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 85, ImageUrl = "/images/svart_trumpetsvamp_2.jpg", Answer = "svart trumpetsvamp", Credit = "Sarahnphillips", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
                new QuizQuestion { Id = 86, ImageUrl = "/images/älggräs_1.jpg", Answer = "älggräs", Credit = "Ivar Leidus", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 87, ImageUrl = "/images/älggräs_2.jpg", Answer = "älggräs", Credit = "Sten Porse", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 88, ImageUrl = "/images/blek_taggsvamp_1.jpg", Answer = "blek taggsvamp", Credit = "Jean-Pol GRANDMONT", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 89, ImageUrl = "/images/blek_taggsvamp_2.jpg", Answer = "blek taggsvamp", Credit = "Archenzo", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 90, ImageUrl = "/images/blomkålssvamp_1.jpg", Answer = "blomkålssvamp", Credit = "Dominicus Johannes Bergsma", License = "https://creativecommons.org/publicdomain/zero/1.0/deed.en" },
                new QuizQuestion { Id = 91, ImageUrl = "/images/blomkålssvamp_2.jpg", Answer = "blomkålssvamp", Credit = "voir ci-dessous", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 92, ImageUrl = "/images/brunsopp_1.jpg", Answer = "brunsopp", Credit = "Jean-Pol GRANDMONT", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 93, ImageUrl = "/images/brunsopp_2.jpg", Answer = "brunsopp", Credit = "Włodzimierz Wysocki", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 94, ImageUrl = "/images/havtorn_1.jpg", Answer = "havtorn", Credit = "Svdmolen", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 95, ImageUrl = "/images/havtorn_2.jpg", Answer = "havtorn", Credit = "Hans Hillewaert", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 96, ImageUrl = "/images/ostronmussling_1.jpg", Answer = "ostronmussling", Credit = "voir ci-dessous", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 97, ImageUrl = "/images/ostronmussling_2.jpg", Answer = "ostronmussling", Credit = "Ericsteinert", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 98, ImageUrl = "/images/tranbär_1.jpg", Answer = "tranbär", Credit = "Christian Fischer", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 99, ImageUrl = "/images/tranbär_2.jpg", Answer = "tranbär", Credit = "Андрей Перцев 1967", License = "https://creativecommons.org/publicdomain/zero/1.0/deed.en" },
                new QuizQuestion { Id = 100, ImageUrl = "/images/trattkantarell_1.jpg", Answer = "trattkantarell", Credit = "Ripa", License = "https://creativecommons.org/public-domain/" },
                new QuizQuestion { Id = 101, ImageUrl = "/images/trattkantarell_1.jpg", Answer = "trattkantarell", Credit = "Amphis", License = "https://creativecommons.org/public-domain/" },
                new QuizQuestion { Id = 102, ImageUrl = "/images/kråkbär_1.jpg", Answer = "kråkbär", Credit = "Opioła Jerzy", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 103, ImageUrl = "/images/kråkbär_2.jpg", Answer = "kråkbär", Credit = "Opioła Jerzy", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 104, ImageUrl = "/images/stensöta_1.jpg", Answer = "stensöta", Credit = "André Karwath", License = "https://creativecommons.org/licenses/by-sa/2.5/" },
                new QuizQuestion { Id = 105, ImageUrl = "/images/stensöta_2.jpg", Answer = "stensöta", Credit = "Michael Linnenbach", License = "https://creativecommons.org/licenses/by-sa/4.0/" },
                new QuizQuestion { Id = 106, ImageUrl = "/images/vresros_1.jpg", Answer = "vresros", Credit = "Letartean", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 107, ImageUrl = "/images/vresros_2.jpg", Answer = "vresros", Credit = "Miya.m", License = "https://creativecommons.org/licenses/by-sa/3.0/" },
                new QuizQuestion { Id = 108, ImageUrl = "/images/våtarv_1.jpg", Answer = "våtarv", Credit = "Kaldari", License = "https://creativecommons.org/publicdomain/zero/1.0/deed.en" },
                new QuizQuestion { Id = 109, ImageUrl = "/images/våtarv_2.jpg", Answer = "våtarv", Credit = "Rasbak", License = "https://creativecommons.org/licenses/by-sa/3.0/" }
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
