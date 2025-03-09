namespace RetrainingScheduler.Models
{
    /// <summary>
    /// Represents an Individual Training Session
    /// </summary>
    public class Session
    {
        /// <summary>
        /// The title of the training session
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The duration of the session in minutes, stored as an integer
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Session"/> class.
        /// </summary>
        /// <param name="title">The title of the session.</param>
        /// <param name="duration">The duration of the session in minutes or 'lightning' for 5 minutes.</param>
        public Session(string title, string duration)
        {
            Title = title;
            Duration = duration.ToLower() == "lightning" ? 5 : int.Parse(duration.Replace("min", ""));
        }
    }
}
