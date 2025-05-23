using System;

namespace CybersecurityChatbot
{
    /// <summary>
    /// Main entry point of the chatbot application.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Chatbot";
            var player = new Player();
            var display = new Display();
            var startChat = new StartChat();

            player.PlayVoiceGreeting("greeting.wav");
            display.DisplayASCIIArt();
            startChat.InitiateChat();
        }
    }
}