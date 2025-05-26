using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace CybersecurityChatbot
{
    /// <summary>
    /// Handles user input processing, generating dynamic responses based on keywords, sentiment, and conversation history.
    /// </summary>
    class RespondToUser
    {
        private readonly UserMemory _memory; // Stores user data for memory and recall
        private readonly Random _random; // Used to select random responses
        private readonly Dictionary<string, List<string>> _keywordResponses; // Maps cybersecurity keywords to response lists
        private readonly List<string> _affirmativeResponses; // List of affirmative human responses
        private readonly List<string> _negativeResponses; // List of negative human responses

        /// <summary>
        /// Initializes the RespondToUser class with a UserMemory instance and sets up keyword responses and simple human answer lists.
        /// </summary>
        /// <param name="memory">UserMemory instance to store and recall user details.</param>
        public RespondToUser(UserMemory memory)
        {
            _memory = memory;
            _random = new Random();

            // Initialize keyword responses for cybersecurity topics, including phishing tips
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
                },
                {
                    "phishing", new List<string>
                    {
                        "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organizations.",
                        "Check the sender's email address carefully—phishers often use slight misspellings to trick you.",
                        "Avoid clicking links in suspicious emails. Hover over them to see the actual URL before clicking."
                    }
                }
            };

            // Initialize lists for simple human answers
            _affirmativeResponses = new List<string> { "yes", "sure", "okay", "yep", "yeah", "please", "go ahead" };
            _negativeResponses = new List<string> { "no", "nope", "not really", "nah" };
        }

        /// <summary>
        /// Processes user input and generates a response based on keywords, sentiment, conversation history, or simple human answers.
        /// </summary>
        /// <param name="input">The user's input string.</param>
        public void ProcessInput(string input)
        {
            string response; // The chatbot's response to the user
            input = input?.Trim().ToLower() ?? string.Empty; // Normalize input by trimming and converting to lowercase
            _memory.AddToHistory(input); // Store the input in conversation history

            // Detect sentiment in the user's input
            string sentiment = DetectSentiment(input);
            bool isSentimentDetected = !string.IsNullOrEmpty(sentiment);

            // Handle predefined queries and keywords
            switch (input)
            {
                case "how are you":
                    response = $"I'm buzzing with cybersecurity tips, {_memory.GetUserName()}! Want to talk about {_memory.GetFavoriteTopic() ?? "online safety"}?";
                    break;

                case "what's your purpose":
                    response = $"I'm here to help you stay safe online, {_memory.GetUserName()}! Ask about password tips, scams, privacy, phishing tips, or anything cybersecurity-related.";
                    break;

                case "what can i ask you about":
                    response = "You can ask about password security, avoiding scams, protecting your privacy, phishing tips, or safe browsing tips. What's on your mind?";
                    break;

                default:
                    // Check for keyword-based responses (including phishing)
                    string keyword = _keywordResponses.Keys.FirstOrDefault(k => input.Contains(k));
                    if (keyword != null)
                    {
                        // Set favorite topic if not already set
                        if (_memory.GetFavoriteTopic() == null)
                        {
                            _memory.SetFavoriteTopic(keyword);
                            response = $"Great! I'll remember that you're interested in {keyword}. It's a crucial part of staying safe online. ";
                        }
                        else
                        {
                            response = string.Empty;
                        }

                        // Set the last keyword discussed
                        _memory.SetLastKeyword(keyword);

                        // Select a random response for the keyword
                        var responses = _keywordResponses[keyword];
                        response += responses[_random.Next(responses.Count)];

                        // Always ask if the user wants more details
                        response += " Want more details?";
                        if (isSentimentDetected)
                            response = AdjustForSentiment(sentiment, response);
                    }
                    else
                    {
                        // Check for follow-up questions, confusion, or simple human answers
                        string lastInput = _memory.GetLastInput()?.ToLower().Trim() ?? string.Empty; // Normalize last input
                        if (lastInput.Contains("want more details") && _memory.GetLastKeyword() != null)
                        {
                            // Split input into words for precise matching
                            var inputWords = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (inputWords.Any(word => _affirmativeResponses.Contains(word)))
                            {
                                // Provide more details on the last keyword
                                var responses = _keywordResponses[_memory.GetLastKeyword()];
                                response = responses[_random.Next(responses.Count)] + " Anything else you'd like to know?";
                            }
                            else if (inputWords.Any(word => _negativeResponses.Contains(word)))
                            {
                                // Acknowledge the user's response and prompt for a new topic
                                response = $"Okay, {_memory.GetUserName()}, let's switch gears. What else would you like to know about? Try asking about passwords, scams, privacy, or phishing tips.";
                            }
                            else
                            {
                                // If the response isn't clear, prompt for clarification
                                response = "I didn't quite catch that. Did you want more details? Just say 'yes' or 'no'.";
                            }
                        }
                        else
                        {
                            // Default response for unrecognized input
                            response = "Hmm, I didn’t catch that one! Could you rephrase or try asking about passwords, scams, privacy, or phishing tips?";
                        }
                        if (isSentimentDetected)
                            response = AdjustForSentiment(sentiment, response);
                    }
                    break;
            }

            // Display the response with a typing effect
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Chatbot: ");
            Console.ResetColor();
            foreach (char c in response)
            {
                Console.Write(c);
                Thread.Sleep(30); // Simulate typing delay
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Detects simple sentiments in user input based on predefined keywords.
        /// </summary>
        /// <param name="input">The user's input string.</param>
        /// <returns>The detected sentiment ("worried", "curious", "frustrated") or null if none detected.</returns>
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
        /// Adjusts the response based on the detected sentiment to make it more empathetic.
        /// </summary>
        /// <param name="sentiment">The detected sentiment.</param>
        /// <param name="baseResponse">The original response before sentiment adjustment.</param>
        /// <returns>The adjusted response incorporating the sentiment.</returns>
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