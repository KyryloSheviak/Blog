using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Blog.Domain.Repository
{
    public class BlogContext : DbContext
    {
        public IDbSet<News> News { get; set; }
        public IDbSet<Reviews> Reviews { get; set; } 

        public BlogContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
        static BlogContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<BlogContext>());
            //Database.SetInitializer(new BlogContextInitializer());
        }
    }

    public class BlogContextInitializer : CreateDatabaseIfNotExists<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            var news = new List<News>
            {
                new News
                {
                    Title = "А тут моя супер новость",
                    Description = "Я сделал ASP.NET приложение и оно работает!! Ураааа !!!",
                    Date = DateTime.Parse("2019-06-01")
                },
                new News
                {
                    Title = "Вторая новость",
                    Description = "Какая-то новость, но не знаю какая",
                    Date = DateTime.Parse("2019-06-02")
                },
                new News
                {
                    Title = "Третья новость",
                    Description = "тут-тут",
                    Date = DateTime.Parse("2019-06-03")
                }
            };
            news.ForEach(n => context.News.Add(n));
            context.SaveChanges();

            var reviews = new List<Reviews>
            {
                new Reviews
                {
                    Name = "Вадим",
                    Description = "Плохой завтрак",
                    Date = DateTime.Parse("2019-08-02")
                },
                new Reviews
                {
                    Name = "Маким",
                    Description = "Отличное расположение",
                    Date = DateTime.Parse("2019-05-01")
                },
                new Reviews
                {
                    Name = "Кирилл",
                    Description = "Жить можно",
                    Date = DateTime.Parse("2019-04-20")
                }
            };
            reviews.ForEach(r => context.Reviews.Add(r));
            context.SaveChanges();
        }
    }       
}
