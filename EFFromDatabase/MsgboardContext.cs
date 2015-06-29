namespace EFFromDatabase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MsgboardContext : DbContext
    {
        public MsgboardContext()
            : base("name=msgboard")
        {
        }

        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         
        }
    }
}
