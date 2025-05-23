using System;

namespace CybersecurityChatbot
{
    /// <summary>
    /// Entry point of the Cybersecurity Awareness Chatbot application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method that starts the chatbot application.
        /// </summary>
        /// <param name="args">Command-line arguments (not used).</param>
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Chatbot"; // Set the console window title
            var player = new Player(); // Initialize the audio player
            var display = new Display(); // Initialize the ASCII art display
            var startChat = new StartChat(); // Initialize the chat session

            player.PlayVoiceGreeting("greeting.wav"); // Play the voice greeting
            display.DisplayASCIIArt(); // Display the ASCII art
            startChat.InitiateChat(); // Start the chat session
        }
    }
}