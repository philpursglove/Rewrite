using Microsoft.AspNetCore.Rewrite;

namespace Rewrite.RewriteRules;

public class ShipRule : IRule
{
    public ShipRule()
    {
        // Only runs at startup so db searches have to be done in ApplyRule
    }

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