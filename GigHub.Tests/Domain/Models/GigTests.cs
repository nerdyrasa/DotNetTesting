using FluentAssertions;
using GigHub.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace GigHub.Tests.Domain.Models
{
    [TestClass]
    public class GigTests
    {

        [TestMethod]
        public void Cancel_ExistingGigCanceled_ReturnsIsCanceledTrue()
        {
            var gig = new Gig();

            gig.Cancel();

            gig.IsCanceled.Should().BeTrue();

        }

        [TestMethod]
        public void Cancel_WhenCalled_EachAttendeeGetsANotification()
        {
            var gig = new Gig();
            gig.Attendances.Add(new Attendance { Attendee = new ApplicationUser { Id = "1" } });

            gig.Cancel();

            // TODO: Add gig.GetAttendees() to Gig class
            var attendees = gig.Attendances.Select(a => a.Attendee).ToList();
            attendees[0].UserNotifications.Count().Should().Be(1);

        }
    }
}
