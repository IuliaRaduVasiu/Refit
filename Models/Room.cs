namespace Refit
{
        public class Room
    {
        public string Name {get; set; }
        
        public int CardSetType {get; set; }
        public bool HaveStories {get; set; }
        public bool ConfirmSkip {get; set; }
        public bool ShowVotingToObservers {get; set; }
        public bool AutoReveal {get; set; }
        public bool ChangeVote {get; set; }
        public bool CountdownTimer {get; set; }
        public int CountdownTimerValue {get; set; }
    }
}