using RetrainingScheduler.CustomMethod;
using RetrainingScheduler.Models;

namespace RetrainingScheduler.Test
{
    /// <summary>
    /// Unit tests for the Retraining Scheduler
    /// </summary>
    public class SchedulerTests
    {
        /// <summary>
        /// Ensures that sessions are created with the correct duration
        /// </summary>
        [Theory]
        [InlineData("60min", 60)]
        [InlineData("45min", 45)]
        [InlineData("30min", 30)]
        [InlineData("lightning", 5)]
        public void Session_Creates_With_Correct_Duration(string inputDuration, int expectedDuration)
        {
            var session = new Session("Test Session", inputDuration);
            Assert.Equal(expectedDuration, session.Duration);
        }

        /// <summary>
        /// Validates that the scheduler generates at least one track
        /// </summary>
        [Fact]
        public void Scheduler_Generates_Correct_Number_Of_Tracks()
        {
            List<Session> sessions = new List<Session>
        {
            new Session("Organising Parents for Academy Improvements", "60min"),
            new Session("Teaching Innovations in the Pipeline", "45min"),
            new Session("Teacher Computer Hacks", "30min"),
            new Session("Making Your Academy Beautiful", "45min"),
            new Session("Academy Tech Field Repair", "45min"),
            new Session("Sync Hard", "lightning"),
            new Session("Unusual Recruiting", "lightning"),
            new Session("Parent Teacher Conferences", "60min"),
            new Session("Managing Your Dire Allowance", "45min"),
            new Session("Customer Care", "30min"),
            new Session("AIMs – 'Managing Up'", "30min"),
            new Session("Dealing with Problem Teachers", "45min"),
            new Session("Hiring the Right Cook", "60min"),
            new Session("Government Policy Changes and New Globe", "60min"),
            new Session("Adjusting to Relocation", "45min"),
            new Session("Public Works in Your Community", "30min"),
            new Session("Talking To Parents About Billing", "30min"),
            new Session("So They Say You're a Devil Worshipper", "60min"),
            new Session("Two-Streams or Not Two-Streams", "30min"),
            new Session("Piped Water", "30min")
        };

            var scheduler = new Scheduler(sessions);
            var tracks = scheduler.GenerateSchedule();

            Assert.True(tracks.Count > 0);
        }

        /// <summary>
        /// Ensures that a track does not exceed the allotted time limits
        /// </summary>
        [Theory]
        [InlineData(new string[] { "60min", "45min", "45min", "30min" }, 180)]
        [InlineData(new string[] { "60min", "30min", "30min", "30min", "30min" }, 180)]
        public void Track_Does_Not_Exceed_Time_Limits(string[] sessionDurations, int timeLimit)
        {
            var sessions = new List<Session>();
            foreach (var duration in sessionDurations)
            {
                sessions.Add(new Session("Test Session", duration));
            }
            var scheduler = new Scheduler(sessions);
            var tracks = scheduler.GenerateSchedule();

            int totalTime = 0;
            foreach(var session in tracks[0].MorningSessions)
            {
                totalTime += session.Duration;
            }

            Assert.True(totalTime <= timeLimit);

            
        }

    }
}
