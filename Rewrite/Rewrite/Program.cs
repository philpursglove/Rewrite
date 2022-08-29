using Microsoft.AspNetCore.Rewrite;
using Rewrite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

var options = new RewriteOptions()
    .Add(new ShipRule());

app.UseRewriter(options);

app.MapRazorPages();

app.Run();


public class ShipRule : IRule
{
    public void ApplyRule(RewriteContext context)
    {
        var request = context.HttpContext.Request;

        if (request.Path.Value != null &&
            request.Path.Value.StartsWith("/Ship", StringComparison.InvariantCultureIgnoreCase))
        {
            string path = request.Path.Value;

            string slug = path.Substring(path.LastIndexOf("/") + 1).ToLower();

            Ship ship = Ships.ShipList().First(s => s.Slug == slug);

            request.Path = "/Ship";
            request.QueryString = new QueryString($"?id={ship.Id}");

            context.Result = RuleResult.SkipRemainingRules;


        }
    }
}