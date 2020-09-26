using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apartment_app.Data
{
    public class UserChat
    {
        private string user1;
        private string user2;
        private List<Tuple<string, string, string>> Messages;

        /// <summary>
        /// Send messages to other user.
        /// </summary>
        /// <param name="Message">Message to be sent</param>
        /// <returns>True if message was sent, false if not sent.</returns>
        private bool sendMessage(string date, string user, string Message)
        {
            return true;
        }
    }
}
