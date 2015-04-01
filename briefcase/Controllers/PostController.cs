using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using briefcase.Models;

namespace briefcase.Controllers
{
    public class PostController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            var posts = await Db.Post.ToListAsync();
            return View(posts);
        }

        public async Task<ActionResult> Details(int id)
        {
            var details = await Db.Post.SingleOrDefaultAsync(p => p.Id == id);

            if (details == null)
            {
                return null;
            }

            return View(details);
        }

        public async Task<ActionResult> Create()
        {
            var model = new Post
            {
                Categories = await CategoryLookup()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Post model)
        {
            model.RowCreated = DateTime.UtcNow;
            model.LastModified = DateTime.UtcNow;

            Db.Post.Add(model);
            await Db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            var post = await Db.Post.SingleOrDefaultAsync(p => p.Id == id);

            Db.Post.Remove(post);
            await Db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id = 0)
        {
            var model = await Db.Post.FindAsync(id);

            if (model != null)
            {
                model.Categories = await CategoryLookup();
            }

            return model == null
                ? null
                : View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Post model)
        {
            var post = await Db.Post.SingleOrDefaultAsync(p => p.Id == model.Id);

            post.Title = model.Title;
            post.Content = model.Content;
            post.LastModified = DateTime.UtcNow;
            post.Category.Id = model.Category.Id;

            await Db.SaveChangesAsync();

            return RedirectToAction("Details", new {id = model.Id});
        }

        public async Task<List<Category>> CategoryLookup()
        {
            var categories = await this.Db.Category
                .Take(10)
                .ToListAsync();

            if (!categories.Any())
                return null;

            return categories;
        }
    }
}