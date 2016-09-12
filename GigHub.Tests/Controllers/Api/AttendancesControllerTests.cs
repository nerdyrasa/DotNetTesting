﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GigHub.Controllers.Api;
using Moq;
using GigHub.Core.Repositories;
using GigHub.Core;
using GigHub.Tests.Extensions;
using GigHub.Core.Models;
using GigHub.Core.Dtos;
using FluentAssertions;
using System.Web.Http.Results;

namespace GigHub.Tests.Controllers.Api
{
    [TestClass]
    public class AttendancesControllerTests
    {
        private AttendancesController _controller;
        private Mock<IAttendanceRepository> _mockRepository;
        private string _userId;


        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepository = new Mock<IAttendanceRepository>();

            var mockUoW = new Mock<IUnitOfWork>();
            mockUoW.SetupGet(u => u.Attendances).Returns(_mockRepository.Object);

            _controller = new AttendancesController(mockUoW.Object);
            _userId = "1";
            _controller.MockCurrentUser(_userId, "user1@domain.com");

        }

        [TestMethod]
        public void Attend_ValidRequest_ReturnsOk()
        {
            var gig = new Gig();

            var attendanceDto = new AttendanceDto { GigId = gig.Id };

            var result = _controller.Attend(attendanceDto);

            result.Should().BeOfType<OkResult>();

        }

        [TestMethod]
        public void Attend_AttendanceAlreadyExists_ReturnsBadRequest()
        {
            var attendance = new Attendance();
            _mockRepository.Setup(r => r.GetAttendance(1, _userId)).Returns(attendance);

            var result = _controller.Attend(new AttendanceDto { GigId = 1 });

            result.Should().BeOfType<BadRequestErrorMessageResult>();
        }
    }
}
