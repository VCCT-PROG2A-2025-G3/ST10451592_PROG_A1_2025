using System;
using System.Media;

namespace CybersecurityChatbot
{
    /// <summary>
    /// Handles playing audio files for the chatbot, such as the greeting.
    /// </summary>
    class Player
    {
        /// <summary>
        /// Plays a voice greeting from a WAV file.
        /// </summary>
        /// <param name="filePath">The path to the WAV file to play.</param>
        public void PlayVoiceGreeting(string filePath)
        {
            try
            {
                // Create a SoundPlayer instance and load the WAV file
                using (var player = new SoundPlayer(filePath))
                {
                    player.PlaySync(); // Play the audio synchronously
                }
            }
            catch (Exception ex)
            {
                // Handle errors gracefully by displaying a message
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Chatbot: Couldn't play the greeting audio. Error: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}