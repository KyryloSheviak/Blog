using System;

namespace Blog.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsDelete { get; set; }
    }
}
