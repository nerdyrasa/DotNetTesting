using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GigHub.Core.Models;
using FluentAssertions;

namespace GigHub.Tests.Domain.Models
{
    [TestClass]
    public class NotificationTests
    {
        [TestMethod]
        public void GigCanceled_WhenCalled_ShouldReturnNotificationForCanceledGig()
        {
            var gig = new Gig();

            var notification = Notification.GigCanceled(gig);

            notification.Type.Should().Be(NotificationType.GigCanceled);

            notification.Gig.Should().Be(gig);
        }

        [TestMethod]
        public void GigCreated_WhenCalled_ShouldReturnNotificationForCreatedGig()
        {
            var gig = new Gig();

            var notification = Notification.GigCreated(gig);

            notification.Type.Should().Be(NotificationType.GigCreated);

            notification.Gig.Should().Be(gig);
        }

        [TestMethod]
        public void GigUpdated_WhenCalled_ShouldReturnNotificationForUpdatedGig()
        {
            var gig = new Gig();

            var notification = Notification.GigUpdated(gig, DateTime.Now, "Test Venue");

            notification.Type.Should().Be(NotificationType.GigUpdated);

            notification.Gig.Should().Be(gig);
        }
    }
}
