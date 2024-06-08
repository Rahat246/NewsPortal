using NewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NewsPortal.Controllers
{
    public class IndexController : Controller
    {
        NewsManvaEntities aDbNewsPortalEntitiesObj = new NewsManvaEntities();
        // GET: Index
        public ActionResult Index()
        {
            List<Post> aTblPostList = new List<Post>();
            aTblPostList = aDbNewsPortalEntitiesObj.Posts.ToList();

            var rnd = new Random();
            var mainNews = aTblPostList.FirstOrDefault(d => d.status == 1 && d.main_news == true);
            var subNews = aTblPostList.OrderBy(x => rnd.Next()).FirstOrDefault(d => d.status == 1 && d.main_news == false);
            var exclusiveNews = aTblPostList.OrderBy(x => rnd.Next()).FirstOrDefault(d => d.status == 1 && d.exclusive_news == true);
            var groupedImages = aTblPostList.GroupBy(img => img.Category);
            var postByViews = aTblPostList.OrderByDescending(p => p.views) .Take(8).ToList();
            var category_id = aTblPostList.OrderBy(x => rnd.Next()).FirstOrDefault(d => d.status == 1);



            // Get the first 300 characters
            int numberOfCharacters = 300;
            string slug = mainNews.slug.Length > numberOfCharacters
                ? mainNews.slug.Substring(0, numberOfCharacters) + "..."
                : mainNews.slug;

            string categoryslug = category_id.slug.Length > numberOfCharacters
                ? category_id.slug.Substring(0, numberOfCharacters) + "..."
                : category_id.slug;

            string slugExclusiveNews = exclusiveNews.slug.Length > numberOfCharacters
                ? exclusiveNews.slug.Substring(0, numberOfCharacters) + "..."
                : exclusiveNews.slug;

            int subNumberOfCharacters = 135;
            string subSlug = subNews.slug.Length > subNumberOfCharacters
                ? subNews.slug.Substring(0, subNumberOfCharacters) + "..."
                : subNews.slug;

            ViewBag.Image = "data:image/png;base64," + Convert.ToBase64String(mainNews.image, 0, mainNews.image.Length);
            ViewBag.SubImage = "data:image/png;base64," + Convert.ToBase64String(subNews.image, 0, subNews.image.Length);
            ViewBag.ExclusiveNewsImage = "data:image/png;base64," + Convert.ToBase64String(exclusiveNews.image, 0, exclusiveNews.image.Length);
            ViewBag.groupImages = "data:image/png;base64," + Convert.ToBase64String(exclusiveNews.image, 0, exclusiveNews.image.Length);
            


            ViewBag.MainNews = mainNews;
            ViewBag.ExclusiveNews = exclusiveNews;
            ViewBag.Slug = slug;

            ViewBag.SubNews = subNews;
            ViewBag.SubSlug = subSlug;
            ViewBag.SlugExclusiveNews = slugExclusiveNews;

            ViewBag.PostList = aTblPostList.ToList();
            ViewBag.rightSideNews = aTblPostList.OrderBy(x => rnd.Next()).Take(4).ToList();

            ViewBag.LifeStyleNews = aTblPostList.Where(d => d.category_id == 6 || d.category_id == 8).OrderBy(x => rnd.Next()).Take(4).ToList();
            ViewBag.LifeStyleNewsimg = aTblPostList.Where(d => d.category_id == 6 || d.category_id == 8).OrderByDescending(x => rnd.Next()).Take(1).ToList();


            ViewBag.sports = aTblPostList.Where(d => d.category_id == 7).OrderBy(x => rnd.Next()).ToList();
            ViewBag.sportsimg = aTblPostList.Where(d => d.category_id == 7).OrderByDescending(x => rnd.Next()).Take(1).ToList();

            ViewBag.entertaintment = aTblPostList.Where(d => d.category_id == 6).OrderBy(x => rnd.Next()).ToList();
            ViewBag.entertaintmentimg = aTblPostList.Where(d => d.category_id == 6).OrderByDescending(x =>rnd.Next()).Take(1).ToList();

            ViewBag.politics = aTblPostList.Where(d => d.category_id == 1).OrderBy(x => rnd.Next()).ToList();
            ViewBag.politicsimg = aTblPostList.Where(d => d.category_id == 1).OrderByDescending(x => rnd.Next()).Take(1).ToList();

            ViewBag.technology = aTblPostList.Where(d => d.category_id == 8).OrderBy(x => rnd.Next()).ToList();
            ViewBag.technologyimg = aTblPostList.Where(d => d.category_id == 8).OrderByDescending(x => rnd.Next()).Take(1).ToList();


            ViewBag.galleryimg = aTblPostList.OrderByDescending(x => rnd.Next()).Take(6).ToList();
            ViewBag.sportimg = aTblPostList.Where(d => d.category_id == 7).OrderByDescending(x => rnd.Next()).Take(1).ToList();
            ViewBag.LifeNewsimg = aTblPostList.Where(d => d.category_id == 6 || d.category_id == 8).OrderByDescending(x => rnd.Next()).Take(1).ToList();

            ViewBag.postByViews = postByViews;

            Session["PostId"] = mainNews.id;


            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Detail()
        {
            return View();
        }

        public ActionResult Sports()
        {
            return View();
        }

        public ActionResult Health()
        {
            return View();
        }

        public ActionResult Video()
        {
            return View();
        }

        public ActionResult Functionprogram()
        {
            return View();
        }

        public ActionResult Business()
        {
            return View();
        }
    }
}