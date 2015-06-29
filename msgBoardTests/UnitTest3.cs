using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EFFromDatabase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace msgBoardTests
{
    [TestClass]
    public class UnitTest3
    {


        [TestMethod]
        public void TestMethod1()
        {
            var expected = new Reply() { Body = "bdy return", TopicId = 1, Id = 1 };
            var mockReplyRepo = new Mock<IMsgRepo>();
            mockReplyRepo
                .Setup(m => m.FindById(1))
                .Returns(new Reply() { Id = 1, Body = "bdy return" });

            var mockSvc = new MsgService(mockReplyRepo.Object);
            var actual = mockSvc.FindById(expected.Id);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Body, actual.Body);


        }
    }
}
