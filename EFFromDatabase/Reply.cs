namespace EFFromDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reply
    {
        public int Id { get; set; }

        public string Body { get; set; }

        public DateTime Created { get; set; }

        public int TopicId { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
