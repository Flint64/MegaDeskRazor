using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskRazor.Data;
using MegaDeskRazor.Models;

namespace MegaDeskRazor.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskRazor.Data.MegaDeskRazorContext _context;

        public CreateModel(MegaDeskRazor.Data.MegaDeskRazorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        //ViewData["DeskId"] = new SelectList(_context.Set<Desk>(), "DeskId", "DeskId");
        ViewData["RushOptionId"] = new SelectList(_context.Set<RushOption>(), "RushOptionId", "RushOptionName");
            
        //Added ViewData["NumDrawersId"] but may not be needed
        //ViewData["NumDrawersId"] = new SelectList(_context.Set<NumDrawers>(), "NumDrawersId", "NumberOfDrawers");
            
        ViewData["SurfaceMaterialId"] = new SelectList(_context.Set<SurfaceMaterial>(), "SurfaceMaterialId", "SurfaceMaterialName");
            
            return Page();
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        [BindProperty]
        public Desk Desk { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Save Desk and then save DeskQuote

            _context.Desk.Add(Desk);
            await _context.SaveChangesAsync();

            DeskQuote.DeskId = Desk.DeskId;
            DeskQuote.Desk = Desk;

            DeskQuote.CurrentDate = DateTime.Now;


            //Add CalculatePrice method
            DeskQuote.Price = DeskQuote.GetQuote(_context);


            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
