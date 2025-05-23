using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    /// <summary>
    /// Manages user-specific data for memory and recall functionality.
    /// </summary>
    class UserMemory
    {
        private string _userName;
        private string _favoriteTopic;
        private readonly List<string> _conversationHistory;

        public UserMemory()
        {
            _userName = "User"; // Default name
            _favoriteTopic = null;
            _conversationHistory = new List<string>();
        }

        /// <summary>
        /// Sets the user's name.
        /// </summary>
        public void SetUserName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                _userName = name.Trim();
        }

        /// <summary>
        /// Gets the user's name.
        /// </summary>
        public string GetUserName() => _userName;

        /// <summary>
        /// Sets the user's favorite cybersecurity topic.
        /// </summary>
        public void SetFavoriteTopic(string topic)
        {
            if (!string.IsNullOrEmpty(topic))
                _favoriteTopic = topic.Trim().ToLower();
        }

        /// <summary>
        /// Gets the user's favorite cybersecurity topic.
        /// </summary>
        public string GetFavoriteTopic() => _favoriteTopic;

        /// <summary>
        /// Adds a user input to the conversation history.
        /// </summary>
        public void AddToHistory(string input)
        {
            if (!string.IsNullOrEmpty(input))
                _conversationHistory.Add(input.Trim());
        }

        /// <summary>
        /// Retrieves the last user input from the conversation history.
        /// </summary>
        public string GetLastInput() => _conversationHistory.Count > 0 ? _conversationHistory[^1] : null;
    }
}