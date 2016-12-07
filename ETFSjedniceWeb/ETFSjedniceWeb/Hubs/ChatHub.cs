﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ETFSjedniceWeb
{
    public class ChatHub : Hub
    {
        public void Send(string message)
        {
            
            Clients.All.newMessage(Context.User.Identity.Name+" kaže: "+ message);
        }
    }
}