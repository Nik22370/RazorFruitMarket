using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Fruitmarket.WebApp.Pages.Markets;

public class DetailsModel : PageModel
{
    private readonly FruitMarketContext _db;
    public List<Product> Products { get; private set; } = new();
    public Market? Market { get; private set;}

    public DetailsModel(FruitMarketContext db)
    {
        _db = db;
    }
    
    public IActionResult OnGet(Guid guid)
    {
        var market = _db.Markets
            .FirstOrDefault(m => m.Guid == guid);
        
        if (market == null)
        {
            return RedirectToPage("/Markets/Index");
        }

        Market = market;
        Products = _db.Products.Where(p =>p.MarketId == market.Id).ToList();

        return Page();
           
       
    }
    

    public Product Product { get; private set; } = default!;

    
}