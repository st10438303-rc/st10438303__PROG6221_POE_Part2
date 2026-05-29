using System;

namespace CybersecurityChatbotWPF.Models
{
    public class ChatMessage
    {
        public string Message { get; set; }
        public bool IsUser { get; set; }
        public DateTime Timestamp { get; set; }

        public string DisplayTime => Timestamp.ToString("HH:mm");

        public ChatMessage()
        {
            Timestamp = DateTime.Now;
        }
    }
}