using System;

namespace CybersecurityChatbot
{
    /// <summary>
    /// Main entry point of the chatbot application.
    /// Coordinates the application flow by calling methods from Player, Display, and StartChat.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Set console title for better identification
            Console.Title = "Cybersecurity Awareness Chatbot";

            // Create instances of the handler classes
            var player = new Player();
            var display = new Display();
            var startChat = new StartChat();

            // Play the voice greeting
            player.PlayVoiceGreeting("greeting.wav");

            // Display ASCII art
            display.DisplayASCIIArt();

            // Start the interactive chat session
            startChat.InitiateChat();
        }
    }
}