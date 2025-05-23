using System;

namespace CybersecurityChatbot
{
    /// <summary>
    /// Initiates and manages the chat session, prompting for user input and handling the conversation.
    /// </summary>
    class StartChat
    {
        private readonly RespondToUser _responder;
        private readonly UserMemory _memory;

        public StartChat()
        {
            _memory = new UserMemory();
            _responder = new RespondToUser(_memory);
        }

        /// <summary>
        /// Initiates the chat session, prompting for the user's name and handling input.
        /// </summary>
        public void InitiateChat()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Hello! What's your name? ");
            Console.ResetColor();

            string userName = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(userName))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Invalid input. I'll call you 'User' for now!");
                Console.ResetColor();
                userName = "User";
            }
            _memory.SetUserName(userName);

            Console.WriteLine($"\nWelcome, {userName}! I'm your Cybersecurity Awareness Bot.");
            Console.WriteLine("Ask me about password security, scams, privacy, or type 'exit' to quit.");
            Console.WriteLine(new string('=', 60));

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("You: ");
                Console.ResetColor();

                string userInput = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Chatbot: Please enter a valid question.");
                    Console.ResetColor();
                    continue;
                }

                if (userInput.ToLower() == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Chatbot: Stay safe online, {_memory.GetUserName()}! Goodbye.");
                    Console.ResetColor();
                    break;
                }

                _responder.ProcessInput(userInput);
            }
        }
    }
}