namespace EFFromDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Topic
    {
        public Topic()
        {
            Replies = new HashSet<Reply>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime Created { get; set; }

        public bool Flag { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }
    }
}
