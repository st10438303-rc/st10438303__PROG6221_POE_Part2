namespace CybersecurityChatbotWPF.Models
{
    public class UserMemory
    {
        public string Name { get; set; }
        public string FavoriteTopic { get; set; }
        public string LastTopic { get; set; }
        public int FollowUpCount { get; set; }

        public UserMemory()
        {
            Name = "Friend";
            FollowUpCount = 0;
        }

        public string GetPersonalizedGreeting()
        {
            if (!string.IsNullOrEmpty(FavoriteTopic))
            {
                return $"Since you're interested in {FavoriteTopic}, ";
            }
            return "";
        }
    }
}