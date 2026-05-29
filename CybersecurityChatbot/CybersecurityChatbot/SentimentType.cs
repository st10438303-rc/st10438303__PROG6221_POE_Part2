namespace CybersecurityChatbotWPF.Models
{
    public enum SentimentType
    {
        Positive,
        Neutral,
        Negative,
        Worried,
        Curious,
        Frustrated
    }

    public class Sentiment
    {
        public SentimentType Type { get; set; }
        public string Label { get; set; }

        public static Sentiment Analyze(string input)
        {
            input = input.ToLower();

            // Palavras de preocupação
            string[] worried = { "worried", "scared", "nervous", "anxious", "concerned", "afraid" };
            foreach (var word in worried)
                if (input.Contains(word))
                    return new Sentiment { Type = SentimentType.Worried, Label = "Worried" };

            // curious words
            string[] curious = { "curious", "wonder", "how", "why", "learn", "understand" };
            foreach (var word in curious)
                if (input.Contains(word))
                    return new Sentiment { Type = SentimentType.Curious, Label = "Curious" };

            // frustrations words
            string[] frustrated = { "frustrated", "confused", "difficult", "complicated" };
            foreach (var word in frustrated)
                if (input.Contains(word))
                    return new Sentiment { Type = SentimentType.Frustrated, Label = "Frustrated" };

            // positive words
            string[] positive = { "great", "good", "excellent", "awesome", "thanks", "helpful" };
            foreach (var word in positive)
                if (input.Contains(word))
                    return new Sentiment { Type = SentimentType.Positive, Label = "Positive" };

            // negative words
            string[] negative = { "bad", "terrible", "awful", "hate" };
            foreach (var word in negative)
                if (input.Contains(word))
                    return new Sentiment { Type = SentimentType.Negative, Label = "Negative" };

            return new Sentiment { Type = SentimentType.Neutral, Label = "Neutral" };
        }

        public string GetEmoji()
        {
            return Type switch
            {
                SentimentType.Positive => "😊",
                SentimentType.Negative => "😟",
                SentimentType.Worried => "😰",
                SentimentType.Curious => "🤔",
                SentimentType.Frustrated => "😤",
                _ => "😐"
            };
        }
    }
}