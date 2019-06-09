using System.Collections.Generic;

namespace Blog.Domain.Entities
{
    public class News : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
