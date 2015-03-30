using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using briefcase.Models;

namespace briefcase.Controllers
{
    public class CategoryController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            var categories = await Db.Category.ToListAsync();
            return View(categories);
        }

        public async Task<ActionResult> Details(int id)
        {
            var category = await Db.Category.SingleOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Category model)
        {
            model.RowCreated = DateTime.UtcNow;
            model.RowModified = DateTime.UtcNow;

            Db.Category.Add(model);
            await Db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var category = await Db.Category.SingleOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return HttpNotFound();
            }

            Db.Category.Remove(category);
            await Db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id = 0)
        {
            var model = await Db.Category.FindAsync(id);

            return model == null
                ? null
                : View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Category model)
        {
            var category = await Db.Category.SingleOrDefaultAsync(c => c.Id == model.Id);

            category.Title = model.Title;
            category.Description = model.Description;
            category.RowModified = DateTime.UtcNow;

            await Db.SaveChangesAsync();

            return RedirectToAction("Details", new { id = model.Id });
        }
    }
}