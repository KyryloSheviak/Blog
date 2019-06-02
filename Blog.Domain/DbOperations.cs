using Blog.Domain.Entities;
using Blog.Domain.Repository;

namespace Blog.Domain
{
    public enum MyObject
    {
        News,
        Reviews
    }

    public class DbOperations
    {
        public void AddNewItem(BlogContext context, MyObject who, dynamic obj)
        {
            switch (who)
            {
                case MyObject.News:
                    var n = obj as Entities.News;
                    context.News.Add(new Entities.News
                    {
                        Title = n.Title,
                        Description = n.Description,
                        Date = n.Date,
                        IsDelete = false
                    });
                    break;
                case MyObject.Reviews:
                    var r = obj as Entities.Reviews;
                    context.Reviews.Add(new Entities.Reviews
                    {
                        Name = r.Name,
                        Description = r.Description,
                        Date = r.Date,
                        IsDelete = false
                    });
                    break;
            }
            context.SaveChanges();
        }

        public void Delete(BlogContext context, MyObject who, int? id)
        {
            switch (who)
            {
                case MyObject.News:
                    context.News.Find(id).IsDelete = true;
                    break;
                case MyObject.Reviews:
                    context.Reviews.Find(id).IsDelete = true;
                    break;
            }
            context.SaveChanges();
        }

        public void Edit(BlogContext context, MyObject who, dynamic obj)
        {
            if (obj is News)
                EditNews(context, obj);
            if (obj is Reviews)
                EditReviews(context, obj);
        }

        public dynamic GetObject(BlogContext context, int? id, MyObject who)
        {
            dynamic obj = null;
            switch (who)
            {
                case MyObject.News:
                    obj = context.News.Find(id);
                    break;
                case MyObject.Reviews:
                    obj = context.Reviews.Find(id);
                    break;
            }
            return obj;
        }


        private void EditNews(BlogContext context, News news)
        {
            context.News.Find(news.Id).Title = news.Title;
            context.News.Find(news.Id).Description = news.Description;
            context.News.Find(news.Id).Date = news.Date;
            context.News.Find(news.Id).IsDelete = news.IsDelete;
            context.SaveChanges();
        }

        private void EditReviews(BlogContext context, Reviews reviews)
        {
            context.Reviews.Find(reviews.Id).Name = reviews.Name;
            context.Reviews.Find(reviews.Id).Description = reviews.Description;
            context.Reviews.Find(reviews.Id).Date = reviews.Date;
            context.Reviews.Find(reviews.Id).IsDelete = reviews.IsDelete;
            context.SaveChanges();
        }
    }
}
