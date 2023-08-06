using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Fruitmarket.WebApp.Pages.Markets;

public class DetailsModel : PageModel
{
    
    
    private readonly FruitMarketContext _db;

    public DetailsModel(FruitMarketContext db)
    {
        _db = db;
    }

    public Product Product { get; private set; } = default!;

    public IActionResult OnGet(Guid guid)
    {
        var product = _db.Products
            .Include(p => p._fruitsandvegetables)
            .ThenInclude(fv => fv._order)
            .FirstOrDefault(p => p.Guid == guid);
            
        
        if (product == null)
        {
            return RedirectToPage("/Products/Index");
        }

        Product = product;

        return Page();
    }
}