using System.Collections.Generic;
using CybersecurityChatbotWPF.Models;

namespace CybersecurityChatbotWPF.Services
{
    public class ConversationService
    {
        private List<(string UserInput, string BotResponse)> history;
        private UserMemory memory;

        public ConversationService()
        {
            history = new List<(string, string)>();
            memory = new UserMemory();
        }

        public UserMemory Memory => memory;

        public void StoreConversation(string userInput, string botResponse)
        {
            history.Add((userInput, botResponse));

           
            if (history.Count > 10)
                history.RemoveAt(0);
        }

        public string GetLastTopic()
        {
            return memory.LastTopic;
        }

        public void SetCurrentTopic(string topic)
        {
            memory.LastTopic = topic;
        }

        public void IncrementFollowUp()
        {
            memory.FollowUpCount++;
        }

        public void ResetFollowUp()
        {
            memory.FollowUpCount = 0;
        }

        public bool IsFollowUpRequest(string input)
        {
            input = input.ToLower();
            return input.Contains("tell me more") ||
                   input.Contains("explain more") ||
                   input.Contains("another tip") ||
                   input.Contains("more information");
        }
    }
}