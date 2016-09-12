using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GigHub.Controllers.Api;
using System.Security.Principal;
using System.Security.Claims;
using Moq;
using GigHub.Core;
using System.Web.Http;
using GigHub.Tests.Extensions;

namespace GigHub.Tests
{
    [TestClass]
    public class GigsControllerTests
    {
        private GigsController _controller;

        public GigsControllerTests()
        {
            var mockUoW = new Mock<IUnitOfWork>();
            _controller = new GigsController(mockUoW.Object);
            _controller.MockCurrentUser("1", "user1@domain.com");
        }
    }
}
