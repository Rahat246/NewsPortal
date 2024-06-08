using NewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsPortal.Controllers
{
    public class CategoryController : Controller
    {
        NewsManvaEntities aDbNewsPortalEntitiesObj = new NewsManvaEntities();
        // GET: Category
        public ActionResult Index()
        {
            Dictionary<string, List<byte[]>> lastImagesByCategory = new Dictionary<string, List<byte[]>>();

            // Fetch last 5 images for each category
            foreach (var category in aDbNewsPortalEntitiesObj.Categories)
            {
                var lastImages = aDbNewsPortalEntitiesObj.Posts
                    .Where(p => p.category_id == category.id && p.status == 1)
                    .OrderByDescending(p => p.id)
                    .Take(5)
                    .Select(p => p.image)
                    .ToList();

                lastImagesByCategory.Add(category.name, lastImages);
            }

            return View();
        }

        public ActionResult Bangladesh()
        {
            int categoryId = 1;
            LoadNews(categoryId);

            return View();
        }

        public ActionResult World()
        {
            int categoryId = 2;
            LoadNews(categoryId);

            return View();
        }

        private void LoadNews(int categoryId)
        {
            List<Post> aTblPostList = aDbNewsPortalEntitiesObj.Posts.Where(d => d.category_id == categoryId && d.status == 1).ToList();
            if (aTblPostList.Count > 0)
            {
                ViewBag.PostList = aTblPostList;
                ViewBag.LastPost = aTblPostList[0];
                ViewBag.LastPostImage = "data:image/png;base64," + Convert.ToBase64String(aTblPostList[0].image, 0, aTblPostList[0].image.Length);

                var rnd = new Random();
                ViewBag.rightSideNews = aTblPostList.OrderBy(x => rnd.Next()).ToList();

                int numberOfCharacters = 300;
                string slug = aTblPostList[0].slug.Length > numberOfCharacters
                    ? aTblPostList[0].slug.Substring(0, numberOfCharacters) + "..."
                    : aTblPostList[0].slug;

                ViewBag.Slug = slug;
            }
        }

        public ActionResult Health()
        {
            int categoryId = 3;
            LoadNews(categoryId);

            return View();
        }

        public ActionResult Business()
        {
            int categoryId = 4;
            LoadNews(categoryId);

            return View();
        }

        public ActionResult Education()
        {
            int categoryId = 5;
            LoadNews(categoryId);

            return View();
        }

        public ActionResult Entertainment()
        {
            int categoryId = 6;
            LoadNews(categoryId);

            return View();
        }

        public ActionResult Technology()
        {
            int categoryId = 8;
            LoadNews(categoryId);

            return View();
        }

        public ActionResult Sports()
        {
            int categoryId = 7;
            LoadNews(categoryId);

            return View();
        }

        public ActionResult Career()
        {
            int categoryId = 9;
            LoadNews(categoryId);

            return View();
        }

        public ActionResult Horoscope()
        {
            int categoryId = 10;
            LoadNews(categoryId);

            return View();
        }

        public ActionResult ShareMarket()
        {
            int categoryId = 11;
            LoadNews(categoryId);

            return View();
        }
    }
}