using System;
// This Cybersecurity Awareness Chatbot was developed with assistance from Grok 3, an AI model created by xAI.
// Namespace for the Cybersecurity Awareness Chatbot application
namespace CybersecurityChatbot
{
    /// <summary>
    /// Main entry point of the chatbot application.
    /// Coordinates the application flow by calling methods from Player, Display, and StartChat.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method that serves as the entry point for the application.
        /// </summary>
        /// <param name="args">Command-line arguments (not used)</param>
        static void Main(string[] args)
        {
            // Set the console window title for better identification
            Console.Title = "Cybersecurity Awareness Chatbot";

            // Create instances of the handler classes
            var player = new Player(); // Handles audio playback
            var display = new Display(); // Manages ASCII art display
            var startChat = new StartChat(); // Manages chat interaction

            // Play the voice greeting audio
            player.PlayVoiceGreeting("greeting.wav");

            // Display the ASCII art logo
            display.DisplayASCIIArt();

            // Start the interactive chat session
            startChat.InitiateChat();
        }
    }
}