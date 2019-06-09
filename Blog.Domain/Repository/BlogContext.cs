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
        public IDbSet<Tag> Tags { get; set; } 

        public BlogContext() { }
        public BlogContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
        static BlogContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<BlogContext>());
            Database.SetInitializer(new BlogContextInitializer());
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
                    Date = DateTime.Parse("2019-06-01"),
                    Tags = new List<Tag>
                    {
                        new Tag { Name = "abds", NewsId = 1 },
                        new Tag { Name = "abds", NewsId = 3 },
                    }
                },
                new News
                {   
                    Title = "Вторая новость",
                    Description = "Какая-то новость, но не знаю какая",
                    Date = DateTime.Parse("2019-06-02"),
                    Tags = new List<Tag>
                    {
                        new Tag { Name = "abds", NewsId = 2 },
                        new Tag { Name = "abds", NewsId = 4 },
                    }
                },
                new News
                {
                    Title = "Третья новость",
                    Description = "тут-тут",
                    Date = DateTime.Parse("2019-06-03"),
                    Tags = new List<Tag>
                    {
                        new Tag { Name = "abds", NewsId = 5 },
                        new Tag { Name = "sd", NewsId = 6 },
                    }
                }
            };
            news.ForEach(n => context.News.Add(n));
            context.SaveChanges();

            //var tag = new List<Tag>
            //{
            //    new Tag { Name = "abds"},
            //    new Tag { Name = "second"},
            //    new Tag { Name = "first"},
            //    new Tag { Name = "test"},
            //    new Tag { Name = "more"},
            //    new Tag { Name = "vsia"},
            //    new Tag { Name = "af"},
            //};
            //tag.ForEach(t => context.Tags.Add(t));
            //context.SaveChanges();

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
