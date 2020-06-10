using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using BasicChat;
using System.Threading.Tasks;


namespace WolfClan.SoliHub.Portal.Hubs
{
    public class ChatHub  : Hub
    {
        // Save users ConnectionId and GroupName (If exist)
        private static Dictionary<string, string> users = new Dictionary<string, string>();

        /// On user connected
        public override  Task OnConnected()
        {
            return base.OnConnected();

        }



        /// On user disconnected
        public override  Task OnDisconnected(bool exception)
        {
            if (users.ContainsKey(Context.ConnectionId)) // If user exist in users list
            {
                string groupName = users[Context.ConnectionId];

                // If user already is in a group
                if (groupName != "-1")
                    Clients.Group(groupName).StrangerLeft();

                // Remove the user from the list
                users.Remove(Context.ConnectionId);
            }

            // Refresh online users and send onlineUsersStr to all connections
            int onlineUsersCount = GetUsersList();
            string onlineUsersStr = onlineUsersCount >= 100000 ? ("+100000") : onlineUsersCount.ToString();

            Clients.All.GetOnlineUsers(onlineUsersStr);
            return  base.OnDisconnected(exception);
        }



        // Check the online users number
        public  void CheckOnlineUsers(string url)
        {
            // If user is in "chat.html" page, add him to users list
            if (url.Contains("/Chat"))
            {
                users.Add(Context.ConnectionId, "-1");
            }

            // Refresh online users and send onlineUsersStr to all connections
            int onlineUsersCount = GetUsersList();
            string onlineUsersStr = onlineUsersCount.ToString();

            //return Clients.All.Send("GetOnlineUsers", onlineUsersStr);
             Clients.All.GetOnlineUsers(onlineUsersStr);

        }

        // Search a stranger to connect and chat
        public  void SearchStranger()
        {
            // Find a stranger ConnectionId
            string aloneStrangerId = users.FirstOrDefault(user => (user.Value == "-1" && user.Key != Context.ConnectionId)).Key;

            // If alone stranger found
            if (aloneStrangerId != null)
            {
                // Set a group and add them to the group
                string groupName = Context.ConnectionId + aloneStrangerId;

                users[aloneStrangerId] = groupName;
                users[Context.ConnectionId] = groupName;

                 Groups.Add(Context.ConnectionId, groupName);
                 Groups.Add(aloneStrangerId, groupName);

                // Send message and let them to start the chat
                 Clients.Clients(new List<string>() { aloneStrangerId, Context.ConnectionId }).JoinToStranger(true);
            }
            else
            {
                // Send a message to caller, alone stranger not found
                Clients.Caller.JoinToStranger(false);
            }
        }

        // When one of the starnger left the chat, remove the group
        public  Task DeleteRoom()
        {
            string groupName = users[Context.ConnectionId];
            return  Groups.Remove(Context.ConnectionId, groupName);
        }

        // When caller left the chat
        public  Task LeftChat()
        {
            // Remove caller from the group
            string groupName = users[Context.ConnectionId];

             Groups.Remove(Context.ConnectionId, groupName);
         return   Clients.Group(groupName).StrangerLeft();
        }

        // Send caller message to other in group
        public  Task SendMessage(string message)
        {
            string groupName = users[Context.ConnectionId];
           return  Clients.OthersInGroup(groupName).ReceiveMessage(message);
        }

        // Send caller isTyping to other in group
        public  Task IsTyping()
        {
            string groupName = users[Context.ConnectionId];
           return   Clients.OthersInGroup(groupName).StrangerIsTyping();
        }

        // Get the online users
        public static int GetUsersList()
        {
                return users.Count;
        }
    }
}