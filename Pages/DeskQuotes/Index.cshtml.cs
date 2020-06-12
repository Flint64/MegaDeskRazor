using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazor.Data;
using MegaDeskRazor.Models;
using MegaDeskRazor.Pages;

namespace MegaDeskRazor.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskRazor.Data.MegaDeskRazorContext _context;

        public IndexModel(MegaDeskRazor.Data.MegaDeskRazorContext context)
        {
            _context = context;
        }
        public IList<DeskQuote> DeskQuote { get;set; }
        
        //Sort By
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }


        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            //IQueryable<string> bookQuery = from m in _context.DeskQuote
            //                               orderby m.CurrentDate
            //                               select m.CurrentDate;

            var deskquotes = from m in _context.DeskQuote
                             select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                deskquotes = deskquotes.Where(s => s.CustomerName.Contains(SearchString));
            }

            //if (!string.IsNullOrEmpty(ScriptureBook))
            //{
            //    deskquotes = deskquotes.Where(x => x.Book == ScriptureBook);
            //}

            if (!string.IsNullOrEmpty(SortBy))
            {
                if (SortBy == "Name")
                {
                    deskquotes = deskquotes.OrderBy(o => o.CustomerName);
                }
                else if (SortBy == "DateCreated")
                {
                    deskquotes = deskquotes.OrderBy(o => o.CurrentDate);
                }
            }

            //Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            DeskQuote = await deskquotes.ToListAsync();

            //This displays the RushOptionName on the index page.
            DeskQuote = await _context.DeskQuote
                .Include(d => d.Desk)
                .Include(d => d.RushOption).ToListAsync();
        }
    }
}
