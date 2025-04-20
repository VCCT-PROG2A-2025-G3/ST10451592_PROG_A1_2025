using System;
using System.Media; // For SoundPlayer
using System.IO; // For file path handling

namespace CybersecurityChatbot
{
    /// <summary>
    /// Handles audio-related functionality, specifically playing the voice greeting.
    /// </summary>
    class Player
    {
        /// <summary>
        /// Plays a WAV audio file as a voice greeting.
        /// Handles errors if the file is missing or corrupted.
        /// </summary>
        /// <param name="filePath">Relative path to the WAV file (e.g., 'greeting.wav' or 'audio/greeting.wav')</param>
        public void PlayVoiceGreeting(string filePath)
        {
            try
            {
                // Resolve the full path relative to the executing directory
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);

                // Check if the file exists to avoid unnecessary exceptions
                if (!File.Exists(fullPath))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: Voice greeting file '{filePath}' not found at '{fullPath}'. Please ensure the file is in the correct directory.");
                    Console.ResetColor();
                    return;
                }

                // Use SoundPlayer to play the WAV file synchronously
                using (SoundPlayer player = new SoundPlayer(fullPath))
                {
                    player.PlaySync(); // Plays the audio and waits until it finishes
                }
            }
            catch (Exception ex)
            {
                // Handle any errors (e.g., invalid file format, file access issues)
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error playing voice greeting: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}