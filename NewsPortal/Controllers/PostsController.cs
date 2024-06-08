using NewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsPortal.Controllers
{
    public class PostsController : Controller
    {
        NewsManvaEntities aDbNewsPortalEntitiesObj = new NewsManvaEntities();
        // GET: Posts
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            Post aTblPosts = aDbNewsPortalEntitiesObj.Posts.FirstOrDefault(d => d.id == id);
            if (aTblPosts != null)
            {
                ViewBag.Title = aTblPosts.title;
                ViewBag.tit = aTblPosts.title;
                ViewBag.Description = aTblPosts.description;
                ViewBag.Category = aTblPosts.Category.name;
                ViewBag.Views = aTblPosts.views;
                ViewBag.RecordDate = aTblPosts.RecordDate;
                ViewBag.Image = "data:image/png;base64," + Convert.ToBase64String(aTblPosts.image, 0, aTblPosts.image.Length);

                
                

                try
                {
                    aTblPosts.views = aTblPosts.views + 1;
                    aDbNewsPortalEntitiesObj.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw ex;
                }
            }

            var rnd = new Random();
            List<Post> aTblPostList = aDbNewsPortalEntitiesObj.Posts.Take(4).ToList();

            ViewBag.rightSideNews = aTblPostList.OrderBy(x => rnd.Next()).ToList();

            return View();
        }
    }
}