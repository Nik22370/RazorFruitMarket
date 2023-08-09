using System;
using System.Diagnostics;
using System.Linq;
using Bogus.DataSets;
using Fruitmarket.WebApp.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fruitmarket.WebApp.Pages;

public class Edit : PageModel
{


    private readonly FruitMarketContext _db;

    public Edit(FruitMarketContext db)
    {
        _db = db;
    }

    
    [BindProperty]
    public ProductDto Product { get; set; } = null!;

    public IActionResult OnPost(Guid guid)
    {
        return Page();
    }

    public IActionResult OnGet(Guid guid)
    {
        var product = _db.Products
            
            .FirstOrDefault(p => p.Guid == guid);
            
        
        if (product is null)
        {
            return RedirectToPage("/Products/Index");
        }
        

        Product = new ProductDto(
        Guid: product.Guid,
        Name: product.Name,
        Price: product.Price
                
        );

        return Page();
    }
}