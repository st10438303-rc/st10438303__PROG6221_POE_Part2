// Arquivo original: ResponseEngine.cs (Parte 1)
// NOVO ARQUIVO: Services/ResponseEngine.cs

using System;
using System.Collections.Generic;
using System.Linq;

namespace CybersecurityChatbotWPF.Services
{
    public class ResponseEngine
    {
        // ==== CÓDIGO ORIGINAL DA PARTE 1 (mantido) ====
        private Dictionary<string, string> responses;

        // Construtor original da Parte 1
        public ResponseEngine()
        {
            responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                // Greeting responses
                {"how are you", "I'm functioning well, thank you for asking! Ready to help you with cybersecurity awareness!"},
                {"how are you doing", "Doing great! All systems operational. How can I assist you with online safety today?"},
                // ... todo o resto do código original da Parte 1 ...
                {"bye", "Goodbye! Stay safe online and remember to practice good cybersecurity habits!"}
            };
        }

        // Método original da Parte 1
        public string GetResponse(string input)
        {
            foreach (var key in responses.Keys)
            {
                if (input.ToLower().Contains(key.ToLower()))
                {
                    return responses[key];
                }
            }
            return null;
        }

        // ==== NOVO CÓDIGO PARA PARTE 2 ====

        // Respostas randomizadas (Requisito 3)
        private Dictionary<string, List<string>> randomResponses;
        private Random random;

        private void InitializeRandomResponses()
        {
            random = new Random();
            randomResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                ["phishing"] = new List<string>
                {
                    "🎣 Tip 1: Always check the sender's email address carefully!",
                    "🎣 Tip 2: Never click links in unsolicited emails!",
                    "🎣 Tip 3: Hover over links to see the real URL before clicking!",
                    "🎣 Tip 4: When in doubt, go directly to the website!"
                },
                ["password"] = new List<string>
                {
                    "🔐 Tip 1: Use at least 12 characters with mixed case!",
                    "🔐 Tip 2: Never reuse passwords across different sites!",
                    "🔐 Tip 3: Use a password manager like Bitwarden!",
                    "🔐 Tip 4: Enable 2FA whenever possible!"
                }
            };
        }

        public string GetRandomResponse(string topic)
        {
            InitializeRandomResponses();
            if (randomResponses.ContainsKey(topic.ToLower()))
            {
                var options = randomResponses[topic.ToLower()];
                return options[random.Next(options.Count)];
            }
            return null;
        }
    }
}