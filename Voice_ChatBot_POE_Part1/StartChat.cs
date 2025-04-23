// This Cybersecurity Awareness Chatbot was developed with assistance from Grok 3, an AI model created by xAI.
// Namespace for the Cybersecurity Awareness Chatbot application
namespace CybersecurityChatbot
{
    /// <summary>
    /// Initiates and manages the chat session, prompting for user input and handling the conversation.
    /// </summary>
    class StartChat
    {
        // Private field to hold the RespondToUser instance for processing user inputs
        private readonly RespondToUser _responder;

        /// <summary>
        /// Constructor that initializes the RespondToUser instance.
        /// </summary>
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
            // Prompt for user name with green text for visual emphasis
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Hello! What's your name? ");
            Console.ResetColor();

            // Read and trim user input for the name
            string userName = Console.ReadLine()?.Trim();

            // Validate user name input; assign default if empty or null
            if (string.IsNullOrEmpty(userName))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Invalid input. I'll call you 'User' for now!");
                Console.ResetColor();
                userName = "User";
            }

            // Display a personalized welcome message
            Console.WriteLine($"\nWelcome, {userName}! I'm your Cybersecurity Awareness Bot.");
            Console.WriteLine("Ask me about password security, phishing, safe browsing, or type17 'exit' to quit.");

            // Add a divider for visual structure
            Console.WriteLine(new string('=', 60));

            // Main chat loop to handle user interaction
            while (true)
            {
                // Prompt for user input with green text for clarity
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("You: ");
                Console.ResetColor();

                // Read and normalize user input to lowercase for consistent processing
                string userInput = Console.ReadLine()?.Trim().ToLower();

                // Validate input; prompt for valid input if empty
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Chatbot: Please enter a valid question.");
                    Console.ResetColor();
                    continue;
                }

                // Check for exit command to terminate the chat session
                if (userInput == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Chatbot: Stay safe online! Goodbye.");
                    Console.ResetColor();
                    break;
                }

                // Process user input using the RespondToUser instance
                _responder.ProcessInput(userInput);
            }
        }
    }
}