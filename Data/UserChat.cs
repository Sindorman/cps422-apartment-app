using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apartment_app.Data
{
    /// <summary>
    /// User chat class.
    /// </summary>
    public class UserChat
    {
        public int ID;
        /// <summary>
        /// User 1.
        /// </summary>
        private string user1;

        /// <summary>
        /// User 2.
        /// </summary>
        private string user2;

        /// <summary>
        /// Messages of the chat.
        /// </summary>
        private List<Tuple<DateTime, string, string>> messages;

        /// <summary>
        /// Send messages to other user.
        /// </summary>
        /// <param name="date">date of the message</param>
        /// <param name="user">user recieving</param>
        /// <param name="message">Message to be sent</param>
        /// <returns>True if message was sent, false if not sent.</returns>
        public bool SendMessage(DateTime date, string user, string message)
        {
            this.messages.Add(new Tuple<DateTime, string, string>(date, user, message));
            return true;
        }
    }
}
