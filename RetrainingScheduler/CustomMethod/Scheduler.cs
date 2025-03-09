using RetrainingScheduler.Models;

namespace RetrainingScheduler.CustomMethod
{
    /// <summary>
    /// Responsible for scheduling training sessions into tracks.
    /// </summary>
    public class Scheduler
    {
        /// <summary>
        /// Maximum duration allowed for morning sessions (in minutes).
        /// </summary>
        private const int MorningDurationLimit = 180;

        /// <summary>
        /// Maximum duration allowed for afternoon sessions (in minutes).
        /// </summary>
        private const int AfternoonDurationLimit = 180;

        /// <summary>
        /// List of available training sessions to be scheduled.
        /// </summary>
        private List<Session> _sessions;

        /// <summary>
        /// Initializes a new instance of the <see cref="Scheduler"/> class.
        /// </summary>
        /// <param name="sessions">List of training sessions to be scheduled.</param>
        public Scheduler(List<Session> sessions)
        {
            _sessions = sessions.OrderByDescending(s => s.Duration).ToList();
        }

        /// <summary>
        /// Generates the schedule by allocating sessions into tracks.
        /// </summary>
        /// <returns>A list of tracks containing scheduled sessions.</returns>
        public List<Track> GenerateSchedule()
        {
            List<Track> tracks = new List<Track>();
            while (_sessions.Any())
            {
                Track track = new Track();
                AllocateSessions(track.MorningSessions, MorningDurationLimit);
                AllocateSessions(track.AfternoonSessions, AfternoonDurationLimit);
                tracks.Add(track);
            }
            return tracks;
        }

        /// <summary>
        /// Allocates training sessions into a specified time slot (morning or afternoon) based on available time.
        /// </summary>
        /// <param name="sessionList">The list where sessions will be added.</param>
        /// <param name="timeLimit">The total available time for the session slot.</param>
        private void AllocateSessions(List<Session> sessionList, int timeLimit)
        {
            int remainingTime = timeLimit;
            for (int i = 0; i < _sessions.Count; i++)
            {
                if (_sessions[i].Duration <= remainingTime)
                {
                    sessionList.Add(_sessions[i]);
                    remainingTime -= _sessions[i].Duration;
                    _sessions.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
