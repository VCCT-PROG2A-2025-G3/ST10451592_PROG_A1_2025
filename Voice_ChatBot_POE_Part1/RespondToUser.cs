using System;
using System.Threading; // For simulating typing effect

// Namespace for the Cybersecurity Awareness Chatbot application
namespace CybersecurityChatbot
{
    /// <summary>
    /// Processes user input and provides detailed responses for specific cybersecurity queries.
    /// </summary>
    class RespondToUser
    {
        /// <summary>
        /// Processes user input and provides detailed responses for specific queries.
        /// Includes a default response for unrecognized inputs.
        /// </summary>
        /// <param name="input">User's input string</param>
        public void ProcessInput(string input)
        {
            // Initialize response variable to store the chatbot's reply
            string response;

            // Use switch to match input (converted to lowercase) with predefined queries
            switch (input.ToLower())
            {
                case "how are you":
                    // Friendly response encouraging further interaction
                    response = "I'm doing great, thanks for asking! As a cybersecurity bot, my circuits are always buzzing with tips to keep you safe online. Want to dive into a topic like password security or phishing? Just let me know!";
                    break;

                case "what's your purpose":
                    // Explain the bot's role in educating users about cybersecurity
                    response = "My mission is to empower you with knowledge about staying secure in the digital world! I provide practical advice on topics like creating strong passwords, spotting phishing scams, and browsing the web safely. By raising awareness about common cyber threats, I help you protect your personal information and stay one step ahead of cybercriminals.";
                    break;

                case "what can i ask you about":
                    // List available topics to guide user queries
                    response = "I'm here to answer a wide range of cybersecurity questions! You can ask about best practices for password security, how to recognize and avoid phishing attacks, tips for safe web browsing, or even general advice on protecting your data. If you're curious about specific threats like malware or two-factor authentication, I can dive into those too. Just type a topic or question, and I'll share some insights!";
                    break;

                case "password security":
                    // Provide detailed password security best practices
                    response = "Password security is crucial for protecting your accounts! Here are some key tips: First, create strong passwords that are at least 12 characters long, combining uppercase and lowercase letters, numbers, and special symbols (like ! or #). Avoid using easily guessable information like your name or birthdate. Second, never reuse passwords across different accounts—each one should be unique. Consider using a reputable password manager to generate and store complex passwords securely. Finally, enable two-factor authentication (2FA) whenever possible for an extra layer of protection. Want tips on choosing a good password manager?";
                    break;

                case "phishing":
                    // Explain phishing attacks and how to avoid them
                    response = "Phishing is a common tactic cybercriminals use to trick you into revealing sensitive information, like login credentials or financial details. These attacks often come as emails, text messages, or even phone calls that appear to be from a trusted source. To stay safe, always verify the sender’s email address or phone number before responding. Look for red flags like urgent language, spelling errors, or requests for personal information. Never click on suspicious links or download attachments from unknown sources. If you’re unsure, contact the organization directly using a verified website or phone number. Pro tip: Hover over links (without clicking) to see the actual URL. Want to know how to report a phishing attempt?";
                    break;

                case "safe browsing":
                    // Share safe browsing habits to reduce cyber risks
                    response = "Safe browsing habits can significantly reduce your risk of falling victim to cyber threats! Always ensure websites use 'https://' and display a padlock icon, indicating a secure connection. Be cautious about clicking on pop-up ads or links from untrusted sources, as they may lead to malicious sites. Keep your browser and antivirus software updated to protect against the latest threats. Avoid using public Wi-Fi for sensitive tasks like online banking unless you’re using a virtual private network (VPN) to encrypt your connection. Also, consider adjusting your browser’s privacy settings to block trackers and limit data collection. Curious about choosing a reliable VPN?";
                    break;

                default:
                    // Default response for unrecognized inputs
                    response = "Hmm, I didn’t catch that one! Could you rephrase or try asking about something specific, like password security, phishing, or safe browsing? I’m here to help with all your cybersecurity questions!";
                    break;
            }

            // Simulate typing effect for a conversational feel
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Chatbot: "); // Display chatbot prefix
            Console.ResetColor();

            // Write each character with a slight delay to mimic typing
            foreach (char c in response)
            {
                Console.Write(c);
                Thread.Sleep(30); // 30ms delay per character
            }
            Console.WriteLine(); // Add newline after response
        }
    }
}