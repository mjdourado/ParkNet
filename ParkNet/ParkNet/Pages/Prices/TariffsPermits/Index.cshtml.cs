﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkNet.Data;
using ParkNet.Data.Entities;

namespace ParkNet.Pages.Prices.TariffsPermits;

public class IndexModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public IndexModel(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<TariffPermit> TariffPermit { get;set; } = default!;

    public async Task OnGetAsync()
    {
        TariffPermit = await _context.TariffPermits.ToListAsync();
    }
}
