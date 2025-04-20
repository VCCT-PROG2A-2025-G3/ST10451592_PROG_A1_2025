// StartChat.cs
namespace CybersecurityChatbot
{
    /// <summary>
    /// Initiates and manages the chat session, prompting for user input and handling the conversation.
    /// </summary>
    class StartChat
    {
        private readonly RespondToUser _responder;

        public StartChat()
        {
            _responder = new RespondToUser();
        }

        /// <summary>
        /// Initiates the chat session, prompting for the user's name and handling input.
        /// Continues the conversation until the user types 'exit'.
        /// </summary>
        public void InitiateChat()
        {
            // Prompt for user name with colored text for emphasis
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Hello! What's your name? ");
            Console.ResetColor();

            string userName = Console.ReadLine()?.Trim();

            // Validate user name input
            if (string.IsNullOrEmpty(userName))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Invalid input. I'll call you 'User' for now!");
                Console.ResetColor();
                userName = "User";
            }

            // Welcome message with personalized greeting
            Console.WriteLine($"\nWelcome, {userName}! I'm your Cybersecurity Awareness Bot.");
            Console.WriteLine("Ask me about password security, phishing, safe browsing, or type 'exit' to quit.");

            // Add a divider for visual structure
            Console.WriteLine(new string('=', 60));

            // Main chat loop
            while (true)
            {
                // Prompt for user input
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("You: ");
                Console.ResetColor();

                string userInput = Console.ReadLine()?.Trim().ToLower();

                // Validate input
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Chatbot: Please enter a valid question.");
                    Console.ResetColor();
                    continue;
                }

                // Exit condition
                if (userInput == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Chatbot: Stay safe online! Goodbye.");
                    Console.ResetColor();
                    break;
                }

                // Process user input and respond
                _responder.ProcessInput(userInput);
            }
        }
    }
}