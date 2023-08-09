using System;
using System.Collections.Generic;
using System.Linq;
using Fruitmarket;
using Fruitmarket.WebApp.Dto;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;


namespace Fruitmarket.WebApp.Pages.Markets;

public class Index : PageModel
{
   
    private readonly FruitMarketContext _db;

    public List<Market> Markets { get; private set; }
        = new();


    public Index(FruitMarketContext db)
    {
        _db = db;
    }
    
    // Habe hier statt dem Code hier:   Markets = _db.Markets.ToList();
    public void OnGet()
    {
      Markets = _db.Markets.OrderBy(m => m.Name).ToList();
    }
    
    
    
}