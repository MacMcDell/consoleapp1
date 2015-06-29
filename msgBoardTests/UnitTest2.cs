using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using EFFromDatabase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace msgBoardTests
{
    [TestClass]
    public class UnitTest2
    {
        private MsgRepo svc;
        private Mock<DbSet<Reply>> mockSet;
        private Mock<MsgboardContext> mockContext;

        [TestInitialize]
        public void init()
        {
            var replies = new List<Reply>
            {
                
                new Reply(){Body = "bdy1", Id = 1, TopicId = 1, Created = DateTime.Now},
                new Reply(){Body = "bdy2", Id = 2, TopicId = 1, Created = DateTime.Now},
                new Reply(){Body = "bdy3", Id = 3, TopicId = 1, Created = DateTime.Now},
                new Reply(){Body = "bdy4", Id = 4, TopicId = 1, Created = DateTime.Now}
            }.AsQueryable();

            mockSet = new Mock<DbSet<Reply>>();
            mockSet.As<IQueryable<Reply>>().Setup(m => m.Provider).Returns(replies.Provider);
            mockSet.As<IQueryable<Reply>>().Setup(m => m.Expression).Returns(replies.Expression);
            mockSet.As<IQueryable<Reply>>().Setup(m => m.ElementType).Returns(replies.ElementType);
            mockSet.As<IQueryable<Reply>>().Setup(m => m.GetEnumerator()).Returns(replies.GetEnumerator());

            mockContext = new Mock<MsgboardContext>();
            mockContext.Setup(c => c.Replies).Returns(mockSet.Object);

            svc = new MsgRepo(mockContext.Object);

        }


        [TestMethod]
        public void InsertIntoRepo()
        {
            //var mockset = new Mock<DbSet<Reply>>();
            //var mockContext = new Mock<msgboard>();
            //mockContext.Setup(m => m.Replies)
            //    .Returns(mockset.Object);

            //var svc = new MsgRepo(mockContext.Object);

            svc.InsertReply(new Reply()
            {
                Body = "new Body",
                TopicId = 1,
                Created = DateTime.Now
            }
                );
            mockSet.Verify(m => m.Add(It.IsAny<Reply>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
          


        }

        [TestMethod]
        public void DeleteFromRepo()
        {
            svc.DeleteReply(1);
            mockSet.Verify(m => m.Remove(It.IsAny<Reply>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
           
          


        }
    }
}
