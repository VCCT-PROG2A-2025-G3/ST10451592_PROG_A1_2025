using System;
using System.Threading;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    /// <summary>
    /// Processes user input with dynamic responses, keyword recognition, and sentiment detection.
    /// </summary>
    class RespondToUser
    {
        private readonly UserMemory _memory;
        private readonly Random _random;
        private readonly Dictionary<string, List<string>> _keywordResponses;

        public RespondToUser(UserMemory memory)
        {
            _memory = memory;
            _random = new Random();
            _keywordResponses = new Dictionary<string, List<string>>
            {
                {
                    "password", new List<string>
                    {
                        "Use strong passwords with at least 12 characters, mixing letters, numbers, and symbols. Avoid reusing passwords!",
                        "A good password is unique and complex. Try a password manager to keep track of them securely.",
                        "Enable two-factor authentication (2FA) to add an extra layer of security to your accounts."
                    }
                },
                {
                    "scam", new List<string>
                    {
                        "Scams often come as urgent emails or texts. Verify the sender before acting, and never share personal info.",
                        "Watch for red flags like spelling errors or requests for money. Contact the organization directly if unsure.",
                        "Report scams to your email provider or local authorities to help stop cybercriminals."
                    }
                },
                {
                    "privacy", new List<string>
                    {
                        "Review your account privacy settings regularly to limit data sharing and protect your information.",
                        "Use a VPN on public Wi-Fi to encrypt your connection and keep your data private.",
                        "Be cautious about what you share online. Adjust social media privacy settings to control who sees your posts."
                    }
                }
            };
        }

        /// <summary>
        /// Processes user input and generates a response based on keywords, sentiment, or predefined queries.
        /// </summary>
        public void ProcessInput(string input)
        {
            string response;
            input = input?.Trim().ToLower() ?? string.Empty;
            _memory.AddToHistory(input); // Store input in history

            // Check for sentiment keywords
            string sentiment = DetectSentiment(input);
            bool isSentimentDetected = !string.IsNullOrEmpty(sentiment);

            // Handle predefined queries
            switch (input)
            {
                case "how are you":
                    response = $"I'm buzzing with cybersecurity tips, {_memory.GetUserName()}! Want to talk about {_memory.GetFavoriteTopic() ?? "online safety"}?";
                    break;

                case "what's your purpose":
                    response = $"I'm here to help you stay safe online, {_memory.GetUserName()}! Ask about password tips, scams, privacy, or anything cybersecurity-related.";
                    break;

                case "what can i ask you about":
                    response = "You can ask about password security, avoiding scams, protecting your privacy, or even safe browsing tips. What's on your mind?";
                    break;

                default:
                    // Check for keyword-based responses
                    string keyword = _keywordResponses.Keys.FirstOrDefault(k => input.Contains(k));
                    if (keyword != null)
                    {
                        // Set favorite topic if not already set
                        if (_memory.GetFavoriteTopic() == null)
                            _memory.SetFavoriteTopic(keyword);

                        // Select a random response for the keyword
                        var responses = _keywordResponses[keyword];
                        response = responses[_random.Next(responses.Count)];

                        // Personalize with favorite topic or sentiment
                        if (_memory.GetFavoriteTopic() == keyword)
                            response += $" Since you're interested in {keyword}, want more details?";
                        if (isSentimentDetected)
                            response = AdjustForSentiment(sentiment, response);
                    }
                    else
                    {
                        // Check for follow-up questions
                        string lastInput = _memory.GetLastInput();
                        if (lastInput != null && lastInput.Contains("more details") && _memory.GetFavoriteTopic() != null)
                        {
                            var responses = _keywordResponses[_memory.GetFavoriteTopic()];
                            response = responses[_random.Next(responses.Count)] + " Anything else you'd like to know?";
                        }
                        else
                        {
                            response = "Hmm, I didn’t catch that one! Could you rephrase or try asking about passwords, scams, or privacy?";
                        }
                        if (isSentimentDetected)
                            response = AdjustForSentiment(sentiment, response);
                    }
                    break;
            }

            // Simulate typing effect
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Chatbot: ");
            Console.ResetColor();
            foreach (char c in response)
            {
                Console.Write(c);
                Thread.Sleep(30);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Detects simple sentiments in user input.
        /// </summary>
        private string DetectSentiment(string input)
        {
            if (input.Contains("worried") || input.Contains("scared"))
                return "worried";
            if (input.Contains("curious") || input.Contains("interested"))
                return "curious";
            if (input.Contains("frustrated") || input.Contains("annoyed"))
                return "frustrated";
            return null;
        }

        /// <summary>
        /// Adjusts the response based on detected sentiment.
        /// </summary>
        private string AdjustForSentiment(string sentiment, string baseResponse)
        {
            return sentiment switch
            {
                "worried" => $"I understand you're feeling {sentiment}, {_memory.GetUserName()}. Don't worry, let's go through this together. {baseResponse}",
                "curious" => $"Great to see you're {sentiment}, {_memory.GetUserName()}! Here's some info to fuel your interest: {baseResponse}",
                "frustrated" => $"I get that you're feeling {sentiment}, {_memory.GetUserName()}. Let's break this down simply: {baseResponse}",
                _ => baseResponse
            };
        }
    }
}