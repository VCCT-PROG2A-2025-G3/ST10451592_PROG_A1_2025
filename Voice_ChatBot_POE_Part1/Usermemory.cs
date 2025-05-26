using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    /// <summary>
    /// Manages user-specific data to enable memory and recall functionality in the chatbot.
    /// </summary>
    class UserMemory
    {
        private string _userName; // Stores the user's name
        private string _favoriteTopic; // Stores the user's favorite cybersecurity topic
        private string _lastKeyword; // Stores the last keyword discussed
        private readonly List<string> _conversationHistory; // Stores the history of user inputs

        /// <summary>
        /// Initializes a new instance of the UserMemory class with default values.
        /// </summary>
        public UserMemory()
        {
            _userName = "User"; // Default name if none provided
            _favoriteTopic = null; // Favorite topic is initially unset
            _lastKeyword = null; // Last keyword is initially unset
            _conversationHistory = new List<string>(); // Initialize empty conversation history
        }

        /// <summary>
        /// Sets the user's name after trimming any whitespace.
        /// </summary>
        /// <param name="name">The user's name to store.</param>
        public void SetUserName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                _userName = name.Trim(); // Store the trimmed name
        }

        /// <summary>
        /// Retrieves the user's name.
        /// </summary>
        /// <returns>The user's name.</returns>
        public string GetUserName() => _userName;

        /// <summary>
        /// Sets the user's favorite cybersecurity topic after trimming and converting to lowercase.
        /// </summary>
        /// <param name="topic">The favorite topic to store.</param>
        public void SetFavoriteTopic(string topic)
        {
            if (!string.IsNullOrEmpty(topic))
                _favoriteTopic = topic.Trim().ToLower(); // Store the trimmed, lowercase topic
        }

        /// <summary>
        /// Retrieves the user's favorite cybersecurity topic.
        /// </summary>
        /// <returns>The user's favorite topic, or null if not set.</returns>
        public string GetFavoriteTopic() => _favoriteTopic;

        /// <summary>
        /// Sets the last keyword discussed.
        /// </summary>
        /// <param name="keyword">The keyword to store.</param>
        public void SetLastKeyword(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                _lastKeyword = keyword.Trim().ToLower(); // Store the trimmed, lowercase keyword
        }

        /// <summary>
        /// Retrieves the last keyword discussed.
        /// </summary>
        /// <returns>The last keyword, or null if not set.</returns>
        public string GetLastKeyword() => _lastKeyword;

        /// <summary>
        /// Adds a user input to the conversation history.
        /// </summary>
        /// <param name="input">The user input to store.</param>
        public void AddToHistory(string input)
        {
            if (!string.IsNullOrEmpty(input))
                _conversationHistory.Add(input.Trim()); // Store the trimmed input
        }

        /// <summary>
        /// Retrieves the most recent user input from the conversation history.
        /// </summary>
        /// <returns>The last user input, or null if the history is empty.</returns>
        public string GetLastInput() => _conversationHistory.Count > 0 ? _conversationHistory[^1] : null;
    }
}