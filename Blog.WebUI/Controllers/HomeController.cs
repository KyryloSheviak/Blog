using Blog.Domain.Repository;
using System.Web.Mvc;
using System.Linq;
using Blog.Domain;
using Blog.Domain.Entities;

namespace Blog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext blogContext = new BlogContext("BlogContext");
        private DbOperations dbOperations = new DbOperations();
        private const int NUM = 10;
        public ActionResult Index()
        {
            var news = blogContext.News.Where(p => !p.IsDelete).OrderByDescending(n => n.Id);
            foreach (var item in news)
            {
                if (item.Description.Length > NUM)
                {
                    item.Description = item.Description.Remove(NUM, item.Description.Length - NUM) + "...";
                }
            }
            return View(news);
        }

        public ActionResult ReviewsBook()
        {
            return View(blogContext.Reviews.OrderByDescending(n => n.Id));
        }

        public ActionResult Poll()
        {
            return View();
        }
         
        // =================================================================

        public ActionResult Delete(int? id, MyObject who)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            dbOperations.Delete(blogContext, who, id);

            if (who == MyObject.Reviews)
                return View("ReviewsBook", blogContext.Reviews.OrderByDescending(n => n.Id));
            else
                return View("Index", blogContext.News.OrderByDescending(n => n.Id));
        }

        public ActionResult Edit(int? id, MyObject who)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var obj = dbOperations.GetObject(blogContext, id, who);

            if (who == MyObject.Reviews)
                return View("EditReviews", obj);
            else
                return View("EditNews", obj);
        }

        // =================================================================

        public ActionResult CreateNews() => View();

        [HttpGet]
        public ActionResult AddNews() => View();

        [HttpPost]
        public ActionResult AddNews(News news)
        {
            dbOperations.AddNewItem(blogContext, MyObject.News, news);
            return View("Index", blogContext.News.OrderByDescending(n => n.Id));
        }

        // =================================================================

        public ActionResult CreateReviews() => View();

        [HttpGet]
        public ActionResult AddReviews() => View();

        [HttpPost]
        public ActionResult AddReviews(Reviews reviews)
        {
            dbOperations.AddNewItem(blogContext, MyObject.Reviews, reviews);
            return View("ReviewsBook", blogContext.Reviews.OrderByDescending(n => n.Id));
        }

        // =================================================================

        [HttpGet]
        public ActionResult EditNews() => View();

        [HttpPost]
        public ActionResult EditNews(News news)
        {
            dbOperations.Edit(blogContext, MyObject.News, news);
            return View("Index", blogContext.News.OrderByDescending(n => n.Id));
        }

        // =================================================================

        [HttpGet]
        public ActionResult EditReviews() => View();

        [HttpPost]
        public ActionResult EditReviews(Reviews reviews)
        {
            dbOperations.Edit(blogContext, MyObject.Reviews, reviews);
            return View("ReviewsBook", blogContext.Reviews.OrderByDescending(n => n.Id));
        }

        // =================================================================

        public ActionResult More (int? id, MyObject who)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var obj = dbOperations.GetObject(blogContext, id, who);
            if (obj == null)
            {
                return HttpNotFound();
            }

            return View("More", obj);
        }
    }
}