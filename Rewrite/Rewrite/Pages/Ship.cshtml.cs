using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Rewrite.Pages
{
    public class ShipModel : PageModel
    {
        public string Name { get; set; }
        public void OnGet(int id)
        {
            Ship ship = Ships.ShipList().First(s => s.Id == id);

            Name = ship.Name;
        }
    }
}
