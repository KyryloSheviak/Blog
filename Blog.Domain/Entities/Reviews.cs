using System;

namespace Blog.Domain.Entities
{
    public class Reviews : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
