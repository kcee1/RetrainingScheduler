namespace RetrainingScheduler.Models
{
    /// <summary>
    /// Represents a track containing scheduled training sessions.
    /// </summary>
    public class Track
    {
        /// <summary>
        /// List of sessions scheduled in the morning.
        /// </summary>
        public List<Session> MorningSessions { get; private set; }

        /// <summary>
        /// List of sessions scheduled in the afternoon.
        /// </summary>
        public List<Session> AfternoonSessions { get; private set; }

        /// <summary>
        /// Start time for morning sessions (9:00 AM).
        /// </summary>
        public static readonly TimeSpan MorningStartTime = new TimeSpan(9, 0, 0);

        /// <summary>
        /// Start time for afternoon sessions (1:00 PM).
        /// </summary>
        public static readonly TimeSpan AfternoonStartTime = new TimeSpan(13, 0, 0);

        /// <summary>
        /// Initializes a new instance of the <see cref="Track"/> class.
        /// </summary>
        public Track()
        {
            MorningSessions = new List<Session>();
            AfternoonSessions = new List<Session>();
        }
    }
}
