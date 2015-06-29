using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using EFFromDatabase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace msgBoardTests
{
    [TestClass]
    public class UnitTest1
    {
        public readonly IMsgRepo MockRepo;

        public UnitTest1()
        {


            List<Reply> replies = new List<Reply>
            {
                
                new Reply(){Body = "bdy1", Id = 1, TopicId = 1, Created = DateTime.Now},
                new Reply(){Body = "bdy2", Id = 2, TopicId = 1, Created = DateTime.Now},
                new Reply(){Body = "bdy3", Id = 3, TopicId = 1, Created = DateTime.Now},
                new Reply(){Body = "bdy4", Id = 4, TopicId = 1, Created = DateTime.Now}
            };

      

            Mock<IMsgRepo> mockRepo = new Mock<IMsgRepo>();
            mockRepo.Setup(m => m.GetReplies()).Returns(replies.AsQueryable);

            mockRepo.Setup(m => m.FindById(
                It.IsAny<int>()))
                .Returns((int i) => replies.Single(x => x.Id == i));

            mockRepo.Setup(m => m.DeleteReply(It.IsAny<int>()))
                .Returns(
                    (int deleteId) =>
                    {
                        var replyToDelete = replies.Single(r => r.Id == deleteId);
                        replies.Remove(replyToDelete);
                        return true;
                    });


            mockRepo.Setup(m => m.InsertReply(
                It.IsAny<Reply>())).Returns(
                    (Reply target) =>
                    {
                        DateTime now = DateTime.Now;
                        if (target.Id.Equals(default(int)))
                        {
                            target.Created = now;
                            target.Id = replies.Count() + 1;
                            replies.Add(target);

                        }
                        else
                        {
                            var orig = replies.Single(r => r.Id == target.Id);
                            if (orig == null)
                                return false;

                            orig.Body = target.Body;
                            orig.Created = now;
                            orig.TopicId = target.TopicId;

                        }
                        return true;
                    }


                );



            MockRepo = mockRepo.Object;
        }

        [TestMethod]
        public void FindById()
        {
            Reply r = MockRepo.FindById(2);
            Assert.IsNotNull(r);
            Assert.IsInstanceOfType(r, typeof(Reply));
            Assert.AreEqual(r.Body, "bdy2");




        }

        [TestMethod]
        public void DeleteReply()
        {
            int deleteId = 2;
            MockRepo.DeleteReply(2);
            Assert.AreEqual(MockRepo.GetReplies().Count(), 3);

        }

        [TestMethod]
        public void InsertReply()
        {
            Reply r = new Reply()
            {
                Body = "New Reply",
                TopicId = 1,
                Created = DateTime.UtcNow
            };
            //before insert
            var replycount = MockRepo.GetReplies().Count();
            Assert.AreEqual(replycount, 4);

            //insert
            MockRepo.InsertReply(r);
            replycount = MockRepo.GetReplies().Count();
            Assert.AreEqual(replycount, 5);





        }
    }
}
