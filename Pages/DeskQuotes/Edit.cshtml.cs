﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazor.Data;
using MegaDeskRazor.Models;

namespace MegaDeskRazor.Pages.DeskQuotes
{
    public class EditModel : PageModel
    {

        private int? id;

        private readonly MegaDeskRazor.Data.MegaDeskRazorContext _context;

        public EditModel(MegaDeskRazor.Data.MegaDeskRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        [BindProperty]
        public Desk Desk { get; set; }
        [BindProperty]
        public NumDrawers NumDrawers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            this.id = id;

            if (id == null)
            {
                return NotFound();
            }

            DeskQuote = await _context.DeskQuote
                .Include(d => d.Desk)
                .Include(d => d.RushOption).FirstOrDefaultAsync(m => m.DeskQuoteId == id);

            if (DeskQuote == null)
            {
                return NotFound();
            }
           ViewData["DeskId"] = new SelectList(_context.Set<Desk>(), "DeskId", "DeskId");
           ViewData["RushOptionId"] = new SelectList(_context.Set<RushOption>(), "RushOptionId", "RushOptionName");
           ViewData["NumDrawersId"] = new SelectList(_context.Set<NumDrawers>(), "NumDrawersId", "NumberOfDrawers");
            ViewData["SurfaceMaterialId"] = new SelectList(_context.Set<SurfaceMaterial>(), "SurfaceMaterialId", "SurfaceMaterialName");
           //ViewData["DeskQuote"] = new SelectList(_context.Set<Desk>(), "Depth", "Depth");
           // ViewData["DeskQuote"] = new SelectList(_context.Set<Desk>(), "Width", "Width");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
                //return await this.OnGetAsync(this.id);

                //return RedirectToPage("./DeskQuotes/Edit");
                

            }
            
            
            //DeskQuote.Price = DeskQuote.GetQuote(_context);
            _context.Attach(DeskQuote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskQuoteExists(DeskQuote.DeskQuoteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return RedirectToPage("./Index");
        }

        private bool DeskQuoteExists(int id)
        {
            return _context.DeskQuote.Any(e => e.DeskQuoteId == id);
        }
    }
}
