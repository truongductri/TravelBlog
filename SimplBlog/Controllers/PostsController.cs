using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimplBlog.Models;
using SimplBlog.Repository;
using SimplBlog.ViewModels;
using SimplBlog.Services;

namespace SimplBlog.Controllers
{
    
    public class PostsController : Controller
    {
        private readonly BloggingContext _context;
        private readonly IPostRepo _postRepo;
        private readonly ICommonService _commonService;

        public PostsController(BloggingContext context,ICommonService commonService, IPostRepo postRepo)
        {
            _context = context;
            _postRepo = postRepo;
            _commonService = commonService;
        }

        // GET: Posts
        [Route("posts")]
        [Route("posts/{page}")]
        public IActionResult Index(int page = 1)

        {
            if (page < 1) page = 1;
            var vm = new PostsPageViewModel();
            var queryParams = new QueryParams()
            {
                CurrentPage = page-1,
                PageItems = 2
            };
            vm.ListPost = _commonService.FindAll<Post>(queryParams); 
            vm.ListPost.PagingBaseUrl = RouteHelper.LinkPosts(true);
            return View(vm);
        }

        // GET: Posts/Details/5
        public IActionResult Details(int? id)
        {
            var post = _postRepo.GetDetailPost(id);
            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,Title,ShortDescription,Description,Meta,Url,Published,PostedOn,Modified,ImagePath")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.SingleOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,Title,ShortDescription,Description,Meta,Url,Published,PostedOn,Modified,ImagePath")] Post post)
        {
            if (id != post.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .SingleOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Posts.SingleOrDefaultAsync(m => m.PostId == id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.PostId == id);
        }
    }
}
