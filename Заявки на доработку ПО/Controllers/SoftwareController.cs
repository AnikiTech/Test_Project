using Заявки_на_доработку_ПО.Classes;

namespace Заявки_на_доработку_ПО.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class SoftwareController : Controller
    {
        private readonly SoftwareTicketsContext _context; 

        public SoftwareController(SoftwareTicketsContext context)
        {
            this._context = context;
        }

        
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            int pageSize = 10;
            var software = this._context.Software.AsQueryable();

            return this.View(await PaginatedList<Software>.CreateAsync(software, pageNumber, pageSize));
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var software = await this._context.Software
                .FirstOrDefaultAsync(m => m.Id == id);
            if (software == null)
            {
                return this.NotFound();
            }

            return this.View(software);
        }

      
        public IActionResult Create()
        {
            return this.View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Название")] Software software)
        {
            if (this.ModelState.IsValid)
            {
                this._context.Add(software);
                await this._context.SaveChangesAsync();
                return this.RedirectToAction(nameof(Index));
            }
            return this.View(software);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var software = await this._context.Software.FindAsync(id);
            if (software == null)
            {
                return this.NotFound();
            }
            return this.View(software);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Название")] Software software)
        {
            if (id != software.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this._context.Update(software);
                    await this._context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.SoftwareExists(software.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return this.RedirectToAction(nameof(Index));
            }
            return this.View(software);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var software = await this._context.Software
                .FirstOrDefaultAsync(m => m.Id == id);
            if (software == null)
            {
                return this.NotFound();
            }

            return this.View(software);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var software = await this._context.Software.FindAsync(id);
            this._context.Software.Remove(software);
            await this._context.SaveChangesAsync();
            return this.RedirectToAction(nameof(Index));
        }


        private bool SoftwareExists(int id)
        {
            return this._context.Software.Any(e => e.Id == id);
        }
    }

}
