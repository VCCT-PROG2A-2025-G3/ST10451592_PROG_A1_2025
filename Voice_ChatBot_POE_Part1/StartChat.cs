using System;

namespace CybersecurityChatbot
{
    /// <summary>
    /// Manages the chat session, handling user input and coordinating responses.
    /// </summary>
    class StartChat
    {
        private readonly RespondToUser _responder; // Handles processing of user input
        private readonly UserMemory _memory; // Stores user data for memory and recall

        /// <summary>
        /// Initializes a new instance of the StartChat class, setting up the memory and responder.
        /// </summary>
        public StartChat()
        {
            _memory = new UserMemory(); // Initialize user memory
            _responder = new RespondToUser(_memory); // Initialize responder with memory
        }

        /// <summary>
        /// Starts the chat session, greeting the user and handling their inputs until they exit.
        /// </summary>
        public void InitiateChat()
        {
            // Prompt for the user's name
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Hello! What's your name? ");
            Console.ResetColor();

            // Read and validate the user's name
            string userName = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(userName))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Invalid input. I'll call you 'User' for now!");
                Console.ResetColor();
                userName = "User";
            }
            _memory.SetUserName(userName); // Store the user's name

            // Display welcome message
            Console.WriteLine($"\nWelcome, {userName}! I'm your Cybersecurity Awareness Bot.");
            Console.WriteLine("Ask me about password security, scams, privacy, or type 'exit' to quit.");
            Console.WriteLine(new string('=', 60)); // Display a separator line

            // Main chat loop
            while (true)
            {
                // Prompt for user input
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("You: ");
                Console.ResetColor();

                // Read and validate user input
                string userInput = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Chatbot: Please enter a valid question.");
                    Console.ResetColor();
                    continue; // Skip to the next iteration if input is empty
                }

                // Check for exit command
                if (userInput.ToLower() == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Chatbot: Stay safe online, {_memory.GetUserName()}! Goodbye.");
                    Console.ResetColor();
                    break; // Exit the chat loop
                }

                // Process the user's input
                _responder.ProcessInput(userInput);
            }
        }
    }
}