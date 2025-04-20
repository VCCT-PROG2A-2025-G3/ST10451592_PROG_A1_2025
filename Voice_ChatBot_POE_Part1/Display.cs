// Display.cs
using System;

namespace CybersecurityChatbot
{
    /// <summary>
    /// Manages the display of ASCII art for the Cybersecurity Awareness Chatbot.
    /// </summary>
    class Display
    {
        /// <summary>
        /// Displays an ASCII art logo for the Cybersecurity Awareness Chatbot.
        /// Uses colored text to enhance visual appeal.
        /// </summary>
        public void DisplayASCIIArt()
        {
            // Set text color to cyan for a professional and visually distinct look
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
   _____       _                 _         _   _        _    
  / ____|     | |               | |       | | (_)      | |   
 | |  __ _   _| |_ ___ _ __   __| | __ _  | |_ _  ___  | |_  
 | | |_ | | | | __/ _ \ '_ \ / _` |/ _` | | __| |/ _ \ | __| 
 | |__| | |_| | ||  __/ | | | (_| | (_| | | |_| |  __/ | |_  
  \_____|\__,_|\__\___|_| |_|\__,_|\__,_|  \__|_|\___|  \__| 
            ");
            Console.WriteLine("Cybersecurity Awareness Bot\n");
            Console.ResetColor(); // Reset to default color after display

            // Add a decorative border for readability
            Console.WriteLine(new string('-', 60));
        }
    }
}