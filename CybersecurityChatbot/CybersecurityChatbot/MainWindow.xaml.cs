using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CybersecurityChatbotWPF.Models;
using CybersecurityChatbotWPF.Services;
using CybersecurityChatbotWPF.Helpers;

namespace CybersecurityChatbotWPF
{
    public partial class MainWindow : Window
    {
        
        private ResponseEngine responseEngine;      
        private AudioService audioService;          

        
        private ConversationService conversationService;
        private SentimentService sentimentService;
        private UserMemory memory;

        private bool awaitingName = true;

        public MainWindow()
        {
            InitializeComponent();

            
            responseEngine = new ResponseEngine();
            audioService = new AudioService();
            conversationService = new ConversationService();
            sentimentService = new SentimentService();
            memory = conversationService.Memory;

            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            audioService.PlayGreeting("greeting.wav");

            // welcome message
            await AddBotMessage("🔐 Welcome to Cybersecurity Awareness Bot!");
            await AddBotMessage("Before we begin, what is your name?");

            MessageTextBox.Focus();
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            await ProcessUserInput();
        }

        private async void MessageTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !string.IsNullOrWhiteSpace(MessageTextBox.Text))
            {
                e.Handled = true;
                await ProcessUserInput();
            }
        }

        private async Task ProcessUserInput()
        {
            string userInput = MessageTextBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(userInput)) return;

            MessageTextBox.Clear();

            // Add user message 
            AddUserMessage(userInput);

            // verify output
            if (userInput.ToLower() == "exit" || userInput.ToLower() == "bye")
            {
                await AddBotMessage($"Goodbye, {memory.Name}! Stay safe online!");
                await Task.Delay(1000);
                Close();
                return;
            }

            // Capture user name
            if (awaitingName)
            {
                memory.Name = userInput;
                awaitingName = false;
                await AddBotMessage($"Nice to meet you, {memory.Name}! I'm here to help you stay safe online.");
                await AddBotMessage("Ask me about: passwords, phishing, safe browsing, malware, or scams!");
                return;
            }

            
            await AddBotMessage("...");

            
            var sentiment = sentimentService.AnalyzeSentiment(userInput);

            
            string response = responseEngine.GetResponse(userInput);

            
            if (string.IsNullOrEmpty(response))
            {
                string[] topics = { "password", "phishing" };
                foreach (var topic in topics)
                {
                    if (userInput.ToLower().Contains(topic))
                    {
                        response = responseEngine.GetRandomResponse(topic);
                        if (!string.IsNullOrEmpty(response)) break;
                    }
                }
            }

            
            if (string.IsNullOrEmpty(response))
            {
                response = "I'm not sure I understand. Try asking about passwords, phishing, or safe browsing!";
            }

            
            response = sentimentService.AdjustResponseForSentiment(response, sentiment, memory);

           
            if (conversationService.IsFollowUpRequest(userInput))
            {
                conversationService.IncrementFollowUp();
                response = $"📖 Sure! {response}";
            }
            else
            {
                conversationService.ResetFollowUp();
            }

            
            conversationService.StoreConversation(userInput, response);

            
            await UpdateLastBotMessage(response);
        }

        private void AddUserMessage(string message)
        {
            Dispatcher.Invoke(() =>
            {
                MessagesItemsControl.Items.Add(new ChatMessage
                {
                    Message = message,
                    IsUser = true,
                    Timestamp = DateTime.Now
                });
                ScrollToBottom();
            });
        }

        private async Task AddBotMessage(string message)
        {
            await Dispatcher.InvokeAsync(() =>
            {
                MessagesItemsControl.Items.Add(new ChatMessage
                {
                    Message = message,
                    IsUser = false,
                    Timestamp = DateTime.Now
                });
                ScrollToBottom();
            });
        }

        private async Task UpdateLastBotMessage(string newMessage)
        {
            await Dispatcher.InvokeAsync(() =>
            {
                if (MessagesItemsControl.Items.Count > 0)
                {
                    var lastItem = MessagesItemsControl.Items[^1];
                    if (lastItem is ChatMessage msg && !msg.IsUser)
                    {
                        msg.Message = newMessage;
                        // Refresh the item
                        MessagesItemsControl.Items.RemoveAt(MessagesItemsControl.Items.Count - 1);
                        MessagesItemsControl.Items.Add(msg);
                    }
                }
                ScrollToBottom();
            });
        }

        private void ScrollToBottom()
        {
            ChatScrollViewer.ScrollToEnd();
        }
    }
}