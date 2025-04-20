// RespondToUser.cs
using System;
using System.Threading; // For simulating typing effect

namespace CybersecurityChatbot
{
    /// <summary>
    /// Processes user input and provides predefined responses for specific queries.
    /// </summary>
    class RespondToUser
    {
        /// <summary>
        /// Processes user input and provides predefined responses for specific queries.
        /// Includes a default response for unrecognized inputs.
        /// </summary>
        /// <param name="input">User's input string</param>
        public void ProcessInput(string input)
        {
            // Use switch for efficient matching of predefined queries
            string response;
            switch (input)
            {
                case "how are you":
                    response = "I'm just a bot, but I'm here to help you stay safe online!";
                    break;

                case "what's your purpose":
                    response = "I educate people about cybersecurity threats and how to stay safe.";
                    break;

                case "what can i ask you about":
                    response = "You can ask about password security, phishing, safe browsing, and more!";
                    break;

                case "password security":
                    response = "Use strong passwords with a mix of letters, numbers, and symbols. Avoid reusing passwords.";
                    break;

                case "phishing":
                    response = "Be cautious of emails asking for personal details. Always verify the sender's identity.";
                    break;

                case "safe browsing":
                    response = "Avoid clicking on suspicious links. Use secure websites starting with 'https://'.";
                    break;

                default:
                    response = "I didn't quite understand that. Could you rephrase?";
                    break;
            }

            // Simulate typing effect for a conversational feel
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Chatbot: ");
            Console.ResetColor();
            foreach (char c in response)
            {
                Console.Write(c);
                Thread.Sleep(30); // Slight delay for each character
            }
            Console.WriteLine();
        }
    }
}