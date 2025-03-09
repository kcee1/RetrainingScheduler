using RetrainingScheduler.CustomMethod;
using RetrainingScheduler.Models;

namespace RetrainingScheduler
{
    /// <summary>
    /// The entry point for the Retraining Scheduler application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method that orchestrates session scheduling and display.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        static void Main(string[] args)
        {
            // List of available training sessions.
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

            // Create a scheduler instance and generate the schedule.
            Scheduler scheduler = new Scheduler(sessions);
            List<Track> tracks = scheduler.GenerateSchedule();

            int trackNumber = 1;
            foreach (var track in tracks)
            {
                Console.WriteLine($"Track {trackNumber}");
                TimeSpan currentTime = Track.MorningStartTime;

                // Print morning sessions.
                PrintSessions(track.MorningSessions, ref currentTime);
                Console.WriteLine("12:00PM | Lunch");

                // Print afternoon sessions.
                currentTime = Track.AfternoonStartTime;
                PrintSessions(track.AfternoonSessions, ref currentTime);

                // Print sharing session.
                Console.WriteLine($"{currentTime:hh\\:mm}PM | Sharing Session");
                Console.WriteLine();
                trackNumber++;
            }
        }


        /// <summary>
        /// Prints scheduled sessions with proper formatting.
        /// </summary>
        /// <param name="sessions">List of sessions to print.</param>
        /// <param name="currentTime">The current time tracker.</param>
        private static void PrintSessions(List<Session> sessions, ref TimeSpan currentTime)
        {
            foreach (var session in sessions)
            {
                string period = currentTime.Hours >= 12 ? "PM" : "AM";
                int hourFormat = currentTime.Hours > 12 ? currentTime.Hours - 12 : currentTime.Hours;

                // Print session details.
                Console.WriteLine($"{hourFormat:D2}:{currentTime.Minutes:D2}{period} | {session.Title} | {session.Duration}min");

                // Update time tracker.
                currentTime = currentTime.Add(TimeSpan.FromMinutes(session.Duration));
            }
        }
    }
}
