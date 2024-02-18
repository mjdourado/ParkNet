﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkNet.Data;
using ParkNet.Data.Entities;

namespace ParkNet.Pages.Prices.TariffsPermits;

[Authorize]
public class CreateModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public CreateModel(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public TariffPermit TariffPermit { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.TariffPermits.Add(TariffPermit);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
