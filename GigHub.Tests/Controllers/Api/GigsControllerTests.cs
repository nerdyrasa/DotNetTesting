using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GigHub.Controllers.Api;
using System.Security.Principal;
using System.Security.Claims;
using Moq;
using GigHub.Core;
using System.Web.Http;

namespace GigHub.Tests
{
    [TestClass]
    public class GigsControllerTests
    {
        private GigsController _controller;

        public GigsControllerTests()
        {
            var identity = new GenericIdentity("user1@domain.com");
            //https://msdn.microsoft.com/en-us/library/microsoft.identitymodel.claims.claimtypes_members.aspx
            //Defines constants for the well-known claim types that are supported by Windows® Identity Foundation (WIF).

            identity.AddClaim(
              new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "user1@domain.com"));
            identity.AddClaim(
              new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "1"));

            var principal = new GenericPrincipal(identity, null);

            var mockUoW = new Mock<IUnitOfWork>();
            _controller = new GigsController(mockUoW.Object);
            _controller.User = principal;
        }
    }
}
