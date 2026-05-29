using CybersecurityChatbotWPF.Models;

namespace CybersecurityChatbotWPF.Services
{
    public class SentimentService
    {
        public Sentiment AnalyzeSentiment(string input)
        {
            return Sentiment.Analyze(input);
        }

        public string AdjustResponseForSentiment(string response, Sentiment sentiment, UserMemory memory)
        {
            string personalization = memory.GetPersonalizedGreeting();

            switch (sentiment.Type)
            {
                case SentimentType.Worried:
                    return $"😰 I understand your concern. {personalization}{response}\n\n💙 Stay safe!";

                case SentimentType.Frustrated:
                    return $"😤 I know this can be frustrating. {personalization}{response}\n\n👍 You've got this!";

                case SentimentType.Curious:
                    return $"🤔 Great question! {personalization}{response}\n\n📚 Want to know more?";

                case SentimentType.Positive:
                    return $"😊 Great attitude! {personalization}{response}";

                default:
                    return $"{personalization}{response}";
            }
        }
    }
}